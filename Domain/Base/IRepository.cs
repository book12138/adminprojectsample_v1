using Domain.EF;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Base
{
    /// <summary>
    /// 仓储基接口
    /// </summary>
    public interface IRepository<T> where T : AggregateRoot
    {
        /// <summary>
        /// EF 上下文
        /// </summary>
        BAMDbContext Db { get; set; }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        void Add(T model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        void Edit(T model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereExpression">记录筛选表达式</param>
        void Remove(Expression<Func<T, bool>> whereExpression);
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
        IQueryable<T> GetPageData<TKey>(out int total, int limit, int page, bool isAscOrder, Expression<Func<T, TKey>> orderExpression, bool isDeleted = false);
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
        IQueryable<T> GetPageData<TKey>(int limit, int page, bool isAscOrder, Expression<Func<T, TKey>> orderExpression, bool isDeleted = false);
    }
}
