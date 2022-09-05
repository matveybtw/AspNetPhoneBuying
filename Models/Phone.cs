using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspPhoneBuying.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string OS { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorModel { get; set; }
        public string ProcessorCores { get; set; }
        public string GPU { get; set; }
        public string Storage { get; set; }
        public string RAM { get; set; }
        public string Camera { get; set; }
        public string CameraResolution { get; set; }
        public string Price { get; set; }
    }
}