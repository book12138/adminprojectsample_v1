using Domain.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitOfWork
{
    /// <summary>
    /// 工作单元模式
    /// </summary>
    /// <typeparam name="T">返回类型</typeparam>
    public interface IUnitOfWork
    {
        /// <summary>
        /// EF上下文
        /// </summary>
        //BAMDbContext Db { get; set; }

        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        Task<T> UsingScopeTransactionAsync<T>(Func<BAMDbContext, T> operation, Action<Exception> handlerExceptionCustom = null);
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        Task UsingScopeTransactionAsync(Action<BAMDbContext> operation, Action<Exception> handlerExceptionCustom = null);
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        T UsingScopeTransaction<T>(Func<BAMDbContext, T> operation, Action<Exception> handlerExceptionCustom = null);
        /// <summary>
        /// 启用一个局部范围的事务
        /// （内置异常捕获和事务提交与回滚）
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="handlerExceptionCustom">自定义错误处理程序（默认直接throw出去）</param>
        /// <returns></returns>
        void UsingScopeTransaction(Action<BAMDbContext> operation, Action<Exception> handlerExceptionCustom = null);
    }
}
