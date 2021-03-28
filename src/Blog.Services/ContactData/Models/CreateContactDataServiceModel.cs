﻿namespace Blog.Services.ContactData.Models
{
    public class CreateContactDataServiceModel
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
