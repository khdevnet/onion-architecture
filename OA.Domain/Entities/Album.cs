using System.Collections.Generic;

namespace OA.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
