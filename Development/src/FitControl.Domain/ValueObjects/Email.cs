using System.Net.Mail;

namespace FitControl.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; private set; }

        private Email() { }

        private Email(string value) { Value = value; }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email is required.", nameof(value));

            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format.", nameof(value));
            return new Email(value);
        }

        public static bool IsValidEmail(string value)
        {
            try
            {
                var addr = new MailAddress(value);
                return addr.Address == value;
            }
            catch
            {
                return false;
            }
        }
    }
}
