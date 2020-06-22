using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.Base
{
    public class BaseResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; } = false;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; } = "";        
    }
}
