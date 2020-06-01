using Domain.Base;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Base
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T">聚合根</typeparam>
    public class Repository<T> : Repository.UnitOfWork.UnitOfWork where T : AggregateRoot
    {
        /// <summary>
        /// 工作单元实例
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// 依赖注入工作单元实例
        /// </summary>
        /// <param name="unitOfWork"></param>
        public Repository(IUnitOfWork unitOfWork)
            => this._unitOfWork = unitOfWork;
    }
}
