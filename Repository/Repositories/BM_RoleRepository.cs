using Domain.Base;
using Domain.Entities;
using Domain.IRepositories;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BM_RoleRepository : Base.SOR_Repository<BM_Role> , IBM_RoleRepository
    {
    }
}
