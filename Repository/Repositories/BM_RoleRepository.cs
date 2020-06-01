using Domain.Base;
using Domain.Entities;
using Domain.IRepositories;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BM_RoleRepository : Base.Repository<BM_Role> , IBM_RoleRepository
    {
        /// <summary>
        /// 依赖注入工作单元实例
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BM_RoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    }
}
