namespace Blog.Data.Models.Links
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Base;
    using Blog.Data.Models.Files;

    public class Link : BaseDbObject
    {
        private string _url;
        private LinkType _linkType;

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

        public LinkType LinkType
        {
            get
            {
                return _linkType;
            }
            private set
            {
                _linkType = value;
            }
        }

        public ICollection<File> Files {get; set;}

        public Link(string url, LinkType linkType)
        {
            Url = url;
            LinkType = linkType;
        }

        private void ValidateUrl(string url)
        {
            if(string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url", "Url can not be null or whitespace!");
            }
        }
    }
}
