namespace Blog.Data.Models.Emails
{
    using System;
    using System.Collections.Generic;
    using Base;

    public class MailList : BaseDbObject
    {
        private string _name = null!;
        private string _description = null!;

        public string Name
        {
            get => _name;
            
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Mail List name can not be null or empty string.");
                }

                _name = value;
            }
        }

        public string Description 
        { 
            get => _description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Mail List description can not be null or empty string.");
                }

                _description = value;
            }
        }

        public ICollection<MailListSubscriber> MailListSubscribers { get; private set; }

        public MailList(string name, string description)
        {
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
