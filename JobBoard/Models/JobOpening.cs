using System.Collections.Generic;
using MySqlConnector;
namespace JobBoard.Models
{
  public class JobOpening
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
    //public Dictionary<string, string> ContactInfo { get; set; } 
    public string ContactInfo { get; set; }

  public JobOpening(string title, string description, string contactInfo)
    {
      Title = title;
      Description = description;
      ContactInfo = contactInfo; 
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
      
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      
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
        JobOpening newJob = new(
          jobTitle ?? "N/A",
          jobDescription ?? "N/A",
          contactInfo ?? "N/A", jobId);
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
      MySqlConnection conn = new(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM jobOpenings WHERE id = @ThisId;";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = searchID;
      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int jobId = 0;
      string jobDescription = "";
      string jobTitle = "";
      string contactInfo = "";
      
      while (rdr.Read())
      {
        jobId = rdr.GetInt32(0);
        jobTitle = rdr.GetString(1);
        jobDescription = rdr.GetString(2);
        contactInfo = rdr.GetString(3);
      }
      JobOpening newJob = new(jobTitle, jobDescription, contactInfo, jobId);
      conn.Close();
      conn?.Dispose();
      return newJob;
    }
  }
}