# pinpayments.net
PinPayments.net is an async .net Standard library for the Pin Payments API (https://pinpayments.com/developers/api-reference/)

## Installation
Using the .NET Core command-line interface (CLI) tools:

``` dotnet add package PinPayments.net ```

Using the NuGet Command Line Interface (CLI):

``` nuget install PinPayments.net ```

Using the Package Manager Console:

``` Install-Package PinPayments.net ```

From within Visual Studio:

Open the Solution Explorer.
Right-click on a project within your solution.
Click on Manage NuGet Packages...
Click on the Browse tab and search for "PinPayments.net".
Click on the PinPayments.net package, select the appropriate version in the right-tab and click Install.

## Usage

### Initialisation
Before you can use the PinPayments.net client, you first need to configure it in your application.

For a web application, call the following code in Startup.cs"

``` PinPaymentsConfiguration.Initialise("PinPaymentsApiKey"); ```

This will initialise the PinPayments Client for the test environment, with default currency AUD.

This settings can be changed by instead calling:

``` PinPaymentsConfiguration.Initialise("PinPaymentsApiKey", PinEnvironment.Live, Currency.AUD); ```

### Creating a Charge

```
var chargeService = new ChargeService();
            
var createOptions = new ChargeCreateOptions
{
    Email = "test@example.com",
    Description = "Order number 12345"
    Amount = 10000, //amount in cents
    Currency = Currency.AUD,
    CardToken = "token",
    IPAddress = "127.0.0.1,
    Metadata = new Dictionary<string,string>()
};
            
var chargeResponse = await chargeService.Create(createOptions);

if (chargeResponse.Success)
{
    //do something
}
```
