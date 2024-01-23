using System.Collections.Generic;
namespace JobBoard.Models
{
  public class JobOpening
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Id { get; }
    public Dictionary<string, string> ContactInfo { get; set; }
    private static List<JobOpening> _instances = new List<JobOpening> { };

    public JobOpening(string title, string description, Dictionary<string, string> contactInfo)
    {
      Title = title;
      Description = description;
      ContactInfo = contactInfo;
      _instances.Add(this);
      Id = _instances.Count;
    }
    public static List<JobOpening> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear(); //can't access _instances here b/c no return and _inst is private
    }
  }
}