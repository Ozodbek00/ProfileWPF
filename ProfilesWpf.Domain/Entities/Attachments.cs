using System;

namespace ProfilesWpf.Domain.Entities
{
    public class Attachments
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
