using AppNewsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace AppNewsApi.Repositories
{
    public class Repository<T> where T: class
    {
        public Sistem21NoticiasdbContext Context;
        public Repository(Sistem21NoticiasdbContext context)
        {
            this.Context = context;
        }
        public DbSet<T> Get()
        {
            return Context.Set<T>();
        }
        public T? GetById(object id)
        {
            return Context.Find<T>(id);
        }
        public void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }
    }
}
