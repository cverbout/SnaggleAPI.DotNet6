﻿using System.Text.Json.Serialization;

namespace SnaggleAPI.Models
{
    public class Project
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;

        public ICollection<Snag>? Snags { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

    }
}
