using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CapModel;

namespace CapV4.Controllers
{ 

    public class RecruitersController : Controller
    {
        Model1Container db = new Model1Container();

        // GET: Recruiters
        public ActionResult Index()
        {
            return View();
        }

        // GET: Recruiters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recruiters/Create
        public ActionResult Create()
        {
            ViewData["company"] = GetCompany();

            return View();
        }

        // POST: Recruiters/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="HasAccess,CompanyCompId,UserName")]  Recruiter recruiter, FormCollection form)
        { if (ModelState.IsValid)
            {
            string companyid = form["company"].ToString();
          
            //Company ccom = from c in db.Companies
                //    where c.CompName == companyid
                //    select c;
           
            
            recruiter.HasAccess = "Y";
            recruiter.CompanyCompId = 1 ;
                db.Recruiters.Add(recruiter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruiter);
        }

        // GET: Recruiters/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Recruiters/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recruiters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recruiters/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public SelectList GetCompany()
        {
            var company = from Company in db.Companies
                          group Company by Company.CompName into unique
                          select unique.FirstOrDefault();
            return new SelectList(company, "CompName", "CompName", "CompId");

        }
    
}
}

