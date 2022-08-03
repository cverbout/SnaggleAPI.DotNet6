namespace SnaggleAPI.Models
{
    public class CreateSnagDto
    {
        public string Title { get; set; } = "Title";
        public string Username { get; set; } = "Default";
        public string Description { get; set; } = "Description";
        public int ProjectId { get; set; } = 1;
    }
}
