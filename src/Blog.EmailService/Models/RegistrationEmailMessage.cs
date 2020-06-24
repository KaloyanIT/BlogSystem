namespace Blog.EmailService.Models
{
    using System.Collections.Generic;

    public class RegistrationEmailMessage : BaseEmailMessage
    {
        private readonly string _confirmationLink;

        public RegistrationEmailMessage(IEnumerable<string> to,
            string subject,
            string content,
            string confirmationLink) : base(to, subject, content)
        {
            _confirmationLink = confirmationLink;

            this.Content += confirmationLink;
        }
    }
}