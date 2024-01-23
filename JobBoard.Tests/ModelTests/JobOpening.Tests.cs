using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JobBoard.Models;
using System;

namespace JobBoard.TestTools
{
  [TestClass]
  public class JobOpeningTests
  {
    [TestMethod]
    public void JobOpeningConstructor_CreatesInstanceOfJobOpening_JobOpening()
    {
      JobOpening newJobOpening = new JobOpening("Dog Walker", "desc");
      Assert.AreEqual(typeof(JobOpening), newJobOpening.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Dog Walker";
      JobOpening newJob = new JobOpening(title, "desc");
      string result = newJob.Title;
      Assert.AreEqual(title, result);
    }
    [TestMethod]
    public void SetTitle_SetsValueOfTitle_String()
    {
      string title = "Dog Walker";
      JobOpening newJob = new JobOpening(title, "desc");
      string updatedTitle = "Line Cook";
      newJob.Title = updatedTitle;
      string result = newJob.Title;
      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetDescription_ReturnDescription_String()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      JobOpening newJob = new JobOpening(title, description);
      string result = newJob.Description;
      Assert.AreEqual(description, result);
    }
    public void SetDescription_SetsValueOfDescription_String()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      JobOpening newJob = new JobOpening(title, description);
      string updatedDescription = "I cook things";
      newJob.Description = updatedDescription;
      string result = newJob.Description;
      Assert.AreEqual(updatedDescription, result);
    }

  }
}