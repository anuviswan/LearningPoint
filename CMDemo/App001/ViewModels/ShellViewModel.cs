using App001.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App001.ViewModels
{
    public class ShellViewModel:Screen
    {
        public ShellViewModel()
        {
            DepartmentCollection.Add(new DeparmentModel() { DepartmentName = "Finance", Supervisor = "John Tommothy" });
            DepartmentCollection.Add(new DeparmentModel() { DepartmentName = "Development", Supervisor = "Alex Brown" });
            DepartmentCollection.Add(new DeparmentModel() { DepartmentName = "Human Resource", Supervisor = "Dennis Burton" });
        }

        private string _FirstName = "Jia Anu";

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                NotifyOfPropertyChange(nameof(FirstName));
                NotifyOfPropertyChange(nameof(FullName));
            }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set {
                _LastName = value;
                NotifyOfPropertyChange(nameof(LastName));
                NotifyOfPropertyChange(nameof(FullName));
            }
        }

        
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        private BindableCollection<DeparmentModel> _DepartmentCollection = new BindableCollection<DeparmentModel>();

        public BindableCollection<DeparmentModel> DepartmentCollection
        {
            get { return _DepartmentCollection; }
            set
            {
                _DepartmentCollection = value;
                
            }
        }

        private DeparmentModel _SelectedDepartment;

        public DeparmentModel SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set
            {
                _SelectedDepartment = value;
                NotifyOfPropertyChange(nameof(SelectedDepartment));
            }
        }

        public bool CanClearTextMethod(string firstName, string lastName)
        {
            return !string.IsNullOrEmpty(firstName);
        }

        public void ClearTextMethod(string firstName,string lastName)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}

