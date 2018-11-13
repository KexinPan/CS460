using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        public DateTime DateValue { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public string IPAddress { get; set; }

        public string Type { get; set; }

    }
}