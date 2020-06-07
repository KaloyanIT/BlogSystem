namespace Blog.Data.Models.Emails
{
    using System.Collections.Generic;
    using Blog.Data.Base;

    public class Subscriber : BaseDbObject
    {
        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public ICollection<MailListSubscriber> MailListSubscriber { get; private set; }

        public Subscriber(string email, string firstName, string lastName)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;

            MailListSubscriber = new List<MailListSubscriber>();
        }
    }
}
