//---------------------------------------------------------------------
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace BindingFiltering
{
    public class Employee
    {
        private string lastNameValue;
        private string firstNameValue;
        private int salaryValue;
        private DateTime startDateValue;
        public Employee()
        {
            LastName = "Last Name";
            FirstName = "First Name";
            Salary = 40000;
            StartDate = DateTime.Today;
        }
        public Employee(string lastName, string firstName,
            int salary, DateTime startDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Salary = salary;
            StartDate = startDate;
        }

        public string LastName
        {
            get { return lastNameValue; }
            set { lastNameValue = value; }
        }
        public string FirstName
        {
            get { return firstNameValue; }
            set { firstNameValue = value; }
        }

        public int Salary
        {
            get { return salaryValue; }
            set { salaryValue = value; }
        }

        public DateTime StartDate
        {
            get { return startDateValue; }
            set { startDateValue = value; }
        }

        public override string ToString()
        {
            return LastName + ", " + FirstName + "\n" +
                "Salary:" + salaryValue + "\n" +
                "Start date:" + startDateValue;
        }

    }
}
