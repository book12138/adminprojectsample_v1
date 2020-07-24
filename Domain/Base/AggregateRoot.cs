using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    /// <summary>
    /// 抽象聚合根
    /// </summary>
    public abstract class AggregateRoot : IEntity
    {
        /// <summary>
        /// true : 已删除  false ：未删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
