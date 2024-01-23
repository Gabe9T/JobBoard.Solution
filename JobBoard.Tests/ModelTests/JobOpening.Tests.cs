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
      JobOpening newJobOpening = new JobOpening("Dog Walker");
      Assert.AreEqual(typeof(JobOpening), newJobOpening.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Dog Walker";
      JobOpening newJob = new JobOpening(title);
      string result = newJob.Title;
      Assert.AreEqual(title, result);
    }

  }
}