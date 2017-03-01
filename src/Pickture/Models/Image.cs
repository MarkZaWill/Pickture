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
        public float Anger { get; set; }
        public float Contempt { get; set; }
        public float Fear { get; set; }
        public float Happiness { get; set; }
        public float Neutral { get; set; }
        public float Sadness { get; set; }
        public float Surprise { get; set; }
        public float Disgust { get; set; }

    }
}
