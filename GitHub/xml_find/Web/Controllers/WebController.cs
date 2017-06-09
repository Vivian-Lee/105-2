using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
namespace Web.Controllers
{
    public class WebController : Controller
    {
        // GET: Web
        public ActionResult IndexMessage()
        {
            var play_Data = new SQL.SQL_Set();
            var Data = play_Data.ReadPlay();
            var message = string.Format("收到{0}筆部落的資料<br/><br/>", Data.Count);

            Data.ForEach(x =>
            {
                message += string.Format("標題：{0} <br/>  民族: {1} <br/>  所在地：{2} <br/>  旅遊天數: {3} <br/>  每人費用：{4} <br/>  住宿地點: {5} <br/>  建立時間: {6} <br/> <br/>", x.title, x.people, x.adress, x.travel, x.money, x.stay, x.CreateTime);

            });
            return Content(message);
        }
        public ActionResult Index(string userName = "")
        {
            var play_Data = new SQL.SQL_Set();
            var Data = play_Data.ReadPlay();
            /*var message = string.Format("收到{0}筆部落的資料<br/><br/>", Data.Count);

            Data.ForEach(x =>
            {
                message += string.Format("標題：{0} <br/>  民族: {1} <br/>  所在地：{2} <br/>  旅遊天數: {3} <br/>  每人費用：{4} <br/>  住宿地點: {5} <br/>  建立時間: {6} <br/> <br/>", x.title, x.people, x.adress, x.travel, x.money, x.stay, x.CreateTime);

            });*/
            ViewBag.UserName = "DoDo";
            
            return View(Data);
        }
    }
}