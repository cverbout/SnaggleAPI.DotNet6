namespace SnaggleAPI
{
    public enum Status
    {
        Open,
        Closed
    }
    public class Snag
    {
        public string Project { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        //public int ResponseCount { get; set; } = 0;

        public Status CurrentStatus { get; set; } = Status.Open;
    }
}

