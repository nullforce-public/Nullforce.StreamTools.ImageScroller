using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nullforce.StreamTools.ImageScroller
{
    public class ScrollSettings
    {
        public int ImageCount { get; set; }
        public string ImageLocation { get; set; }
        public int ImageMaxHeight { get; set; }
        public int ImageMaxWidth { get; set; }
        public int IntervalInSeconds { get; set; }
        public bool ShuffleImages { get; set; }
    }
}
