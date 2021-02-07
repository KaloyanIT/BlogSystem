namespace Blog.Data.Repositories.ContactData
{
    using DataAccess.SqlServer;
    using Models.Context;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class ContactDataRepository : SqlServerEntityFrameworkCrudRepository<ContactData, BlogContext>, IContactDataRepository
    {
        public ContactDataRepository(BlogContext context) : base(context)
        {

        }

        protected override DbSet<ContactData> EntityDbSet => Context.ContactsData;
    }
}
