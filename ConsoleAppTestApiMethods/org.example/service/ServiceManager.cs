using ConsoleAppTestApiMethods.org.example.statemachine;
using ConsoleAppTetsBot.org.example.service.logic;

namespace ConsoleAppTestApiMethods.org.example.service;

public class ServiceManager
{
    private Dictionary<State, Func<string, TransmittedData, BotTextMessage>> _methods;

    private StartLogic _startLogic;

    public ServiceManager()
    {
        _methods = new Dictionary<State, Func<string, TransmittedData, BotTextMessage>>();

        _startLogic = new StartLogic();

        _methods.Add(State.WaitingCommandStart, _startLogic.ProcessWaitingCommandStart);
        _methods.Add(State.WaitingReadCbrApi,
            _startLogic.ProcessWaitingWaitingReadCbrApi);
    }

    public BotTextMessage ProcessBotUpdate(string textData, TransmittedData transmittedData)
    {
        var serviceMethod = _methods[transmittedData.State];

        return serviceMethod.Invoke(textData, transmittedData);
    }
}