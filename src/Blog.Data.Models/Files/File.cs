namespace Blog.Data.Models.Files
{
    using System;
    using Base;
    using Links;

    public class File : BaseDbObject
    {
        private string _name;
        private string _description;

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

        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }

        public Guid LinkId { get; set; }

        public Link Link { get; set; }

        public Guid LibraryId { get; set; }

        public Library Library { get; set; }


        public File(string name, string description, Guid linkId, Guid libraryId)
        {
            Name = name;
            Description = description;
            LinkId = linkId;
            LibraryId = libraryId;
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
