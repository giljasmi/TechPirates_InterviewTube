using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using CapModel;

using System.Data;
using System.Data.Entity;



namespace CapV4.Controllers
{
    public class JobPostingController : Controller
    {
        private Model1Container db = new Model1Container();
        // GET: JobPosting
        [HttpGet]
        public ActionResult Index()
        {
          
            ViewData["country"] = GetCountries();
            ViewData["province"] = GetProvince();
            ViewData["city"] = GetCities();
            ViewData["category"] = GetCategories();
            ViewData["subcategory"] = GetSubcategories();
            var jobPostings = db.JobPostings.Include(j => j.UserMedia).Include(j => j.Company);
            return View(jobPostings.ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //to puplate data in drop downs
            ViewData["country"] = GetCountries();
            ViewData["province"] = GetProvince();
            ViewData["city"] = GetCities();
            ViewData["category"] = GetCategories();
            ViewData["subcategory"] = GetSubcategories();

            //to get data submitted
            string textsearch = form["textserach"].ToString();
            string countrySearch = form["country"].ToString();
            string provinceSearch = form["province"].ToString();
            string citySearch = form["city"].ToString();
            string catSearch = form["category"].ToString();
            string subcatSearch = form["subcategory"].ToString();
            string levelSearch = form["joblevel"];
            string typeSearch = form["jobtype"];
           
            string salaryrange1 = form["salRange1"].ToString();
            string salaryrange4 = form["salRange4"].ToString();
            string salaryrange5 = form["salRange5"].ToString();
            string salaryrange6 = form["salRange6"].ToString();
            string salaryrange7 = form["salRange7"].ToString();
            string salaryrange8 = form["salRange8"].ToString();
            string salaryrange9 = form["salRange9"].ToString();
            string salaryrange10 = form["salRange10"].ToString();

            string companysearch = form["companySearch"].ToString();
            string titlesearch = form["titleSearch"].ToString();
            string postingdateSearch = form["postingdate"].ToString();
            //test data entered - only for testing purposes
            ViewData["result"] = levelSearch;
            float minSalary, maxSalary; //string jlevel = null;
          //  string jtype = null;
            //if no search criteria is specified show all jobs
            var jobPostings = db.JobPostings.Include(j => j.UserMedia).Include(j => j.Company);
            // if text search is entered 
            if (salaryrange1.Contains("true") && salaryrange4.Contains("true") && salaryrange6.Contains("true") && salaryrange7.Contains("true") && salaryrange8.Contains("true") && salaryrange9.Contains("true") && salaryrange10.Contains("true"))
            {
                  minSalary = 1; maxSalary = 599999;
            }
            else if (salaryrange1.Contains("true") && salaryrange4.Contains("true") && salaryrange6.Contains("true") && salaryrange7.Contains("true") && salaryrange8.Contains("true") && salaryrange9.Contains("true")) 
            {
                minSalary = 1; maxSalary = 99999;
            }
            else if (salaryrange1.Contains("true") && salaryrange4.Contains("true") && salaryrange6.Contains("true") && salaryrange7.Contains("true") && salaryrange8.Contains("true") )
            {
                  minSalary = 1; maxSalary = 89999;
             }
            else if (salaryrange1.Contains("true") && salaryrange4.Contains("true") && salaryrange6.Contains("true") && salaryrange7.Contains("true"))
            {
                minSalary = 1; maxSalary = 79999;
            }
            else if (salaryrange1.Contains("true") && salaryrange4.Contains("true") && salaryrange6.Contains("true"))
            {
                minSalary = 1; maxSalary = 69999;
            }
            else if (salaryrange1.Contains("true") && salaryrange4.Contains("true"))
            {
                minSalary = 1; maxSalary = 59999;
            }
            else if (salaryrange4.Contains("true") && salaryrange6.Contains("true") && salaryrange7.Contains("true") && salaryrange8.Contains("true") && salaryrange9.Contains("true") && salaryrange10.Contains("true"))
            {
                minSalary = 40000; maxSalary = 599999;
            }
            else if (salaryrange6.Contains("true") && salaryrange7.Contains("true") && salaryrange8.Contains("true") && salaryrange9.Contains("true") && salaryrange10.Contains("true"))
            {
                minSalary = 60000; maxSalary = 599999;
            }
            else if (salaryrange7.Contains("true") && salaryrange8.Contains("true") && salaryrange9.Contains("true") && salaryrange10.Contains("true"))
            {
                minSalary = 70000; maxSalary = 599999;
            }
            else if (salaryrange8.Contains("true") && salaryrange9.Contains("true") && salaryrange10.Contains("true"))
            {
                minSalary = 80000; maxSalary = 599999;
            }
            else if (salaryrange9.Contains("true") && salaryrange10.Contains("true"))
            {
                minSalary = 90000; maxSalary = 599999;
            }
            else if (salaryrange8.Contains("true") && salaryrange9.Contains("true"))
            {
                minSalary = 80000; maxSalary = 99999;
            }
            else if (salaryrange7.Contains("true") && salaryrange8.Contains("true"))
            {
                minSalary = 70000; maxSalary = 89999;
            }
            else if (salaryrange5.Contains("true") && salaryrange6.Contains("true"))
            {
                minSalary = 50000; maxSalary = 69999;
            }
            else if (salaryrange4.Contains("true") && salaryrange5.Contains("true"))
            {
                minSalary = 40000; maxSalary = 59999;
            }
            else if (salaryrange1.Contains("true"))
            {
                minSalary = 1; maxSalary = 39999;
            }
            else if (salaryrange4.Contains("true"))
            {
                minSalary = 40000; maxSalary = 49999;
            }
            else if (salaryrange5.Contains("true"))
            {
                minSalary = 50000; maxSalary = 59999;
            }
            else if (salaryrange6.Contains("true"))
            {
                minSalary = 60000; maxSalary = 69999;
            }
            else if (salaryrange7.Contains("true"))
            {
                minSalary = 70000; maxSalary = 79999;
            }
            else if (salaryrange8.Contains("true"))
            {
                minSalary = 80000; maxSalary = 89999;
            }
            else if (salaryrange9.Contains("true"))
            {
                minSalary = 90000; maxSalary = 99999;
            }
            else if (salaryrange10.Contains("true"))
            {
                minSalary = 100000; maxSalary = 599999;
            }
            else
            {
                minSalary = 1;
                maxSalary = 599999;
            } DateTime oldestDate = DateTime.UtcNow.Date.AddDays(-30);
            if (postingdateSearch == "1")
            {
                 oldestDate = DateTime.UtcNow.Date.AddDays(1);
            }
            else if (postingdateSearch == "2")
            {
               oldestDate = DateTime.UtcNow.Date.AddDays(-1);
            }
            else if (postingdateSearch == "3")
            {
                oldestDate = DateTime.UtcNow.Date.AddDays(-3);
            }
            else if (postingdateSearch == "7")
            {
               oldestDate = DateTime.UtcNow.Date.AddDays(-7);
            }
            else if (postingdateSearch == "14")
            {
               oldestDate = DateTime.UtcNow.Date.AddDays(-14);
            }
            else if (postingdateSearch == "30")
            {
                oldestDate = DateTime.UtcNow.Date.AddDays(-30);
            }
          //  ViewData["result"] = levelSearch;
            jobPostings = db.JobPostings.Include(j => j.UserMedia).Include(j => j.Company)
                        .Where(j => j.JobTitle.Contains(textsearch) &&
                                    j.Description.Contains(textsearch) &&
                                    j.Location.Country.Contains(countrySearch) &&
                                    j.Location.Province.Contains(provinceSearch) &&
                                    j.Location.City.Contains(citySearch) &&
                                    j.Company.CompName.Contains(companysearch) &&
                                    (j.JobCompensation >= minSalary &&
                                    j.JobCompensation <= maxSalary) &&
                                    j.JobCategory.Contains(catSearch) &&
                                    j.JobSubcategory.Contains(subcatSearch) &&
                                    j.JobTitle.Contains(titlesearch) &&
                                    (j.PostStartDate >= oldestDate)
                                    );    
             return View(jobPostings.ToList());

          
        }
        // GET: JobPostings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // GET: JobPostings/Create
        public ActionResult Create()
        {
            ViewData["company"] = GetCompany();
            ViewData["level"] = GetJobLevel();
            ViewData["type"] = GetJobType();
            ViewData["category"] = GetCategories();
            ViewData["subcategory"] = GetSubcategories();
            ViewData["country"] = GetCountries();
            ViewData["province"] = GetProvince();
            ViewData["city"] = GetCities();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            // to populate the drop down
            ViewData["company"] = GetCompany();
            ViewData["level"] = GetJobLevel();
            ViewData["type"] = GetJobType();
            ViewData["category"] = GetCategories();
            ViewData["subcategory"] = GetSubcategories();
            ViewData["country"] = GetCountries();
            ViewData["province"] = GetProvince();
            ViewData["city"] = GetCities();

            //to get data submmited in form
            string jobtitle = form["jobtitle"].ToString();
            string compname = form["company"].ToString();
            string positions = form["positions"];
            string joblevel = form["level"].ToString();
            string jobtype = form["type"].ToString();
            DateTime postingdate = Convert.ToDateTime(form["postingdate"]);
            DateTime closingdate = Convert.ToDateTime(form["closingdate"]);
            double jobSalary = Convert.ToDouble(form["jobCompensation"]);
            string category = form["category"].ToString();
            string subcategory = form["category"].ToString();
            string aptNum = form["aptNum"].ToString();
            string streetAddress = form["streetAdress"].ToString();
            string city = form["city"].ToString();
            string province = form["province"].ToString();
            string country = form["country"].ToString();
            string jobDescripition = form["jobdesciption"].ToString();
            string jobDuties = form["jobRequirements"].ToString();
            string jobrequirements = form["jobDuties"].ToString();
            string jobVisible = "false";
            string postalcode = form["postalcode"].ToString();
            int company = (from Company in db.Companies
                           where Company.CompName.Contains(compname)
                           select Company.CompId).SingleOrDefault();
         //   int compId = Convert.ToInt32(company);

            JobPosting jobposting = new JobPosting()
            {
                JobTitle = jobtitle,
                JobType = jobtype,
                PostStartDate = postingdate,
                PostEndDate = closingdate,
                NumPositions = positions,
                JobLevel = joblevel,
                JobCompensation = jobSalary,
                Description = jobDescripition,
                JobReq = jobrequirements,
                JobDuties = jobrequirements,
                CompanyCompId = company,
                RecruiterRecId = 1,
                JobVisible = jobVisible,
                JobCategory = category,
                JobSubcategory = subcategory,
            };
            db.JobPostings.Add(jobposting);
            Location loc = new Location();

            loc.AptNum = aptNum;
            loc.StreetAdd = streetAddress;
            loc.City = city;
            loc.Country = country;
            loc.Province = province;
            jobposting.Location = loc;
            loc.PostalCode = postalcode;
           
            db.Locations.Add(jobposting.Location);

            db.SaveChanges();
            return View();
        }

        // GET: JobPostings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobPostId = new SelectList(db.UserMedias, "UMediaId", "VidPath", jobPosting.JobPostId);
            ViewBag.CompanyCompId = new SelectList(db.Companies, "CompId", "CompName", jobPosting.CompanyCompId);
            return View(jobPosting);
        }

