using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Base
{
    /// <summary>
    /// 领域服务基类
    /// </summary>
    public class Service : Repository.UnitOfWork.UnitOfWork , IService
    {   

    }
}
