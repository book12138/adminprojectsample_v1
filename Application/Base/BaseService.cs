using Domain.EF;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Base
{
    public class BaseService : UnitOfWork
    {
        /// <summary>
        /// 构造注入EF上下文实例
        /// </summary>
        /// <param name="context"></param>
        public BaseService(BAMDbContext context)
            : base(context)
        { }
    }
}
