using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Contracts
{
    public interface ICommentService
    {
        Task AddComment();

        Task<bool> DeleteComment();

        Task Edit();
    }
}
