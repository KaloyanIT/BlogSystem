namespace Blog.Data.Models.Emails
{
    using System;
    using System.Collections.Generic;
    using Base;

    public class MailList : BaseDbObject
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public ICollection<MailListSubscriber> MailListSubscribers { get; private set; }

        public MailList(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Mail List name can not be null or empty string.");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description", "Mail List description can not be null or empty string.");
            }

            Name = name;
            Description = description;

            MailListSubscribers = new List<MailListSubscriber>();
        }

        public void Edit(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Delete()
        {
            MailListSubscribers = null!;
        }
    }
}
