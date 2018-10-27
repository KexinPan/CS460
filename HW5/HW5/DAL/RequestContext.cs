using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class RequestContext: DbContext
    {
        // passing the name of database to Dbcontext structure
        public RequestContext() : base("name=RequestList")
        {

        }

        // get access to the table
        public virtual DbSet<RequestForm> request { get; set; }
    }
}