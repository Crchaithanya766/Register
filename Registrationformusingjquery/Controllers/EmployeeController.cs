using Registrationformusingjquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registrationformusingjquery.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
        public ActionResult Register()
        {
            return View(@"/Views/Employee/RegistrationForm.cshtml");
        }
        [HttpPost]
        public ActionResult Registration(EmployeeReg data)
        {
            using (var res = new EmployeeContext())
            {
                res.employeeRegs.Add(data);
                res.SaveChanges();
                return Json(data, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginpage(EmployeeReg model)
        {
            EmployeeContext db = new EmployeeContext();

            var data = from c in db.employeeRegs where c.Username ==  model.Username && c.Password == model.Password select c;
            if(data!=null)
            {
                Session["EmpId"] = model.EmpId;
                Session["Username"] = model.Username;
                Session["Password"] = model.Password;
            }
            if (data.Count() > 0)
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult LogOut()
        {
            if (Session["EmpId"] == null)
            {

            }
            Session.Abandon();
            return View();
        }
    }
}