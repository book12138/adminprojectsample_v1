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
using System.Linq;
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
            return u.SaveChanges() == 1;
        },exception => { return false; });

        /// <summary>
        /// 获取 饿了么UI 级联选择器填充用的数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CascaderRecordDto> GetCascaderData()
        {
            var menuData = this._menuRepository.Find().ToList();
            List<CascaderRecordDto> cascaderRecordDtos = new List<CascaderRecordDto>();
            Action<CascaderRecordDto, long> findChildren = null;
            findChildren = (parentObj, parentId) =>
            {
                var data = menuData.Where(u => u.ParentId == parentId).ToList();
                if (data.Count() != 0)  //存在子级节点
                {
                    parentObj.Children = new List<CascaderRecordDto>();
                    foreach (var item in data)
                    {
                        CascaderRecordDto dto = new CascaderRecordDto();
                        dto.Lable = item.Name;
                        dto.Value = item.Id.ToString();
                        findChildren(dto, item.Id);
                        parentObj.Children.Add(dto);
                    }
                }
            };

            foreach (var item in menuData.Where(u => u.ParentId == 0)) /* 从一级节点开始找起 */
            { 
                CascaderRecordDto dto = new CascaderRecordDto();
                dto.Lable = item.Name;
                dto.Value = item.Id.ToString();
                findChildren(dto, item.Id);

                cascaderRecordDtos.Add(dto);
            }

            return cascaderRecordDtos;
        }
    }
}
