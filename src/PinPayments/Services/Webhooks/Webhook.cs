namespace PinPayments.Services.Webhooks
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.AspNetCore.Http;
    using PinPayments.Entities.Events;
    using PinPayments.Json;

    public static class WebhookHelpers
    {
        private const string PinSignature = "Pin-Signature";

        public static async Task<Event> Verify(this HttpRequest request, string hashKey, DateTime? validFrom = null)
        {
            try
            {
                if (string.IsNullOrEmpty(hashKey))
                {
                    throw new PinException("Hash Key is required");
                }

                if (request == null)
                {
                    throw new PinException("Request is required");
                }

                // Get Pin Signature
                if (!request.Headers.ContainsKey(PinSignature))
                {
                    throw new PinException("No Pin Signature in request header");
                }

                var pinSignature = request.Headers[PinSignature][0];
                var parameterisedPinSignature = pinSignature.Replace(",", "&");
                var pinSignatureParts = HttpUtility.ParseQueryString(parameterisedPinSignature);

                var t = pinSignatureParts["t"];
                var v1 = pinSignatureParts["v1"];

                if (string.IsNullOrEmpty(t) || string.IsNullOrEmpty(v1))
                {
                    throw new PinException("No Pin Signature header is not valid");
                }

                double dT = 0;
                if (!double.TryParse(t, out dT))
                {
                    dT = double.Parse(t);
                }

                var timestamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                timestamp = timestamp.AddSeconds(dT).ToLocalTime();

                if (validFrom.HasValue && timestamp < validFrom.Value)
                {
                    throw new PinException("Timestamp is out of range");
                };

                if (request.ContentLength == null || !(request.ContentLength > 0) || !request.Body.CanSeek)
                {
                    return null;
                }

                request.EnableBuffering();
                request.Body.Seek(0, SeekOrigin.Begin);

                if (request.Body.Position > 0)
                {
                    request.Body.Seek(0, 0);
                }
                using var streamReader = new StreamReader(request.Body);
                string strBody = streamReader.ReadToEnd();

                // Check HMAC
                var stringToTest = $"{t}.{strBody}";
                var hmac = HmacString(hashKey, stringToTest);

                if (!hmac.Equals(v1))
                {
                    throw new PinException("HMAC does not match");
                }

                var deserialisationOptions = new JsonSerializerOptions()
                {
                    Converters = {
                    new EventSerialiser(),
                },
                };

                var evnt = JsonSerializer.Deserialize<Event>(strBody, deserialisationOptions);

                return evnt;
            }
            catch (Exception exp)
            {
                throw new PinException(exp.Message);
            }
        }

        private static string HmacString(string key, string data)
        {
            var encoder = new ASCIIEncoding();
            var code = encoder.GetBytes(key);
            using var hmac = new HMACSHA256(code);
            var hmBytes = hmac.ComputeHash(encoder.GetBytes(data));
            var hash = ToHexString(hmBytes);
            return hash;
        }

        private static string ToHexString(byte[] array)
        {
            var hexString = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                hexString.AppendFormat("{0:x2}", b);
            }

            return hexString.ToString();
        }
    }
}