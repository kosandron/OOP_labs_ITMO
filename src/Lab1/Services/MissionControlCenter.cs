using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class MissionControlCenter
{
    public RequestResult TryToFlyGalactic(ref ShipBase ship, GalacticBase galactic, in Burse burse)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (galactic == null)
        {
            throw new ArgumentNullException(nameof(galactic));
        }

        if (burse == null)
        {
            throw new ArgumentNullException(nameof(burse));
        }

         // доступность прохода двигателя через голактику - иначе 0 0 0 2

        int time = ship.ShipImpulsEngine.GetTimeForPath(galactic.Size); // расчет через формулу, использовать другую
        int cost = 0; // расчет за единицу
        
        // проход по метеорам, получение дамага
        
        // возвращение результата
    }

    public RequestResult TryToFlyWay(ShipBase ship, Collection<GalacticBase> way, in Burse burse)
    {
        if (way == null)
        {
            throw new ArgumentNullException(nameof(way));
        }

        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (burse == null)
        {
            throw new ArgumentNullException(nameof(burse));
        }

        // maybe создание промежуточных переменных для рекорда
        foreach (GalacticBase galactic in way)
        {
            TryToFlyGalactic(ref ship, galactic, in burse);
            // обработка рекорда
        }
        // вынесение приговора, возврат рекорда
    }
    
    // метод, принимающий коллекцию кораблей и возвращающий лучший корабль
}