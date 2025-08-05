using MvcTemplate.Dtos;
using MvcTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Areas.UserArea.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService userService = new UserService();
        // GET: UserArea/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUsers(int? id)
        {
            if (id != null)
            {
                var usersdto = userService.GetbyID(id.Value);
                return View(usersdto);
            }
            return View(new UsersDto());
        }



        [HttpPost]

        public ActionResult SaveUsers(UsersDto usersDto)
        {
            if (usersDto.Id > 0)
            {
                userService.Update(usersDto);
            }
            else
            {

                userService.Add(usersDto);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

   
        public ActionResult Remove(UsersDto usersdto)
        {
            userService.Remove(usersdto);
            return RedirectToAction("GetUserslist");
        }

        public ActionResult GetUserslist()
        {
            var list = userService.GetAll();
            return View(list);
        }

        //partial view code start here

        public ActionResult CreateUsersAjax()
        {
            return View();
        }

        public ActionResult CreateusersPartial(int? id)
        {
            if (id != null)
            {
                var usersdto = userService.GetbyID(id.Value);
                return PartialView("_CreateUserPartial",usersdto);
            }
            return PartialView("_CreateUserPartial", new UsersDto());
        }


        public ActionResult GetUsersListPartial()
        {
            var list = userService.GetAll();
            return PartialView("_GetUsersListPartial",list);
        }
    }
}
