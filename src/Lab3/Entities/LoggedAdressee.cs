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

    public void GetMessage(Message message)
    {
        _adressee.GetMessage(message);
        _logger.Log(message);
    }
}