using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emrys.EnumTools.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var des = Gender.Male.GetDescription();
            // des = “男性”

            var name = Gender.Male.ToString();
            // name= "Male"

            var key = (int)Gender.Male;
            // key = 2

            int order;
            var des1 = Gender.Female.GetDescription(out order);
            // des1 = “女性”, order= 2 

            return View(new Person { Age = 1, Name = "Emrys", Gender = Gender.Male });
        }

    }


    public class Person
    {
        public string Name { get; set; } 
        public int Age { get; set; } 
        public Gender Gender { get; set; } 
    }



    /// <summary>
    /// 性别
    /// </summary> 
    public enum Gender
    {
        /// <summary>
        /// 女性
        /// </summary>
        [Description("女性", 2)]
        Female = 1,

        /// <summary>
        /// 男性
        /// </summary>
        [Description("男性", 1)]
        Male = 2,

        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知", 3)]
        Unknown = 3,

        /// <summary>
        /// 人妖
        /// </summary>
        [Description("人妖", 4)]
        Demon = 4
    }
}