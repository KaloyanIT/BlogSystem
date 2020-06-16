using System;

namespace Blog.ViewModels.BackEnd.Base
{
    public class BaseGridViewModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
