using HtmlAgilityPack;

namespace ConsoleAppTestApiMethods.org.example.ImdbParser;

public class ImdbSiteParser
{
    public List<Film> GetFirstFilmsFromTop250(int limit)
    {   
        HttpClient httpClient = new HttpClient();
        string htmlString = httpClient.GetStringAsync("https://www.imdb.com/chart/top/").Result;

        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(htmlString);

        HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//h3 [@class='ipc-title__text']");

        string filmInfo = htmlNode.InnerText.Trim(new char[]{' ','\n'});
        int dotPosition = filmInfo.IndexOf(".");
        int filmNumber = int.Parse(filmInfo.Substring(0, dotPosition));

        filmInfo = filmInfo.Remove(0, dotPosition);
        
        return null;
    }
}