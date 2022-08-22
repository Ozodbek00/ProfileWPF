using System;

namespace ProfilesWpf.Domain.Entities
{
    public class Student
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public long? ImageId { get; set; }
        public Attachments Image { get; set; }
        public long? PassportId { get; set; }
        public Attachments Passport { get; set; }
    }
}
