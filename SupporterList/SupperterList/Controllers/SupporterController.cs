using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupperterList.DTOs;
using SupperterList.EF;

namespace SupperterList.Controllers
{
    public class SupporterController : Controller
    {
        FCclubEntities db = new FCclubEntities();
        // GET: Supporter
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.SupporterManagements.ToList();
            return View(convert(data));
        }
        [HttpPost]
        public ActionResult insert(SupporterManagementDTO s)
        {
            db.SupporterManagements.Add(convert(s));
            if(db.SaveChanges()>0)
            {
                TempData["msg"] = "Submission Sucsessfull";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Submission Unsucsessfull";
            return View(s);
            
        }
        [HttpGet]
        public ActionResult insert()
        {
            return View();
        }
        [HttpGet]
        public ActionResult edit(int Id)
        {
            var data = db.SupporterManagements.Find(Id);
            return View(convert(data));
        }
        
        [HttpPost]
        public ActionResult edit(SupporterManagementDTO S)
        {
            var data = db.SupporterManagements.Find(S.Id);
            var s = convert(S);
            data.Name= s.Name;
            data.Age = s.Age;
            data.Nation = s.Nation;
            if(db.SaveChanges()>0)
            {
                TempData["msg"] = "Update Successfull";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Update UnSuccessfull";
            return View(S);
        }
        [HttpGet]
        public ActionResult delete(int Id)
        {
            var data = db.SupporterManagements.Find(Id);
            if(data!=null)
            {
                db.SupporterManagements.Remove(data);
                if (db.SaveChanges() > 0)
                {
                    TempData["msg"]= "Delete Successfull";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = "Delete Successfull";
                    return RedirectToAction("Index");
                }
                    
                
            }

            else
            {
                TempData["msg"] = "Delete UnSuccessfull";
                return RedirectToAction("Index");
            }
        }

        public static SupporterManagementDTO convert(SupporterManagement s)
        {
            var NAME = s.Name.Split(' ');
            return new SupporterManagementDTO
            {
                Id = s.Id,
                FName = NAME[0],
                LName = NAME[1],
                Club = s.Club,
                Nation = s.Nation,
                Age = s.Age
            };
        }
        public static SupporterManagement convert (SupporterManagementDTO s)
        {
            return new SupporterManagement
            {
                Id = s.Id,
                Name = s.FName + " " + s.LName,
                Club = s.Club,
                Nation = s.Nation,
                Age = s.Age
            };
        }
        public static List<SupporterManagementDTO> convert(List<SupporterManagement> s)
        {
           var data = new List<SupporterManagementDTO>();
            foreach (var item in s)
            {
                data.Add(convert(item));
            }
            return data;
        }
        }
}