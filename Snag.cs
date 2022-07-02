using System.Text.Json.Serialization;

namespace SnaggleAPI
{
    public enum Status
    {
        Open,
        Closed
    }
    public class Snag
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        //public int ResponseCount { get; set; } = 0;

        public Status CurrentStatus { get; set; } = Status.Open;
        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }

    }
}

