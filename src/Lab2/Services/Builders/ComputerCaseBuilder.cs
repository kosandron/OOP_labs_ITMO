using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class ComputerCaseBuilder
{
    private string? _name;
    private int _maxVideoCardWidth = -1;
    private int _maxVideoCardHeight = -1;
    private IList<MotherBoardFormFactorTypes>? _supportedFormFactorTypes;
    private CaseSize _size = CaseSize.None;

    public ComputerCaseBuilder() { }
    public ComputerCaseBuilder(ComputerCase otherComputerCase)
    {
        if (otherComputerCase == null)
        {
            throw new ArgumentNullException(nameof(otherComputerCase));
        }

        _name = otherComputerCase.Name;
        _maxVideoCardWidth = otherComputerCase.MaxVideoCardWidth;
        _maxVideoCardHeight = otherComputerCase.MaxVideoCardHeight;
        _supportedFormFactorTypes = otherComputerCase.SupportedFormFactorTypes;
        _size = otherComputerCase.Size;
    }

    public ComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ComputerCaseBuilder WithMaxVideoCardWidth(int maxVideoCardWidth)
    {
        if (maxVideoCardWidth <= 0)
        {
            throw new NegativeValueException("Maximal videocard width is less than 0!");
        }

        _maxVideoCardWidth = maxVideoCardWidth;
        return this;
    }

    public ComputerCaseBuilder WithMaxVideoCardHeight(int maxVideoCardHeight)
    {
        if (maxVideoCardHeight <= 0)
        {
            throw new NegativeValueException("Maximal videocard height is less than 0!");
        }

        _maxVideoCardHeight = maxVideoCardHeight;
        return this;
    }

    public ComputerCaseBuilder WithSupportedFormFactorTypes(IList<MotherBoardFormFactorTypes> supportedFormFactorTypes)
    {
        if (supportedFormFactorTypes == null)
        {
            throw new ArgumentNullException(nameof(supportedFormFactorTypes));
        }

        if (supportedFormFactorTypes.Count == 0)
        {
            throw new ArgumentException("There are no one supported motherboard!");
        }

        _supportedFormFactorTypes = supportedFormFactorTypes;
        return this;
    }

    public ComputerCaseBuilder WithSize(CaseSize size)
    {
        _size = size;
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(_name, _maxVideoCardWidth, _maxVideoCardHeight, _supportedFormFactorTypes, _size);
    }
}