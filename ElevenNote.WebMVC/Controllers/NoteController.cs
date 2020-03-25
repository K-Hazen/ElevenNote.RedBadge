using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
      //First word in the controller Name (i.e. Note) will be the first part of our url path xxxx/Note

        [Authorize] //only available to logged in users 
    public class NoteController : Controller
    {
        // GET: Note

            //ActionResult = a type that allows us to return the View()
            //Index = next in line for url name so xxxx/ControllerName/ActionResult method name 
        public ActionResult Index()
        {
            //newing up an instance of the model. Must have an instance here for the view to use (populate data)

            //Authenticates Guid
            var userId = Guid.Parse(User.Identity.GetUserId());

            //new instance of NoteService 
            var service = new NoteService(userId);

            //Get Notes method from Note Service 
            var model = service.GetNotes();
            return View(model);
        }

        //GET
        //This section creates a GET method that gies users a VIEW in where they can input the info to create a note
        //Making a request to get the create VIEW - "hey we need this page" 
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            //Makes sure model is valid 
            if (!ModelState.IsValid) return View(model);

            //grabs userID
            var service = CreateNoteService();  

            //Calls in method
            if (service.CreateNote(model))
            {
                //Temp Data vs. ViewBag --> temp removes the information after it is accessed
                TempData["SaveResult"] = "Your note was created.";
                //returns user back to index (list view) --> shows user action was completed 
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created");

            return View(model);
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }







    }
}