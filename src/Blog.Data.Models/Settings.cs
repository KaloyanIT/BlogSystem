namespace Blog.Data.Models
{
    using System;
    using Blog.Data.Base;

    public class Settings : BaseDbObject
    {
        public string Name { get; private set; }

        public string Content { get; private set; }

        public Settings()
        {
            Name = string.Empty;
            Content = string.Empty;
        }

        public Settings(string name, string content)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "Settings name can not be null!");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("content", "Settings content can not be null!");
            }

            this.Name = name;
            this.Content = content;
        }
    }
}
