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
        
        public MailListSubscriber(Guid maliListId, Guid subscriberId)
        {
            SubscriberId = subscriberId;
            MailListId = MailListId;
        }

        //public MailListSubscriber(MailList mailList, Subscriber subscriber)
        //{
        //    Subscriber = subscriber;
        //    MailList = mailList;
        //}
    }
}
