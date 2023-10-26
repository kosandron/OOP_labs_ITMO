using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : IComponent, ICloneable<ComputerCase>, ICopyable<ComputerCase>
{
    private readonly int _maxVideoCardWidth;
    private readonly int _maxVideoCardHeight;
    private readonly IList<MotherBoardFormFactorTypes> _supportedFormFactorTypes;
    private readonly CaseSize _size;

    public ComputerCase(string? name, int maxVideoCardWidth, int maxVideoCardHeight, IList<MotherBoardFormFactorTypes>? supportedFormFactorTypes, CaseSize size)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (maxVideoCardWidth <= 0)
        {
            throw new NegativeValueException("Maximal videocard width is less than 0!");
        }

        if (maxVideoCardHeight <= 0)
        {
            throw new NegativeValueException("Maximal videocard height is less than 0!");
        }

        if (supportedFormFactorTypes?.Count == 0)
        {
            throw new EmptyCollectionException("There are no one supported motherboard!");
        }

        if (!new ComputerCaseSizeValidator().IsValidSize(supportedFormFactorTypes, size))
        {
            throw new ArgumentException("Not valid computer case size!");
        }

        if (size == CaseSize.None)
        {
            throw new ArgumentNullException(nameof(size));
        }

        Name = name;
        _maxVideoCardWidth = maxVideoCardWidth;
        _maxVideoCardHeight = maxVideoCardHeight;
        _supportedFormFactorTypes = supportedFormFactorTypes ?? throw new ArgumentNullException(nameof(supportedFormFactorTypes));
        _size = size;
    }

    public ComputerCase(ComputerCase other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _maxVideoCardWidth = other._maxVideoCardWidth;
        _maxVideoCardHeight = other._maxVideoCardHeight;
        _supportedFormFactorTypes = other._supportedFormFactorTypes;
        _size = other._size;
    }

    public string Name { get; init; }
    public int MaxVideoCardWidth => _maxVideoCardWidth;
    public int MaxVideoCardHeight => _maxVideoCardHeight;

    public ImmutableList<MotherBoardFormFactorTypes> SupportedFormFactorTypes =>
        _supportedFormFactorTypes.ToImmutableList();

    public CaseSize Size => _size;
    public ComputerCase Clone() => new ComputerCase(this);

    public ComputerCase DeepCopy()
    {
        return new ComputerCase(Name, MaxVideoCardWidth, MaxVideoCardHeight, new List<MotherBoardFormFactorTypes>(SupportedFormFactorTypes), Size);
    }
}