        public SelectList GetCountries()
        {
            var country = from Country in db.Countries
                          group Country by Country.CountryName into unique
                          select unique.FirstOrDefault();
            return new SelectList(country, "CountryName", "CountryName", "Id");
        }

        public SelectList GetProvince()
        {
            var country = from Country in db.Countries
                          where Country.CountryName.Contains("CA")
                          group Country by Country.Province into unique
                          select unique.FirstOrDefault();
            return new SelectList(country, "Province", "Province", "Id");
        }
        public SelectList GetCities()
        {
            var country = from Country in db.Countries
                          where Country.Province.Contains("Ontario")
                          group Country by Country.City into unique
                          select unique.FirstOrDefault();
            return new SelectList(country, "City", "City", "Id");
        }

        public SelectList GetCategories()
        {
            var jobcategories = from JobCategory in db.JobCategories
                                group JobCategory by JobCategory.CatName into uniqueCategories
                                select uniqueCategories.FirstOrDefault();

            return new SelectList(jobcategories, "CatName", "CatName", "Id");
        }

        public SelectList GetSubcategories()
        {
            var jobcategories = from JobCategory in db.JobCategories
                                where JobCategory.CatName.Contains("Software Development")
                                group JobCategory by JobCategory.SubCategory into uniqueCategories
                                select uniqueCategories.FirstOrDefault();

            return new SelectList(jobcategories, "SubCategory", "SubCategory", "Id");
        }
        public SelectList GetJobLevel()
        {
            List<string> joblevels = new List<string>();
            joblevels.Add("Student");
            joblevels.Add("Entry Level");
            joblevels.Add("Experienced (Non-manager)");
            joblevels.Add("Manager");
            joblevels.Add("Executive");
            joblevels.Add("Senior - Executive");
            return new SelectList(joblevels);
        }
        public SelectList GetJobType()
        {
            List<string> jobtypes = new List<string>();
            jobtypes.Add("Part-time");
            jobtypes.Add("Full-time");
            jobtypes.Add("Temporary/Contract");
            jobtypes.Add("Intern");
            return new SelectList(jobtypes);
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
