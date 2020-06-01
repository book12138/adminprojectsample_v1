using Domain.Entities;
using Domain.IRepositories;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BM_UserRepository : Base.Repository<BM_User> , IBM_UserRepository
    {
        /// <summary>
        /// 依赖注入工作单元实例
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BM_UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    }
}
