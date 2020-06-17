namespace Blog.Data.Models.Emails
{
    using System.Collections.Generic;
    using Base;

    public class Subscriber : BaseDbObject
    {
        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public ICollection<MailListSubscriber> MailListSubscriber { get; private set; }

        public Subscriber(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;

            MailListSubscriber = new List<MailListSubscriber>();
        }
    }
}
