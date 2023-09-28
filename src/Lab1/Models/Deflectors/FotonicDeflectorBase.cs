using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
public class FotonicDeflectorBase
{
    private const int BasicPosibleHitsCount = 3;

    public FotonicDeflectorBase(int posibleHitsCount = BasicPosibleHitsCount)
    {
        if (posibleHitsCount <= 0)
        {
            throw new ArgumentException("Possible hits count is less or equal null!", nameof(posibleHitsCount));
        }

        Hits = posibleHitsCount;
    }

    public int Hits { get; private set; }
    public bool IsDead => Hits == 0;
    public void TakeDamage()
    {
        Hits = Math.Min(Hits - 1, 0);
    }
}
