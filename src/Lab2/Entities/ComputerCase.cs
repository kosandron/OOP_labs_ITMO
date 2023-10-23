using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase
{
    private readonly int _maxVideoCardWidth;
    private readonly int _maxVideoCardHeight;
    private readonly IList<MotherBoardFormFactorTypes> _supportedFormFactorTypes;
    private readonly CaseSize _size;

    public ComputerCase(int maxVideoCardWidth, int maxVideoCardHeight, IList<MotherBoardFormFactorTypes> supportedFormFactorTypes, CaseSize size)
    {
        if (maxVideoCardWidth <= 0)
        {
            throw new NegativeValueException("Maximal videocard width is less than 0!");
        }

        if (maxVideoCardHeight <= 0)
        {
            throw new NegativeValueException("Maximal videocard height is less than 0!");
        }

        if (supportedFormFactorTypes == null)
        {
            throw new ArgumentNullException(nameof(supportedFormFactorTypes));
        }

        if (supportedFormFactorTypes.Count == 0)
        {
            throw new ArgumentException("There are no one supported motherboard!");
        }

        _maxVideoCardWidth = maxVideoCardWidth;
        _maxVideoCardHeight = maxVideoCardHeight;
        _supportedFormFactorTypes = supportedFormFactorTypes;
        _size = size;
    }

    public int MaxVideoCardWidth => _maxVideoCardWidth;
    public int MaxVideoCardHeight => _maxVideoCardHeight;
    public ImmutableList<MotherBoardFormFactorTypes> SupportedFormFactorTypes => _supportedFormFactorTypes.ToImmutableList();
    public CaseSize Size => _size;
}