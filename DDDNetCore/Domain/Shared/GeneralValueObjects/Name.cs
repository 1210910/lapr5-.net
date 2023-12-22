using System;

namespace DDDSample1.Domain.Shared.generalValueObjects
{
    public class Name
    {


        public string _fullName;

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

            
            _fullName = fullName;
        }
        
        private Name()
        {
            // Private constructor to enforce creation via static method
        }

        public override string ToString()
        {
            return _fullName;
        }
        
        public string Value 
        {
            get => _fullName;
            
            private set => _fullName = value;
        }
    }
}