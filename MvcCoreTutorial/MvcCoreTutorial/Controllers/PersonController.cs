using Microsoft.AspNetCore.Mvc;
using MvcCoreTutorial.Mapper;
using MvcCoreTutorial.Models.Domain;
using MvcCoreTutorial.ViewModels;

namespace MvcCoreTutorial.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        { 
            // below ways use sessions which is bad practice, it is burden to servers.
            // // below techniques is: controller => view but not vice versa
            
            //ViewBag and ViewData can send data only from ControllerToView
            ViewBag.greeting = "Hello World !!";
            ViewData["greeting2"] = "I am using ViewData";
           
            // TempData can send data from one controller method to another Controller method
            TempData["greeting3"] = "It's TempData msg";
            return View();
        }
        

        // it is a get method
        public IActionResult AddPerson() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(PersonViewModel personVM)
        {
            var person = personVM.ToModel();

            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not be added!!!";
                return View();
            }
        }
    

        // Edit/Update Feature

        public IActionResult DisplayPersons()
        {
            
            var persons = _ctx.Person.ToList();
            var personsVM = persons.ToViewModel();
            return View(personsVM); 
        }

        public IActionResult EditPerson(int Id)
        {
            
            var person = _ctx.Person.Find(Id);
            var personVM = person.ToViewModel();
            return View(personVM);



        }

        [HttpPost]
        public IActionResult EditPerson(PersonViewModel personVM)
        {
            var person = personVM.ToModel();
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Update(person);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not be added";
                return View();
            }
        }

        // Delete Confirm
        public IActionResult DeleteConfirm(int id)
        {
            var person = _ctx.Person.Find(id);
            var personVM = person.ToViewModel();
            return View(personVM);
        }

        [HttpPost]
        public IActionResult DeletePerson(PersonViewModel personVM)
        {
            try
            {
                var person = personVM.ToModel();
                //var personss = _ctx.Person.Find(Id);
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex )
            {
               
            }
            return RedirectToAction("DisplayPersons");

        }
    }
}
