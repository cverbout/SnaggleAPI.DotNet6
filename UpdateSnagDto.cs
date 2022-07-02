namespace SnaggleAPI
{
    public class UpdateSnagDto
    {
        public int Id { get; set; } = 1;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Status CurrentStatus { get; set; } = Status.Open;
    }
}
