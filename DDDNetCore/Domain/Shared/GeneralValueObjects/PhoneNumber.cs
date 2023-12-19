using System;

namespace DDDSample1.Domain.Shared.generalValueObjects
{
    public class PhoneNumber
    {
        private readonly string _phoneNumber;

        public PhoneNumber(string phoneNumber)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid phone number");
                
            }

            _phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return _phoneNumber;
        }

        // Validation method to check if the phone number is valid
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Implement your validation logic here
            // Example: Check if the phone number has the correct format
            // You can use regular expressions or other validation methods

            // For simplicity, let's say a valid phone number has 10 digits
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 10 && IsNumeric(phoneNumber);
        }

        // Helper method to check if a string contains only numeric characters
        private bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}