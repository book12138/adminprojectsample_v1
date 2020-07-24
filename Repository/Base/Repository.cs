using Domain.Base;
using Domain.EF;
using Domain.UnitOfWork;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Base
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T">聚合根</typeparam>
    public class Repository<T> where T : AggregateRoot , IEntity
    {
        /// <summary>
        /// EF 上下文
        /// </summary>
        public BAMDbContext Db { get; set; }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public virtual void Add(T model) => Db.Set<T>().Add(model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        public virtual void Edit(T model) => Db.Entry<T>(model).State = EntityState.Modified;
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereExpression">记录筛选表达式</param>
        public virtual void Remove(Expression<Func<T, bool>> whereExpression)
        {
            var models = this.Db.Set<T>().Where(whereExpression);
            foreach (var model in models)
            {              
                model.IsDeleted = true;
                this.Db.Entry<T>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        /// <summary>
        /// 分页获取数据（默认排序只针对一个字段，多字段的实现，请自己重写这个方法）
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="total">总记录数</param>
        /// <param name="limit">限制的每页显示数量</param>
        /// <param name="page">页码</param>
        /// <param name="isAscOrder">排序是否使用正序</param>
        /// <param name="orderExpression">排序表达式</param>
        /// <param name="isDeleted">是否不排除已删除的记录</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetPageData<TKey>(out int total,int limit, int page, bool isAscOrder, Expression<Func<T,TKey>> orderExpression, bool isDeleted = false)
        {
            total = Db.Set<T>().Where(u => !u.IsDeleted).Select(u => u.IsDeleted).Count(); //查询总记录数

            /* 获取分页数据 */
            if (isAscOrder)
                return Db.Set<T>().Where(u => !u.IsDeleted).OrderBy(orderExpression).Skip((page - 1) * limit).Take(limit);
            else
                return Db.Set<T>().Where(u => !u.IsDeleted).OrderByDescending(orderExpression).Skip((page - 1) * limit).Take(limit);
        }
        /// <summary>
        /// 分页获取数据（默认排序只针对一个字段，多字段的实现，请自己重写这个方法）
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="limit">限制的每页显示数量</param>
        /// <param name="page">页码</param>
        /// <param name="isAscOrder">排序是否使用正序</param>
        /// <param name="orderExpression">排序表达式</param>
        /// <param name="isDeleted">是否不排除已删除的记录</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetPageData<TKey>(int limit, int page, bool isAscOrder, Expression<Func<T, TKey>> orderExpression, bool isDeleted = false)
        {
            /* 获取分页数据 */
            if (isAscOrder)
                return Db.Set<T>().Where(u => !u.IsDeleted).OrderBy(orderExpression).Skip((page - 1) * limit).Take(limit);
            else
                return Db.Set<T>().Where(u => !u.IsDeleted).OrderByDescending(orderExpression).Skip((page - 1) * limit).Take(limit);
        }
    }
}
