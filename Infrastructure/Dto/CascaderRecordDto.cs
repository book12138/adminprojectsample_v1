using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    /// <summary>
    /// 饿了么UI 级联选择器填充数据传输模型
    /// </summary>
    public class CascaderRecordDto
    {
        /// <summary>
        /// 包含的值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 用于显示的文字
        /// </summary>
        public string Lable { get; set; }
        /// <summary>
        /// 子级
        /// </summary>
        public List<CascaderRecordDto> Children { get; set; }
    }
}
