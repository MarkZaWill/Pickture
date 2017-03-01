using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickture.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageURL { get; set; }
        public int TakerId { get; set; }

    }
}
