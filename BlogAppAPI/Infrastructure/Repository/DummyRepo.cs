using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
   public class DummyRepo:IDummy
   {
       public Dummy GetName()
       {
            return new Dummy() { Name = "Bhavesh" };
       }
   }
}
