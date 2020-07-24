using Application.Base;
using Application.IServices;
using Domain.EF;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.AutoMap;
using Infrastructure.Dto;
using Infrastructure.ValueMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class MenuService : BaseService, IMenuService
    {
        /// <summary>
        /// 菜单仓储
        /// </summary>
        private readonly IBM_MenuRepository _menuRepository;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="menuRepository"></param>
        public MenuService(BAMDbContext context, IBM_MenuRepository menuRepository)
            :base(context)
        {
            this._menuRepository = menuRepository;

            /* 配置工作单元 */
            this._menuRepository.Db = context;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId">用户id</param>
        /// <returns>是否添加成功</returns>
        public bool AddMenu(NewMenuRecordDto dto, long userId)
        => base.UsingScopeTransaction(u =>
        {
            this._menuRepository.Add(dto.MappingTo<BM_Menu>(), userId);
            return true;
        },exception => { return false; });
    }
}
