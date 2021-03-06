﻿using System.Collections.Generic;

namespace OA.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
