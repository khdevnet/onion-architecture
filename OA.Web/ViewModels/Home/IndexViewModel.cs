using OA.Domain.Entities;
using System.Collections.Generic;

namespace OA.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
    }
}
