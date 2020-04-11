using AutoMapper;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper.UseIoc
{
    public class AssemblyProfile:Profile
    {
        public AssemblyProfile()
        {
            CreateMap<Person, Student>().ConstructUsingServiceLocator();
            CreateMap<Address, Address>().ConstructUsingServiceLocator();
        }
    }
}
