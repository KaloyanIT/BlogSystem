namespace Blog.EmailService.Adapters
{
    using Infrastructure.Adapter;
    using MimeKit;
    using MimeKit.Text;
    using Models;

    public class BaseEmailMessageAdapter : ISingleObjectAdapter<BaseEmailMessage, MimeMessage>
    {
        public void Adapt(BaseEmailMessage fromValue, MimeMessage toValue)
        {
            var emailMessage = new MimeMessage();
            emailMessage.To.AddRange(fromValue.To);
            emailMessage.Subject = fromValue.Subject;
            emailMessage.Body = new TextPart(TextFormat.Text)
            {
                Text = fromValue.Content
            };
        }
    }
}
