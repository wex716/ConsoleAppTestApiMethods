using System.Globalization;
using System.Text.Json.Nodes;

namespace ConsoleAppTestApiMethods.CbrApi;

public class CbrApiWorker
{
    public ExchangeRate GetCurrentExchangeRate()
    {
        HttpClient httpClient = new HttpClient();

        string jsonAsString = httpClient.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js").Result;
        
        JsonObject jsonObject = JsonObject.Parse(jsonAsString).AsObject();

        DateTime dateTime = DateTime.Parse(jsonObject["Date"].ToString());
        
        double usd = double.Parse(jsonObject["Valute"]["USD"]["Value"].ToString(), CultureInfo.InvariantCulture);
        
        double eur = double.Parse(jsonObject["Valute"]["EUR"]["Value"].ToString(), CultureInfo.InvariantCulture);
        
        double kzt = double.Parse(jsonObject["Valute"]["KZT"]["Value"].ToString(), CultureInfo.InvariantCulture);
        
        int numCode = int.Parse(jsonObject["Valute"]["NZD"]["NumCode"].ToString(), CultureInfo.InvariantCulture);

        return new ExchangeRate() { DateTime = dateTime, Usd = usd, Eur = eur, Kzt = kzt, NumCode = numCode };
    }
}