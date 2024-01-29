using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JobBoard.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace JobBoard.Tests
{
  [TestClass]
  public class JobOpeningTests : IDisposable
  {

    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      JobOpening.ClearAll();
    }

    public JobOpeningTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    [TestMethod]
    public void JobOpeningConstructor_CreatesInstanceOfJobOpening_JobOpening()
    {
      string contact = "name:kim";
      JobOpening newJobOpening = new JobOpening("Dog Walker", "desc", contact);
      Assert.AreEqual(typeof(JobOpening), newJobOpening.GetType());
    }
    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string contact = "name:kim";
      string title = "Dog Walker";
      JobOpening newJob = new JobOpening(title, "desc", contact);
      string result = newJob.Title;
      Assert.AreEqual(title, result);
    }
    [TestMethod]
    public void SetTitle_SetsValueOfTitle_String()
    {
      string contact = "name:kim";
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
      string contact = "you";
      string title = "Dog Walker";
      string description = "I walk dogs.";
      JobOpening newJob = new JobOpening(title, description, contact);
      string result = newJob.Description;
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void SetDescription_SetsValueOfDescription_String()
    {
      string contact = "name:kim";
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
      string contact = "name:kim";
      JobOpening newJob = new JobOpening(title, description, contact);
      string result = newJob.ContactInfo;
      Assert.AreEqual(contact, result);
    }

    [TestMethod]
    public void SetContactInfo_ReturnsContactInfo_Object()
    {
      string title = "Dog Walker";
      string description = "I walk dogs.";
      string contact = "name:kim";
      JobOpening newJob = new JobOpening(title, description, contact);
      string newContact = "name:ravin";
      newJob.ContactInfo = newContact;
      string result = newJob.ContactInfo;
      Assert.AreEqual(newContact, result);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyListFROMDB_JobOpeningList()
    {
      List<JobOpening> newList = new List<JobOpening> { };
      List<JobOpening> result = JobOpening.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      string title1 = "Dog Walker";
      string description1 = "I walk dogs.";
      string contact1 = "me";
      JobOpening firstJob = new JobOpening(title1, description1, contact1);
      JobOpening secondJob = new JobOpening(title1, description1, contact1);
      Assert.AreEqual(firstJob, secondJob);
    }
    [TestMethod]

    public void Save_SavesToDatabase_ItemList()
    {
      string title1 = "Dog Walker";
      string description1 = "I walk dogs.";
      string contact1 = "abc @gmail.com";
      JobOpening testItem = new(title1, description1, contact1);
      testItem.Save();
      List<JobOpening> result = JobOpening.GetAll();
      List<JobOpening> testList = new() { testItem };

      CollectionAssert.AreEqual(testList, result);
    }
    // [TestMethod]
    // public void GetAll_ReturnsJobOpening_JobOpeningList()
    // {
    //   string title = "Dog Walker";
    //   string description = "I walk dogs.";
    //   Dictionary<string, string> contact = new Dictionary<string, string>
    //   {
    //     {"name", "Kim"},
    //     {"email", "abc@gmail.com"},
    //     {"phone", "5551234567"}
    //   };
    //   JobOpening newJob = new JobOpening(title, description, contact);
    //   string title1 = "Dog Groomer";
    //   string description1 = "I groom dogs.";
    //   Dictionary<string, string> contact1 = new Dictionary<string, string>
    //   {
    //     {"name", "Ravin"},
    //     {"email", "dcb@gmail.com"},
    //     {"phone", "5551234567"}
    //   };
    //   JobOpening newJob1 = new JobOpening(title, description, contact);
    //   List<JobOpening> newList = new List<JobOpening> { newJob, newJob1};
    //   List<JobOpening> result = JobOpening.GetAll();
    //   CollectionAssert.AreEqual(newList, result);
    // }
    // [TestMethod]
    // public void GetId_JobsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   string title = "Dog Walker";
    //   string description = "I walk dogs.";
    //   Dictionary<string, string> contact = new Dictionary<string, string>
    //   {
    //     {"name", "Kim"},
    //     {"email", "abc@gmail.com"},
    //     {"phone", "5551234567"}
    //   };
    //   JobOpening newJob = new JobOpening(title, description, contact);

    //   int result = newJob.Id;
    //   Assert.AreEqual(1, result);
    // }

    // [TestMethod]
    // public void Find_ReturnsCorrectJob_JobOpening()
    // {
    //   string title = "Dog Walker";
    //   string description = "I walk dogs.";
    //   Dictionary<string, string> contact = new Dictionary<string, string>
    //   {
    //     {"name", "Kim"},
    //     {"email", "abc@gmail.com"},
    //     {"phone", "5551234567"}
    //   };
    //   JobOpening newJob = new JobOpening(title, description, contact);
    //   string title1 = "Dog Groomer";
    //   string description1 = "I groom dogs.";
    //   Dictionary<string, string> contact1 = new Dictionary<string, string>
    //   {
    //     {"name", "Ravin"},
    //     {"email", "dcb@gmail.com"},
    //     {"phone", "5551234567"}
    //   };
    //   JobOpening newJob1 = new JobOpening(title1, description1, contact1);
    //   JobOpening result = JobOpening.Find(2);
    //   Assert.AreEqual(newJob1, result);
    // }

  }
}