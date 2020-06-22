using Domain.EF;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    /// <summary>
    /// 工作单元模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// EF 上下文
        /// </summary>
        protected readonly BAMDbContext _db;
        /// <summary>
        /// 构造注入 EF 上下文实例
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(BAMDbContext context)
            => this._db = context;
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        public T UsingScopeTransaction<T>(Func<BAMDbContext, T> operation, Action<Exception> handlerExceptionCustom = null)
        {
            T result = default(T);
            using(var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    result = operation.Invoke(this._db);
                    transaction.Commit();
                }
                catch(Exception e)
                {                    
                    transaction.Rollback();
                    (handlerExceptionCustom ?? (ex => { throw ex; })).Invoke(e);
                }
            }
            return result;
        }
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        public void UsingScopeTransaction(Action<BAMDbContext> operation, Action<Exception> handlerExceptionCustom = null)
        {
            using (var transaction = this._db.Database.BeginTransaction())
            {
                try
                {
                    operation.Invoke(this._db);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    (handlerExceptionCustom ?? (ex => { throw ex; })).Invoke(e);
                }
            }
        }
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        public async Task<T> UsingScopeTransactionAsync<T>(Func<BAMDbContext, T> operation, Action<Exception> handlerExceptionCustom = null)
            => await Task.Run(() => this.UsingScopeTransaction(operation,handlerExceptionCustom));
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        public async Task UsingScopeTransactionAsync(Action<BAMDbContext> operation, Action<Exception> handlerExceptionCustom = null)
            => await Task.Run(() => this.UsingScopeTransaction(operation, handlerExceptionCustom));
    }
}
