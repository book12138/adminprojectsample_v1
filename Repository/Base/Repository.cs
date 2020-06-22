using Domain.Base;
using Domain.EF;
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
    public class Repository<T> where T : AggregateRoot
    {
        /// <summary>
        /// EF 上下文
        /// </summary>
        public BAMDbContext Db { get; set; }
    }
}
