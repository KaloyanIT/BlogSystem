namespace Blog.ViewModels.BackEnd.ContactsData
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class ContactDataViewModel : IHaveMapFrom<ContactData>
    {
         public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Subject { get; set; } = null!;       
    }
}
