namespace Blog.Data.Models.Files
{
    using System;
    using System.Collections.Generic;
    using Base;

    public class Library : BaseDbObject
    {
        private string _name;
        private StorageType _storageType;
        private string _urlPrefix;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                ValidateName(value);

                _name = value;
            }
        }


        public StorageType StorageType
        {
            get
            {
                return _storageType;
            }
            private set
            {
                _storageType = value;
            }
        }


        public string UrlPrefix
        {
            get
            {
                return _urlPrefix;
            }
            private set
            {
                ValidateUrlPrefix(value);

                _urlPrefix = value;
            }
        }

        public ICollection<File> Files { get; set; }

        public Library(string name, string urlPrefix, StorageType storageType)
        {
            Name = name;
            UrlPrefix = urlPrefix;
            StorageType = storageType;
        }

        private void ValidateUrlPrefix(string urlPrefix)
        {
            if (string.IsNullOrWhiteSpace(urlPrefix))
            {
                throw new ArgumentNullException(nameof(urlPrefix), "Url prefix can not be null or whitespace!");
            }

            if (urlPrefix.Length < 2)
            {
                throw new ArgumentException("Url Prefix should be longer than 2 Chars.", nameof(urlPrefix));
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name can not be null or whitespace!");
            }

            if (name.Length < 4)
            {
                throw new ArgumentException("Name should be longer than 4 Chars.", nameof(name));
            }
        }
    }
}
