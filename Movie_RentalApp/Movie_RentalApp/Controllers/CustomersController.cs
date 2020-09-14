using Movie_RentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.InteropServices.WindowsRuntime;
using Movie_RentalApp.ViewModel; 

namespace Movie_RentalApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var Customers = _context.Customers.Include(C => C.MembershipType).ToList();
            return View(Customers);
        }
        
        public ActionResult New()
        {
            var membershiptype = _context.MembershipType.ToList();

            var ModelView = new CustomerMembershipTypeMovdelView()
            {
                MembershiptypeList = membershiptype,
            };

            return View(ModelView);
        }

        [HttpPost]
        public ActionResult Create(Customers customers)
        {
            _context.Customers.Add(customers);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(C => C.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}