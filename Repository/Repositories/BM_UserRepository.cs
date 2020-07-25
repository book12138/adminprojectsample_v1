using Domain.Entities;
using Domain.IRepositories;
using Domain.UnitOfWork;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Helper;
using System.Diagnostics.CodeAnalysis;

namespace Repository.Repositories
{
    public class BM_UserRepository : Base.Repository<BM_User>, IBM_UserRepository
    {
        /// <summary>
        /// 用户密码加密公共后缀
        /// 拼接到用户密码尾部，然后再md5
        /// </summary>
        private static readonly string _passwordEncryptSuffix = "f&{$eDyWceWw";

        /// <summary>
        /// 检查用户名密码组合是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回用户记录</returns>
        public BM_User UsernamePasswordCombinationExists(string username, string password)
            => base.Db.BM_User.FirstOrDefault(u => u.Name == username.Trim() && $"{password.Trim()}_{_passwordEncryptSuffix}".MD5Encrypt32() == u.Password && !u.IsDeleted);

        /// <summary>
        /// 检查该用户名是否已经有过
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public bool UserNameExists([NotNull] string name)
             => base.Db.BM_User.FirstOrDefault(u => u.Name == name.Trim() && !u.IsDeleted) != null;

        /// <summary>
        /// 添加新后台管理用户
        /// </summary>
        /// <param name="model">新用户</param>
        /// <returns></returns>
        public void AddUser([NotNull] BM_User model)
        {
            model.Password = $"{model.Password}_{_passwordEncryptSuffix}".MD5Encrypt32();
            base.Db.BM_User.Add(model);
        }
    }
}
