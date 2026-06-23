namespace FitControl.Domain.ValueObject
{
    public record class Email
    {
        public string Value { get; private init; }

        public Email() { }

        private Email(string value)
        {       
            Value = value;
        }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be null or empty.", nameof(value));

            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format.", nameof(value));

            return new Email(value);
        }

        public static string GetEmailDomain(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            var atIndex = email.LastIndexOf('@');
            if (atIndex < 0 || atIndex == email.Length - 1)
                throw new ArgumentException("Invalid email format.", nameof(email));
            return email.Substring(atIndex + 1);
        }

        private static bool IsValidEmail(string value)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return addr.Address == value;
            }
            catch
            {
                return false;
            }
        }
    }
}
