namespace Blog.Data.Models
{
    using System;
    using Base.Contracts;
    using Microsoft.AspNetCore.Identity;

    public class Role : IdentityRole, IHaveDateCreated, IHaveDateModified, IHaveCreatedBy, IHaveModifiedBy
    {
        public string Description { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? ModifiedBy { get; set; }


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
