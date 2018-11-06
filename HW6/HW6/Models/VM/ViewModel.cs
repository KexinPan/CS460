using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.VM
{
    public class ViewModel
    {
        public Person Person { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceLine> InvoiceLine { get; set; }
    }
}