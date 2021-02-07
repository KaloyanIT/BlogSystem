namespace Blog.Data.Models
{
    using System;
    using Base;

    public class ContactData : BaseDbObject
    {
        public string Name { get; private set; } = null!;

        public string Subject { get; private set; } = null!;

        public string Email { get; private set; } = null!;

        public string Message { get; set; } = null!;

        public ContactData(string name, string subject, string email, string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name should not be null or empty!");
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject), "Subject should not be null or empty!");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email), "Email should not be null or empty!");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Message should not be null or empty!");
            }

            Name = name;
            Subject = subject;
            Email = email;
            Message = message;
        }
    }
}
