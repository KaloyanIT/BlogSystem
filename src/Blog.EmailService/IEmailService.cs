﻿namespace Blog.EmailService
{
    using System.Threading.Tasks;
    using Models;
    using Services.Base;

    public interface IEmailService : IService
    {
        void SendEmail<T>(T message) where T : BaseEmailMessage;

        Task SendEmailAsync<T>(T message) where T : BaseEmailMessage;
    }
}
