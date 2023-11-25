using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class LoggedAdressee : IAdressee
{
    private readonly IAdressee _adressee;
    private readonly ILogger _logger;

    public LoggedAdressee(IAdressee adressee, ILogger logger)
    {
        if (adressee is null)
        {
            throw new ArgumentNullException(nameof(adressee));
        }

        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        _adressee = adressee;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _adressee.SendMessage(message);
        _logger.Log(message);
    }
}