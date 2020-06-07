namespace Blog.Data.Models
{
    using System;
    using Base;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IHaveDateCreated, IHaveDateModified
    {
        [PersonalData]

        public string? FirstName { get; set; }

        [PersonalData]

        public string? LastName { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime DateCreated { get; set; }       
    }
}
