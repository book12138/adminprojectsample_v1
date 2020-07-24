using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    /// <summary>
    /// 关于后台菜单的 应用服务
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId">用户id</param>
        /// <returns>是否添加成功</returns>
        bool AddMenu(NewMenuRecordDto dto, long userId);
    }
}
