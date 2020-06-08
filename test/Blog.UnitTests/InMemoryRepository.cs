using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Base;
using Blog.DataAccess;

namespace Blog.UnitTests
{
    public class InMemoryRepository<T> : IRepository<T> where T : IDbObject
    {
        private Guid currId = Guid.NewGuid();

        public InMemoryRepository()
        {
            this.Items = new List<T>();
        }

        public List<T> Items
        {
            get;
            set;
        }

        public IQueryable<T> GetAll()
        {
            return this.Items.AsQueryable();
        }

        public async Task<T> GetById(Guid id)
        {
            return await Task.Run(() =>
            {
                return (from temp in this.Items
                        where temp.Id == id
                        select temp).FirstOrDefault();
            });
        }

        public async Task Save(T saveThis)
        {
            await Task.Run(() =>
            {
                if (saveThis == null)
                {
                    throw new ArgumentNullException("saveThis", "Argument cannot be null.");
                }

                if (saveThis.Id == this.currId)
                {
                    // assign new identity value
                    saveThis.Id = this.GetNextIdValue();
                }

                if (this.Items.Contains(saveThis) == false)
                {
                    this.Items.Add(saveThis);
                }
            });
        }

        public async Task Delete(T deleteThis)
        {
            await Task.Run(() =>
            {
                if (deleteThis == null)
                {
                    throw new ArgumentNullException("deleteThis", "Argument cannot be null.");
                }

                if (this.Items.Contains(deleteThis) == true)
                {
                    this.Items.Remove(deleteThis);
                }
            });
        }

        protected Guid GetNextIdValue()
        {
            return Guid.NewGuid();
        }
    }
}
