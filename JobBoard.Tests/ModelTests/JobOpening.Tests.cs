using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JobBoard.Models;
using System;

namespace JobBoard.TestTools
{
  [TestClass]
  public class JobOpeningTests : IDisposable
  {
    public void Dispose()
    {
      JobOpening.ClearAll();
    }
    [TestMethod]
    public void JobOpeningConstructor_CreatesInstanceOfJobOpening_JobOpening()
    {
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      JobOpening newJobOpening = new JobOpening("Dog Walker", "desc", contact);
      Assert.AreEqual(typeof(JobOpening), newJobOpening.GetType());
    }
    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      string title = "Dog Walker";
      JobOpening newJob = new JobOpening(title, "desc", contact);
      string result = newJob.Title;
      Assert.AreEqual(title, result);
    }
    [TestMethod]
    public void SetTitle_SetsValueOfTitle_String()
    {
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      string title = "Dog Walker";
      JobOpening newJob = new JobOpening(title, "desc", contact);
      string updatedTitle = "Line Cook";
      newJob.Title = updatedTitle;
      string result = newJob.Title;
      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetDescription_ReturnDescription_String()
    {
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      string title = "Dog Walker";
      string description = "I walk dogs.";
      JobOpening newJob = new JobOpening(title, description, contact);
      string result = newJob.Description;
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void SetDescription_SetsValueOfDescription_String()
    {
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      string title = "Dog Walker";
      string description = "I walk dogs.";
      JobOpening newJob = new JobOpening(title, description, contact);
      string updatedDescription = "I cook things";
      newJob.Description = updatedDescription;
      string result = newJob.Description;
      Assert.AreEqual(updatedDescription, result);
    }
    [TestMethod]
    public void GetContactInfo_ReturnsContactInfo_Object()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      JobOpening newJob = new JobOpening(title, description, contact);
      Dictionary<string, string> result = newJob.ContactInfo;
      CollectionAssert.AreEquivalent(contact, result);
    }
    
    [TestMethod]
      public void SetContactInfo_ReturnsContactInfo_Object()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      JobOpening newJob = new JobOpening(title, description, contact);
      Dictionary<string, string> newContact = new Dictionary<string, string>
      {
        {"name", "Ravin"},
        {"email", "the@email.com"},
        {"phone", "5895554789"}
      };
      newJob.ContactInfo = newContact;
      Dictionary<string, string> result = newJob.ContactInfo;
      CollectionAssert.AreEquivalent(newContact, result);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyList_JobOpeningList()
    {
      List<JobOpening> newList = new List<JobOpening> { };
      List<JobOpening> result = JobOpening.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsJobOpening_JobOpeningList()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      JobOpening newJob = new JobOpening(title, description, contact);
      string title1 = "Dog Groomer";
      string description1 = "I groom dogs.";
      Dictionary<string, string> contact1 = new Dictionary<string, string>
      {
        {"name", "Ravin"},
        {"email", "dcb@gmail.com"},
        {"phone", "5551234567"}
      };
      JobOpening newJob1 = new JobOpening(title, description, contact);
      List<JobOpening> newList = new List<JobOpening> { newJob, newJob1};
      List<JobOpening> result = JobOpening.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      Dictionary<string, string> contact = new Dictionary<string, string>
      {
        {"name", "Kim"},
        {"email", "abc@gmail.com"},
        {"phone", "5551234567"}
      };
      JobOpening newJob = new JobOpening(title, description, contact);

      int result = newJob.Id;
      Assert.AreEqual(1, result);
    }
    
  }
}