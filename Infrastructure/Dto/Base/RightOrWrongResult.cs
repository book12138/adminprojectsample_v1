using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.Base
{
    public class RightOrWrongResult
    {
        /// <summary>
        /// 最终的结果得到的是正确的
        /// </summary>
        public bool IsTrue { get; set; } = false;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; } = "";
    }
}
