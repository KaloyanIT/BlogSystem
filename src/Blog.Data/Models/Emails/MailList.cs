namespace Blog.Data.Models.Emails
{
    using System.Collections.Generic;
    using Blog.Data.Base;

    public class MailList : BaseDbObject
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public ICollection<MailListSubscriber> MailListSubscribers { get; private set; }

        public MailList(string name, string description)
        {
            Name = name;
            Description = description;

            MailListSubscribers = new List<MailListSubscriber>();
        }
    }
}
