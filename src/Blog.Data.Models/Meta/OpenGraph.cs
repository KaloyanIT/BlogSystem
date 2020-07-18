
namespace Blog.Data.Models.Meta
{
    using System;
    using Base;

    public class OpenGraph : BaseDbObject
    {
        private string _title = null!;
        private string _description = null!;
        private string _type = null!;
        private string _url = null!;
        private string? _imageUrl;
        private Guid _attachedItemId;

        public Guid AttachedItemId
        {
            get
            {
                return _attachedItemId;
            }
            set
            {
                _attachedItemId = value;
            }
        }


        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                ValidateTitle(value);

                _title = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                ValidateDescription(value);

                _description = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            private set
            {
                ValidateType(value);

                _type = value;
            }
        }

        public string Url
        {
            get
            {
                return _url;
            }
            private set
            {
                ValidateUrl(value);

                _url = value;
            }
        }

        public string? ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            private set
            {
                _imageUrl = value;
            }
        }

        public OpenGraph(Guid attachedItemId, string title, string description, string type, string url, string? imageUrl = null)
        {
            AttachedItemId = attachedItemId;
            Title = title;
            Description = description;
            Type = type;
            Url = url;

            ImageUrl = imageUrl;
        }

        private void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title can not be null!");
            }
        }

        private void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description), "Description can not be null!");
            }
        }

        private void ValidateType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(nameof(type), "Title can not be null!");
            }
        }

        private void ValidateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url), "Title can not be null!");
            }
        }
    }
}
