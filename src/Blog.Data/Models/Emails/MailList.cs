﻿namespace Blog.Data.Models.Emails
{
    using System.Collections.Generic;
    using Blog.Data.Base;

    public class MailList : BaseDbObject
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public ICollection<MailListSubscirber> MailListSubscribers { get; private set; }

        public MailList(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
