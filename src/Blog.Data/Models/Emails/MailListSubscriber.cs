namespace Blog.Data.Models.Emails
{
    using System;
    using Blog.Data.Base;

    public class MailListSubscriber : BaseDbObject
    {
        public Guid SubscriberId { get; set; }

        public Subscriber Subscriber { get; set; }

        public Guid MailListId { get; set; }

        public MailList MailList { get; set; }
    }
}
