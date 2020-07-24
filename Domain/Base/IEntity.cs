using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    /// <summary>
    /// 实体基接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// true : 已删除  false ：未删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
