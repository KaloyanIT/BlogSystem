namespace Blog.Data.Models
{
    using System;
    using Base.Contracts;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IHaveDateCreated, IHaveDateModified, IHaveCreatedBy, IHaveModifiedBy
    {
        [PersonalData]

        public string? FirstName { get; set; }

        [PersonalData]
        public string? LastName { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? ModifiedBy { get; set; }
    }
}
