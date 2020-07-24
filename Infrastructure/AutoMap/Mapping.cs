using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Infrastructure.AutoMap
{
    public static class Mapping
    {
        /// <summary>
        /// 映射
        /// </summary>
        /// <typeparam name="TSource">源数据类型</typeparam>
        /// <typeparam name="TResult">映射结果数据类型</typeparam>
        /// <param name="target">待转换数据</param>
        /// <returns></returns>
        public static TResult MappingTo<TResult>(this object target) where TResult : new()
        {
            TResult result = new TResult();
            var type = typeof(TResult);
            var sourceType = target.GetType();
            foreach (var item in sourceType.GetProperties())
            {
                var temp = type.GetProperty(item.Name);
                if (temp == null)
                    if (item.IsDefined(typeof(MappingAttribute.AtMappingNameAttribute), false))
                    {
                        var attr = item.GetCustomAttribute<MappingAttribute.AtMappingNameAttribute>();
                        if (attr != null)
                        {
                            var resultProperty = type.GetProperty(attr.Name);
                            if (resultProperty != null)
                                resultProperty.SetValue(result, item.GetValue(target));
                        }
                    }
                    else;
                else temp.SetValue(result, item.GetValue(target));
            }

            return result;
        }

        /// <summary>
        /// 映射
        /// </summary>
        /// <typeparam name="TSource">源数据类型</typeparam>
        /// <typeparam name="TResult">映射结果数据类型</typeparam>
        /// <param name="target">待转换数据</param>
        /// <returns></returns>
        public static IEnumerable<TResult> MappingTo<TResult>(this List<object> target) where TResult : new() 
            => target.Select(u => u.MappingTo<TResult>());

        /// <summary>
        /// 映射
        /// </summary>
        /// <typeparam name="TSource">源数据类型</typeparam>
        /// <typeparam name="TResult">映射结果数据类型</typeparam>
        /// <param name="target">待转换数据</param>
        /// <returns></returns>
        public static IEnumerable<TResult> MappingTo<TSource, TResult>(this IEnumerable<object> target) where TResult : new() 
            => target.Select(u => u.MappingTo<TResult>());

        /// <summary>
        /// 映射
        /// </summary>
        /// <typeparam name="TSource">源数据类型</typeparam>
        /// <typeparam name="TResult">映射结果数据类型</typeparam>
        /// <param name="target">待转换数据</param>
        /// <returns></returns>
        public static IEnumerable<TResult> MappingTo<TResult>(this IQueryable<object> target) where TResult : new()
            => target.Select(u => u.MappingTo<TResult>());
    }
}
