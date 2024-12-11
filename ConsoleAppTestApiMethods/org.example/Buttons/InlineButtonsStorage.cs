namespace ConsoleAppTestApiMethods.org.example.Buttons;

public class InlineButtonsStorage
{
    public static InlineButton GetCurrentExchangeRate { get; } =
        new InlineButton("Показать текущий курс валют", "GetCurrentExchangeRate");

    public static InlineButton ShowTop250Movies { get; } =
        new InlineButton("Показать топ фильмов с IMDb top 250 movies", "ShowTop250Movies");

    public static InlineButton ShowPostById { get; } =
        new InlineButton("Показать пост по id", "ShowPostById");

    public static InlineButton ShowPostAll { get; } =
        new InlineButton("Показать все посты", "ShowPostAll");
}