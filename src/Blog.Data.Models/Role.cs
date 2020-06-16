namespace Blog.Data.Models
{
    using System;
    using Blog.Data.Base;
    using Microsoft.AspNetCore.Identity;

    public class Role : IdentityRole, IHaveDateCreated, IHaveDateModified
    {
        public string Description { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public Role()
        {
            this.DateCreated = DateTime.UtcNow;
        }

        public Role(string name, string description) : this()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name can not be null or empty!");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw  new ArgumentNullException(nameof(description), "Description can not be null or empty!");
            }

            this.Name = name;
            this.Description = description;
        }
    }
}
