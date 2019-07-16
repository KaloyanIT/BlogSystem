using System;
using Blog.Data.Models;
using Blog.Services;

namespace Blog.UnitTests.Services
{
    public class BlogPostServiceShould : IDisposable
    {
        private readonly BlogService systemUnderTest;
        private readonly InMemoryRepository<BlogPost> blogPostRepositoryInstance;
        //private readonly 

        public BlogPostServiceShould()
        {

        }

        public void Dispose()
        {
            
        }
    }
}
