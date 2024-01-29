using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;
using MySqlConnector;
namespace JobBoard.Models
{
  public class JobOpening
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Id { get; }
    //public Dictionary<string, string> ContactInfo { get; set; } 
    public string ContactInfo { get; set; }

  public JobOpening(string title, string description, string contactInfo)
    {
      Title = title;
      Description = description;
      ContactInfo = contactInfo; 
      // ?? new Dictionary<string, string>
      // {
      //   {"Phone", "1-800-555-5555"}
      // };
    }

    public JobOpening(string title, string description, string contactInfo, int id)
    {
      Title = title;
      Description = description;
      ContactInfo = contactInfo;
      Id = id;
    }

    public override bool Equals(object otherJobOpening)
    {
      if (otherJobOpening is not JobOpening)
      {
        return false;
      }
      else
      {
        JobOpening job = (JobOpening) otherJobOpening;
        if (
        (Description == job.Description) &&
        (ContactInfo == job.ContactInfo) &&
        (Title == job.Title))
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }
    public void Save()
    {
      MySqlConnection conn = new(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand();
      
      cmd.CommandText = "INSERT INTO jobOpenings (title, description, contactInfo) VALUES (@Title, @Description, @ContactInfo);";
      cmd.Parameters.AddWithValue("@Title", Title);
      cmd.Parameters.AddWithValue("@Description", Description);
      cmd.Parameters.AddWithValue("@ContactInfo", ContactInfo);
      
      //contact dict is contactname, phone, email

      cmd.ExecuteNonQuery();
      //Id = cmd.LastInsertedId;
      
      conn.Close();
      conn?.Dispose();
    }
    public static List<JobOpening> GetAll()
    {
      List<JobOpening> allJobs = new List<JobOpening> { };
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);

      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM jobOpenings;"; //table name...

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int jobId = rdr.GetInt32(0);
        string jobTitle = rdr.GetString(1);
        string jobDescription = rdr.GetString(2);
        string contactInfo = rdr.GetString(3);
        JobOpening newJob = new(jobTitle, jobDescription, contactInfo, jobId);
        allJobs.Add(newJob);
      }
      conn.Close();
      conn?.Dispose(); //shortcut for if statement
      return allJobs;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM jobOpenings;";
      cmd.ExecuteNonQuery();

      conn.Close();
      conn?.Dispose();
    }

    public static JobOpening Find(int searchID)
    {
      // Dictionary<string, string> contactInfo = new() { {"Phone", "1-800-555-5555"}};
      JobOpening placeholderJob = new JobOpening("placeholder item", "1", "contact");
      return placeholderJob;
    }
  }
}