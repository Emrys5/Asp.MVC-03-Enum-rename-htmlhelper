using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Emrys.EnumTools
{

    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumTools
    {

        /// <summary>
        /// 获取当前枚举值的描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            int order;
            return GetDescription(value, out order);
        }

        /// <summary>
        /// 获取当前枚举值的描述和排序
        /// </summary>
        /// <param name="value"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value, out int order)
        {
            string description = string.Empty;

            Type type = value.GetType();

            // 获取枚举
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // 获取枚举自定义的特性DescriptionAttribute
            object[] attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            DescriptionAttribute attr = (DescriptionAttribute)attrs.FirstOrDefault(a => a is DescriptionAttribute);

            order = 0;
            description = fieldInfo.Name;

            if (attr != null)
            {
                order = attr.Order;
                description = attr.Name;
            }
            return description;

        }

        /// <summary>
        /// 获取当前枚举的所有描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetAll<T>()
        {
            return GetAll(typeof(T));
        }

        /// <summary>
        /// 获取所有的枚举描述和值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetAll(Type type)
        {

            List<EnumToolsModel> list = new List<EnumToolsModel>();

            // 循环枚举获取所有的Fields
            foreach (var field in type.GetFields())
            {
                // 如果是枚举类型
                if (field.FieldType.IsEnum)
                {
                    object tmp = field.GetValue(null);
                    Enum enumValue = (Enum)tmp;
                    int intValue = Convert.ToInt32(enumValue);
                    int order;
                    string showName = enumValue.GetDescription(out order); // 获取描述和排序
                    list.Add(new EnumToolsModel { Key = intValue, Name = showName, Order = order });
                }
            }

            // 排序并转成KeyValue返回
            return list.OrderBy(i => i.Order).Select(i => new KeyValuePair<int, string>(i.Key, i.Name)).ToList();

        }


        /// <summary>
        /// 枚举下拉
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EnumToolsSelect<T>(this HtmlHelper html, object htmlAttributes = null)
        {
            return html.EnumToolsSelect(typeof(T), int.MaxValue, htmlAttributes);
        }


        /// <summary>
        /// 枚举下拉
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="html"></param>
        /// <param name="selectedValue">选择项</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EnumToolsSelect<T>(this HtmlHelper html, int selectedValue, object htmlAttributes = null)
        {
            return html.EnumToolsSelect(typeof(T), selectedValue, htmlAttributes);
        }

        /// <summary>
        /// 枚举下拉
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="html"></param>
        /// <param name="selectedValue">选择项</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EnumToolsSelect<T>(this HtmlHelper html, T selectedValue, object htmlAttributes = null)
        {
            return html.EnumToolsSelect(typeof(T), Convert.ToInt32(selectedValue), htmlAttributes);
        }



        /// <summary>
        /// 枚举下拉
        /// </summary>
        /// <param name="html"></param>
        /// <param name="enumType">枚举类型</param>
        /// <param name="selectedValue">选择项</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EnumToolsSelect(this HtmlHelper html, Type enumType, int selectedValue, object htmlAttributes = null)
        {
            // 创建标签
            TagBuilder tag = new TagBuilder("select");

            // 添加自定义标签
            if (htmlAttributes != null)
            {
                RouteValueDictionary htmlAttr = htmlAttributes as RouteValueDictionary ?? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tag.MergeAttributes(htmlAttr);
            }
            // 创建option集合
            StringBuilder options = new StringBuilder();
            foreach (var item in GetAll(enumType))
            {
                // 创建option
                TagBuilder option = new TagBuilder("option");

                // 添加值
                option.MergeAttribute("value", item.Key.ToString());

                // 设置选择项
                if (item.Key == selectedValue)
                {
                    option.MergeAttribute("selected", "selected");
                }

                // 设置option
                option.SetInnerText(item.Value);
                options.Append(option.ToString());
            }
            tag.InnerHtml = options.ToString();

            // 返回MVCHtmlString
            return MvcHtmlString.Create(tag.ToString());

        }
        /// <summary>
        /// 下拉枚举
        /// </summary>
        /// <typeparam name="TModel">Model</typeparam>
        /// <typeparam name="TProperty">属性</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EnumToolsSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            // 获取元数据meta
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            Type enumType = modelMetadata.ModelType;

            // 设置id name的属性值
            var rvd = new RouteValueDictionary
            {
                { "id", modelMetadata.PropertyName },
                { "name", modelMetadata.PropertyName }
            };

            // 添加自定义属性
            if (htmlAttributes != null)
            {
                RouteValueDictionary htmlAttr = htmlAttributes as RouteValueDictionary ?? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in htmlAttr)
                {
                    rvd.Add(item.Key, item.Value);
                }
            }

            // 获取验证信息
            IDictionary<string, object> validationAttributes = htmlHelper.GetUnobtrusiveValidationAttributes(modelMetadata.PropertyName, modelMetadata);

            // 添加至自定义属性
            if (validationAttributes != null)
            {
                foreach (var item in validationAttributes)
                {
                    rvd.Add(item.Key, item.Value);
                }
            }
            return htmlHelper.EnumToolsSelect(enumType, Convert.ToInt32(modelMetadata.Model), rvd);
        }
    }

    /// <summary>
    /// 枚举特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 显示自定义描述名称
        /// </summary>
        /// <param name="name">名称</param>
        public DescriptionAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 显示自定义名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="order">排序</param>
        public DescriptionAttribute(string name, int order)
        {
            Name = name;
            Order = order;
        }

    }


    /// <summary>
    /// 枚举Model
    /// </summary> 
    partial class EnumToolsModel
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public int Key { get; set; }
    }
}
