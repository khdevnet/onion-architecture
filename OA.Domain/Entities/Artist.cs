using System.Collections.Generic;

namespace OA.Domain.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
