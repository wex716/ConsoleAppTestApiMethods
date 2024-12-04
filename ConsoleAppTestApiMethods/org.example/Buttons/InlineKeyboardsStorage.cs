using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTestApiMethods.org.example.Buttons;

public class InlineKeyboardsStorage
{
    public static InlineKeyboardMarkup GetMainMenuKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.GetCurrentExchangeRate.Name,
                InlineButtonsStorage.GetCurrentExchangeRate.CallBackData),
        }
    });
}