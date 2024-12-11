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
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ShowTop250Movies.Name,
                InlineButtonsStorage.ShowTop250Movies.CallBackData),
        },
        new[]
        {
        InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ShowPostById.Name,
        InlineButtonsStorage.ShowPostById.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ShowPostAll.Name,
                InlineButtonsStorage.ShowPostAll.CallBackData),
        },
    });
}