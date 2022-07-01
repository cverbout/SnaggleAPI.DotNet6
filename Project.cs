namespace SnaggleAPI
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;

        

      
        
    }
}
