using System.Text;
using ConsoleAppTestApiMethods;
using ConsoleAppTestApiMethods.CbrApi;
using ConsoleAppTestApiMethods.org.example.Buttons;
using ConsoleAppTestApiMethods.org.example.FakeApi;
using ConsoleAppTestApiMethods.org.example.ImdbParser;
using ConsoleAppTestApiMethods.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class StartLogic
{
    private CbrApiWorker _cbrApiWorker;
    private ImdbSiteParser _imdbSiteParser;
    private FakeApiWorker _fakeApiWorker;

    public StartLogic()
    {
        _imdbSiteParser = new ImdbSiteParser();
        _cbrApiWorker = new CbrApiWorker();
        _fakeApiWorker = new FakeApiWorker();
    }

    public BotTextMessage ProcessWaitingCommandStart(string textFromUser, TransmittedData transmittedData)
    {
        if (textFromUser != "/start")
        {
            return new BotTextMessage("ну ты и блядь ");
        }

        transmittedData.State = State.WaitingReadCbrApi;

        textFromUser = "Сделайте выбор месье";

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetMainMenuKeyboard);
    }

    public BotTextMessage ProcessWaitingWaitingReadCbrApi(string textFromUser,
        TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.GetCurrentExchangeRate.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ShowTop250Movies.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ShowPostById.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ShowPostAll.CallBackData))
        {
            return new BotTextMessage("Ошибка. Нажмите на кнопку.");
        }

        if (textFromUser.Equals(InlineButtonsStorage.GetCurrentExchangeRate.CallBackData))
        {
            ExchangeRate exchangeRate = _cbrApiWorker.GetCurrentExchangeRate();

            return new BotTextMessage(
                $"Курс валют на {exchangeRate.DateTime}\n1 американский доллар: {exchangeRate.Usd} руб.\n1 евроид: {exchangeRate.Eur} руб \n1 казахстнаская монета: {exchangeRate.Kzt} руб.\n цифровой код NZD: {exchangeRate.NumCode}");
        }

        if (textFromUser.Equals(InlineButtonsStorage.ShowTop250Movies.CallBackData))
        {
            // ExchangeRate exchangeRate = _cbrApiWorker.GetCurrentExchangeRate();
            _imdbSiteParser.GetFirstFilmsFromTop250(250);

            return new BotTextMessage("");
        }

        if (textFromUser.Equals(InlineButtonsStorage.ShowPostById.CallBackData))
        {
            FakePost fakePost = _fakeApiWorker.GetById(1);

            return new BotTextMessage(
                $"Id: {fakePost.Id}, \nTitle: {fakePost.Title}, \nBody: {fakePost.Body}, \nUserId: {fakePost.UserId}");
        }

        if (textFromUser.Equals(InlineButtonsStorage.ShowPostAll.CallBackData))
        {
            List<FakePost> fakePosts = _fakeApiWorker.GetByAll().GetRange(0,5);

            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (FakePost fakePost in fakePosts)
            {
                stringBuilder.AppendLine($"userId:{fakePost.UserId}\nid:{fakePost.Id}\ntitle:{fakePost.Title}\nbody:{fakePost.Title}");
            }

            return new BotTextMessage(stringBuilder.ToString());
        }

        return new BotTextMessage(textFromUser);
    }
}