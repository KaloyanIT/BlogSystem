namespace Blog.Data.Models.Emails
{
    using System;
    using Base;

    public class MailListSubscriber : BaseDbObject
    {
        public Guid SubscriberId { get; private set; }

        public Subscriber? Subscriber { get; private set; }

        public Guid MailListId { get; private set; }

        public MailList? MailList { get; private set; }

        public MailListSubscriber()
        {

        }
        
        public MailListSubscriber(Guid mailListId, Guid subscriberId)
        {
            SubscriberId = subscriberId;
            MailListId = mailListId;
        }      
    }
}
