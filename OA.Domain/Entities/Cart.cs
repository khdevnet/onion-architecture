using System;

namespace OA.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public string CartId { get; set; }

        public int AlbumId { get; set; }

        public int Count { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Album Album { get; set; }
    }
}
