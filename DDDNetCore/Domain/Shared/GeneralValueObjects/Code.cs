using System;

namespace DDDSample1.Domain.Shared.generalValueObjects;

public class Code
{
    private string _value;

    public string Value
    {
        get => _value;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Code cannot be null or empty.");
            }

            if (value.Length < 4 || value.Length > 6)
            {
                throw new ArgumentException("Code must be between 4 and 6 digits.");
            }

            if (!int.TryParse(value, out _))
            {
                throw new ArgumentException("Code must contain only digits.");
            }

            _value = value;
        }
    }

    private Code()
    {
        // Private constructor to enforce creation via static method
    }

    public static Code Create(string code)
    {
        var newCode = new Code();
        newCode.Value = code;
        return newCode;
    }
}