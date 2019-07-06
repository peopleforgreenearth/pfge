using Microsoft.EntityFrameworkCore;
using PFGE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFGE.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            //set command timeout
            //this.context.Database.SetCommandTimeout(5 * 60);
            entities = context.Set<T>();
        }

        /// <summary>
        /// get all records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        /// <summary>
        /// get record by primary key 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            var x = entities;
            if (x == null)
            {
                throw new Exception("_entities was null");
            }

            return entities.Find(id);
        }

        /// <summary>
        /// get data from store procedure
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //public IEnumerable<T> GetWithQuery(string command, SqlParameter[] parameters)
        //{
        //    StringBuilder strBuilder = new StringBuilder();
        //    if (context.Database.IsMySql())
        //    {
        //        strBuilder.Append($"CALL {command}");
        //    }
        //    if (context.Database.IsSqlServer())
        //    {
        //        strBuilder.Append($"Execute {command}");
        //    }
        //    // strBuilder.Append(string.Join(",", parameters.ToList().Select(s => $" @{s.ParameterName}")));

        //    return context.Set<T>().FromSql(strBuilder.ToString());
        //}



        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                context.SaveChanges();
            }
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

    }
}
