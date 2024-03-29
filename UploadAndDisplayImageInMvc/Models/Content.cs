﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UploadAndDisplayImageInMvc.Models
{
    public class Content 
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
    }
}