using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcPet.Common
{
    public static class LinqHelp
    {

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> ApartPage<TEntity>(this IQueryable<TEntity> dbSet, int index, int size) where TEntity : class
        {
            int strat = ((index - 1) * size);
            return dbSet.Skip(strat).Take(size);
        }

    }
}
