using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Asp.NET.Services
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string messege) : base(messege)
        {

        }
    }
}
