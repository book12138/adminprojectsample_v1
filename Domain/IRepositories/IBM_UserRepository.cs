using Domain.Base;
using Domain.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    /// <summary>
    /// 后台管理——用户信息仓储
    /// </summary>
    public interface IBM_UserRepository : IRepository<BM_User>
    {
        /// <summary>
        /// 检查用户名密码组合是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回用户记录</returns>
        BM_User UsernamePasswordCombinationExists(string username,string password);

        /// <summary>
        /// 检查该用户名是否已经有过
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        bool UserNameExists(string name);

        /// <summary>
        /// 添加后台管理用户
        /// </summary>
        /// <param name="model">新用户</param>
        /// <returns></returns>
        void AddUser(BM_User model);
    }
}
