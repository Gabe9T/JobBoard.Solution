using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.Controllers
{
  public class JobOpeningController : Controller
  {
    [HttpGet("/jobopening")]
    public ActionResult Index()
    {
      List<JobOpening> allJobs = JobOpening.GetAll();
      return View(allJobs);
    }
    [HttpGet("/jobopening/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/jobopening")]
    public ActionResult Create(string title, string description, Dictionary<string, string> contact)
    {
      JobOpening newJob = new JobOpening(title, description, contact);
      return RedirectToAction("Index");
    }
  }
}