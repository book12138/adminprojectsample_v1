using Domain.Entities;
using Domain.IRepositories;
using Domain.UnitOfWork;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BM_MenuRepository : Repository<BM_Menu> , IBM_MenuRepository
    {
        /// <summary>
        /// 依赖注入工作单元实例
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BM_MenuRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    }
}
