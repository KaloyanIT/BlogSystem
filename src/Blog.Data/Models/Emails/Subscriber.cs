﻿namespace Blog.Data.Models.Emails
{
    using System.Collections.Generic;
    using Blog.Data.Base;

    public class Subscriber : BaseDbObject
    {
        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public ICollection<MailListSubscirber> MailListSubscriber { get; set; }

        public Subscriber(string email, string firstName, string lastName)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
