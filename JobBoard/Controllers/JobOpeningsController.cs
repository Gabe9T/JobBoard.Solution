using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.Controllers
{
  public class JobOpeningsController : Controller
  {
    [HttpGet("/jobopenings")]
    public ActionResult Index()
    {
      List<JobOpening> allJobs = JobOpening.GetAll();
      return View(allJobs);
    }

    [HttpGet("/jobopenings/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/jobopenings")]
    public ActionResult Create(string title, string description, string contact) //was dict contact
    {
      JobOpening newJob = new JobOpening(title, description, contact);
      return RedirectToAction("Index");
    }
    
//NOTWORKING
    [HttpGet("/jobopenings/{id}")]
    public ActionResult JobDetails(int id)
    {
      JobOpening foundJob = JobOpening.Find(id);
      return View(foundJob);
    }

    // [HttpPost("/jobopenings/details")]
    // public ActionResult JobDetails(string title, string description, string contact)
    // {
    //   // JobOpening newJob = new JobOpening(title, description, contact);
    //   return View(JobDetails);
    // }
  }
}