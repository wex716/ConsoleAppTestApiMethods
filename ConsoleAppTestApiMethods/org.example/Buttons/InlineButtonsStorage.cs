namespace ConsoleAppTestApiMethods.org.example.Buttons;

public class InlineButtonsStorage
{
    public static InlineButton GetCurrentExchangeRate { get; } =
        new InlineButton("Показать текущий курс валют", "GetCurrentExchangeRate");
}