using AutoMapper;
using Caliburn.Micro;
using Shared.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
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

            Result = string.Join(Environment.NewLine, Validate(PersonInstance, StudentInstance));
        }

        public IEnumerable<string> Validate(Person source,Student destination)
        {
            yield return $"Mapping <{nameof(Person.FirstName)},{nameof(Student.FirstName)}>,Is Equal : {Equals(source.FirstName, destination.FirstName)}, Is Same : {ReferenceEquals(source.FirstName, destination.FirstName)}";
            yield return $"Mapping <{nameof(Person.LastName)},{nameof(Student.LastName)}>,Is Equal : {Equals(source.LastName, destination.LastName)}, Is Same : {ReferenceEquals(source.LastName, destination.LastName)}";
            yield return $"Mapping <{nameof(Person.Age)},{nameof(Student.Age)}>,Is Equal : {Equals(source.Age, destination.Age)}, Is Same : {ReferenceEquals(source.Age, destination.Age)}";
            yield return $"Mapping <{nameof(Person.Address)},{nameof(Student.Address)}>,Is Equal : {Equals(source.Address, destination.Address)}, Is Same : {ReferenceEquals(source.Address, destination.Address)}";
            
            yield return $"...Mapping <{nameof(Person.Address.City)},{nameof(Student.Address.Street)}>,Is Equal : {Equals(source.Address.Street, destination.Address.Street)}, Is Same : {ReferenceEquals(source.Address.Street, destination.Address.Street)}";
            yield return $"...Mapping <{nameof(Person.Address.City)},{nameof(Student.Address.City)}>,Is Equal : {Equals(source.Address.City, destination.Address.City)}, Is Same : {ReferenceEquals(source.Address.City, destination.Address.City)}";
            yield return $"...Mapping <{nameof(Person.Address.State)},{nameof(Student.Address.State)}>,Is Equal : {Equals(source.Address.State, destination.Address.State)}, Is Same : {ReferenceEquals(source.Address.State, destination.Address.State)}";
            yield return $"...Mapping <{nameof(Person.Address.Country)},{nameof(Student.Address.Country)}>,Is Equal : {Equals(source.Address.Country, destination.Address.Country)}, Is Same : {ReferenceEquals(source.Address.Country, destination.Address.Country)}";
        }
        public string Result { get; set; }

        public Student StudentInstance { get; set; }
        public Person PersonInstance { get; set; }
    }
}
