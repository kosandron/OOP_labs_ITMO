using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public class PhotonDeflectorBase
{
    private const int BasicPosibleHitsCount = 3;
    private int _hits;

    public PhotonDeflectorBase(int posibleHitsCount = BasicPosibleHitsCount)
    {
        if (posibleHitsCount < 0)
        {
            throw new NegativeValueException(nameof(posibleHitsCount));
        }

        _hits = posibleHitsCount;
    }

    public int Hits => _hits;
    public bool IsDead => Hits == 0;
    public void TakeDamage()
    {
        _hits = Math.Max(Hits - 1, 0);
    }
}
