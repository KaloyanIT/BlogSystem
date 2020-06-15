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
    }
}
