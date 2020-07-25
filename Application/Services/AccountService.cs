using Application.Base;
using Application.IServices;
using Domain.EF;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.IRepositories;
using System.Threading.Tasks;
using Infrastructure.Dto;
using Infrastructure.Jwt;
using Infrastructure.Dto.Base;

namespace Application.Services
{
    /// <summary>
    /// 用户应用服务
    /// </summary>
    public class AccountService : BaseService , IAccountService
    {
        /// <summary>
        /// 后台管理用户仓储
        /// </summary>
        private readonly IBM_UserRepository _userRepository;
        /// <summary>
        /// 后台管理角色仓储
        /// </summary>
        private readonly IBM_RoleRepository _roleRepository;

        /// <summary>
        /// 构造注入实例
        /// </summary>
        /// <param name="context"></param>
        /// <param name=""></param>
        public AccountService(BAMDbContext context, IBM_UserRepository bM_UserRepository, IBM_RoleRepository bM_RoleRepository)
            : base(context)
        {
            this._userRepository = bM_UserRepository;
            this._roleRepository = bM_RoleRepository;

            /* 配置工作单元 */
            this._userRepository.Db = context;
            this._roleRepository.Db = context;
        }

        /// <summary>
        /// 持用户名密码组合登录，获取token
        /// </summary>
        /// <param name="dto">用户名密码组合</param>
        /// <returns></returns>
        public LoginResult Login(UsernamePasswordCombinationDto dto)
        {
            var accountRecord = this._userRepository.UsernamePasswordCombinationExists(dto.Name, dto.Password);
            string token = "";
            if (accountRecord != null)
                token = JwtHelper.IssueJwt(new TokenModelJwt { Uid = accountRecord.Id });
            return new LoginResult() { IsSuccess = accountRecord != null, Message = accountRecord == null ? "用户名或密码错误" : "" , Token = token };
        }

        /// <summary>
        /// 检查该用户名是否已经有过
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public RightOrWrongResult UserNameExists(string name)
            => new RightOrWrongResult { IsTrue = this._userRepository.UserNameExists(name) };

        /// <summary>
        /// 注册新账户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RegisterResult Register(AccountRegisterDto dto)
            => base.UsingScopeTransaction<RegisterResult>(u =>
            {
                var newUserModel = new Domain.Entities.BM_User
                {
                    Name = dto.Name.Trim(),
                    Password = dto.Password.Trim()
                };
                this._userRepository.AddUser(newUserModel);
                bool recordInsertResult = u.SaveChanges() == 1; //添加用户结果

                string token = "";
                if (recordInsertResult)
                    token = JwtHelper.IssueJwt(new TokenModelJwt { Uid = newUserModel.Id });
                return new RegisterResult() { IsSuccess = recordInsertResult, Message = !recordInsertResult ? "发生未知错误，注册失败" : "", Token = token };
            }, exception => throw exception);
    }
}
