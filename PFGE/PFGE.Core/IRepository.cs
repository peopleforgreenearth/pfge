using System;
using System.Collections.Generic;
using System.Text;

namespace PFGE.Core
{

    public partial interface IRepository<T> where T : class
    {
        /// <summary>
        /// get all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// get record by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// get data from store procedure
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //IEnumerable<T> GetWithQuery(string query, SqlParameter[] parameters);

        /// <summary>
        /// insert entity/data
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// update data
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
