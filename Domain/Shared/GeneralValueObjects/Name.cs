using System;

namespace DDDSample1.Domain.Shared.generalValueObjects
{
    public class Name
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Name(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty.");
            }

            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
            {
                throw new ArgumentException("Please provide both first name and last name.");
            }

            FirstName = nameParts[0];
            LastName = nameParts[nameParts.Length - 1];
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}