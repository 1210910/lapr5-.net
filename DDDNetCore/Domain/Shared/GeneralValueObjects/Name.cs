using System;

namespace DDDSample1.Domain.Shared.generalValueObjects
{
    public class Name
    {
        public string FirstName { get; }
        public string LastName { get; }
        
        public string FullName { get; set; }

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
            FullName = fullName;
        }
        
        private Name()
        {
            // Private constructor to enforce creation via static method
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        
        public string Value 
        {
            get => FullName;
            
            private set => FullName = ToString();
        }
    }
}