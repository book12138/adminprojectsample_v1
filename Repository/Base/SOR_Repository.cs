using Domain.Base;
using Domain.EF;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Base
{
    public class SOR_Repository<T> where T : class, IStrongOperationRecording
    {
        /// <summary>
        /// EF 上下文
        /// </summary>
        public BAMDbContext Db { get; set; }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="coverHasDeletedRecord">是否涵盖已删除记录，默认不涵盖</param>
        /// <returns></returns>
        public virtual IQueryable<T> Find(bool coverHasDeletedRecord = false)
        {
            if (coverHasDeletedRecord)
                return this.Db.Set<T>();
            else
                return this.Db.Set<T>().Where(u => !u.IsDeleted);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereExpression">数据筛选表达式</param>
        /// <returns></returns>
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> whereExpression)
            => this.Db.Set<T>().Where(whereExpression);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <param name="creator">添加记录者</param>
        public virtual void Add(T model, long creator)
        {
            model.Creator = creator;
            this.Db.Set<T>().Add(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mender">修改记录者</param>
        public virtual void Edit(T model, long mender)
        {
            model.Mender = mender;
            this.Db.Entry<T>(model).Property(u => u.CreateTime).IsModified = false;
            this.Db.Entry<T>(model).Property(u => u.Creator).IsModified = false;
            this.Db.Entry<T>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereExpression">记录筛选表达式</param>
        /// <param name="mender">删除记录者</param>
        public virtual void Remove(Expression<Func<T, bool>> whereExpression, long mender)
        {
            var models = this.Db.Set<T>().Where(whereExpression);
            foreach (var model in models)
            {
                model.Mender = mender;
                model.UpdateTime = DateTime.Now;
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
        public virtual IQueryable<T> GetPageData<TKey>(out int total, int limit, int page, bool isAscOrder, Expression<Func<T, TKey>> orderExpression, bool isDeleted = false)
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
