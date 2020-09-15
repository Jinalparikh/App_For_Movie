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
                customers = new Customers(),
                MembershiptypeList = membershiptype,
            };

            return View("CustomerForm", ModelView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerMembershipTypeMovdelView
                {
                    customers = customers,
                    MembershiptypeList = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);

                customerInDb.Name = customers.Name;
                customerInDb.Birthdate = customers.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customers.MembershipTypeId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerMembershipTypeMovdelView()
            {
                customers = customer,
                MembershiptypeList = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
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