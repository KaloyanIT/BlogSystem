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
            toValue.To.AddRange(fromValue.To);
            toValue.Subject = fromValue.Subject;
            toValue.Body = new TextPart(TextFormat.Text)
            {
                Text = fromValue.Content
            };
        }
    }
}
