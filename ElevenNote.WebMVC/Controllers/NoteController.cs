using ElevenNote.Models;
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
            var model = new NoteListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }








    }
}