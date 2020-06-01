﻿using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    /// <summary>
    /// 仓储基接口
    /// </summary>
    public interface IRepository<T> where T : AggregateRoot
    {
    }
}
