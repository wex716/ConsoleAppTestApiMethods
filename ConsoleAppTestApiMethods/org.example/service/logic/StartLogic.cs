using ConsoleAppTestApiMethods;
using ConsoleAppTestApiMethods.CbrApi;
using ConsoleAppTestApiMethods.org.example.Buttons;
using ConsoleAppTestApiMethods.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class StartLogic
{
    private CbrApiWorker _cbrApiWorker;

    public StartLogic()
    {
        _cbrApiWorker = new CbrApiWorker();
    }

    public BotTextMessage ProcessWaitingCommandStart(string textFromUser, TransmittedData transmittedData)
    {
        if (textFromUser != "/start")
        {
            return new BotTextMessage("Тест api ");
        }

        transmittedData.State = State.WaitingReadCbrApi;

        textFromUser = "Посмотрите курс валют";

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetMainMenuKeyboard);
    }
    
    public BotTextMessage ProcessWaitingWaitingReadCbrApi(string textFromUser,
        TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.GetCurrentExchangeRate.CallBackData))
        {
            return new BotTextMessage("Ошибка. Нажмите на кнопку.");
        }

        if (textFromUser.Equals(InlineButtonsStorage.GetCurrentExchangeRate.CallBackData))
        {
            ExchangeRate exchangeRate = _cbrApiWorker.GetCurrentExchangeRate();

            return new BotTextMessage(
                $"Курс валют на {exchangeRate.DateTime}\n1 американский доллар: {exchangeRate.Usd} руб.\n1 евроид: {exchangeRate.Eur} руб \n1 казахстнаская монета: {exchangeRate.Kzt} руб.\n цифровой код NZD: {exchangeRate.NumCode}");
        }

        return new BotTextMessage(textFromUser);
    }
}