using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IServices;
using Infrastructure.Dto;
using Infrastructure.Dto.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Jwt;

namespace WebApp.Controllers
{
    /// <summary>
    /// 后台权限操作
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        /// <summary>
        /// 后台管理 菜单应用服务
        /// </summary>
        private readonly IMenuService _menuService;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="menuService"></param>
        public PermissionController(IMenuService menuService)
        {
            this._menuService = menuService;
        }

        /// <summary>
        /// 添加新菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddMenu")]
        public RightOrWrongResult AddMenu([FromBody] NewMenuRecordDto dto)
        {
            var tokenModel = HttpContext.GetTokenModel();
            if (tokenModel == null)
                return new RightOrWrongResult() { IsTrue = false, Message = "您还未登录" };
            return new RightOrWrongResult() { IsTrue = this._menuService.AddMenu(dto, tokenModel.Uid) };
        }

        /// <summary>
        /// 获取 饿了么UI 级联选择器填充用的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCascaderData")]
        public IEnumerable<CascaderRecordDto> GetCascaderData()
            => this._menuService.GetCascaderData();
    }
}
