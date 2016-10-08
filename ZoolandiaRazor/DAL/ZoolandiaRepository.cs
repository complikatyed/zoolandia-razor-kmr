using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRepository
    {
        public ZoolandiaContext Context { get; set; }

        public ZoolandiaRepository()
        {
            Context = new ZoolandiaContext();
        }

        public ZoolandiaRepository(ZoolandiaContext _context)
        {
            Context = _context;
        }
    }
}