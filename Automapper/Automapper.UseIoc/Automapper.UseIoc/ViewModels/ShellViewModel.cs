using Automapper.UseIoc.Models;
using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper.UseIoc.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel(IMapper mapper)
        {
            PersonInstance = IoC.Get<Person>();
            PersonInstance.Age = 50;
            PersonInstance.FirstName = "Person First Name";
            PersonInstance.LastName = "Person Last Name";
            PersonInstance.Address = IoC.Get<Address>();
            PersonInstance.Address.Street = "Modified Street";
            PersonInstance.Address.City = "Modified City";
            PersonInstance.Address.State = "Modified State";
            PersonInstance.Address.Country = "Modified Country";
            StudentInstance = mapper.Map<Student>(PersonInstance);
        }

        public Student StudentInstance { get; set; }
        public Person PersonInstance { get; set; }
    }
}
