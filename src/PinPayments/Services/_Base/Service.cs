namespace PinPayments.Services
{
    using System.Globalization;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using PinPayments.Entities;
    using PinPayments.Json;

    public class Service
    {
        internal async Task<U> Execute<T, U>(HttpMethod method, string url, T data = null)
            where T : class, new()
            where U : class, new()
        {
            return await this.ExecuteRequest<T, U>(method, url, data);
        }

        internal async Task<T> Execute<T>(HttpMethod method, string url)
            where T : class, new()
        {
            return await this.ExecuteRequest<object, T>(method, url, null);
        }

        internal async Task Execute(HttpMethod method, string url)
        {
            await this.ExecuteRequest<object, PinResponse>(method, url);
        }

        internal string GetErrorType(string error)
        {
            var errorName = string.Join(' ', error.Split("_"));
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(errorName.ToLower());
        }

        private async Task<U> ExecuteRequest<T, U>(HttpMethod method, string url, T data = null)
            where T : class, new()
            where U : class, new()
        {
            var requestUrl = $"{Constants.ApiVersion}/{url}";

            HttpResponseMessage response = null;

            if (method == HttpMethod.Get || method == HttpMethod.Delete)
            {
                if (data != null)
                {
                    requestUrl += $"?{Helpers.ObjectToQueryString(data)}";
                }

                if (method == HttpMethod.Get)
                {
                    response = await PinPaymentsConfiguration.Client.GetAsync(requestUrl);
                }
                else if (method == HttpMethod.Delete)
                {
                    response = await PinPaymentsConfiguration.Client.DeleteAsync(requestUrl);
                }
            }
            else
            {
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    WriteIndented = true,
                    Converters =
                                {
                                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                                },
                };
                var jsonString = JsonSerializer.Serialize(data, options);
                var json = new StringContent(
                                jsonString,
                                Encoding.UTF8,
                                "application/json");

                if (method == HttpMethod.Post)
                {
                    response = await PinPaymentsConfiguration.Client.PostAsync(requestUrl, json);
                }
                else if (method == HttpMethod.Put)
                {
                    response = await PinPaymentsConfiguration.Client.PutAsync(requestUrl, json);
                }
            }

            using var responseStream = await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = await JsonSerializer.DeserializeAsync<PinResponse>(responseStream);
                this.ErrorCheck(error);
            };

            var deserialisationOptions = new JsonSerializerOptions()
            {
                Converters = {
                    new EventSerialiser(),
                },
            };

            var returnObject = await JsonSerializer.DeserializeAsync<PinResponse<U>>(responseStream, deserialisationOptions);
            this.ErrorCheck(returnObject);
            if (typeof(IPinList).IsAssignableFrom(typeof(U)) && returnObject.Pagination != null)
            {
                ((IPinList)returnObject.Response).Current = returnObject.Pagination.Current;
                ((IPinList)returnObject.Response).Total = returnObject.Pagination.Count;
                ((IPinList)returnObject.Response).Previous = returnObject.Pagination.Previous;
                ((IPinList)returnObject.Response).Next = returnObject.Pagination.Next;
                ((IPinList)returnObject.Response).Pages = returnObject.Pagination.Pages;
                ((IPinList)returnObject.Response).PageSize = returnObject.Pagination.PageSize;
            }

            return returnObject.Response;
        }

        private void ErrorCheck(IPinResponse pinResponse)
        {
            if (!string.IsNullOrEmpty(pinResponse.Error))
            {
                var errorType = this.GetErrorType(pinResponse.Error);
                throw new PinException(errorType)
                {
                    ErrorType = pinResponse.Error,
                    ErrorDescription = pinResponse.ErrorDescription,
                    Messages = pinResponse.Messages,
                };
            }
        }
    }
}