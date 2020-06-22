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
    }
}
