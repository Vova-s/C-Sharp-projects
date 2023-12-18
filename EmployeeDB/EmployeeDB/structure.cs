using System;
using static System.Console;

namespace TestSimpleDB
{
    struct Employee
    {
        private byte ID;
        private string Surname;
        private string Name;
        private string last_name;
        private string gender;
        private DateTime date_birthday;
        private string residence_address;
        private string position;
        private string unit;
        private DateTime date_join;
        private DateTime date_leave;


        public Employee(byte ID,string Surname,string Name, string last_name, string gender, DateTime date_birthday, string residence_address, string unit, string position , DateTime date_join, DateTime date_leave)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Name = Name;         
            this.last_name = last_name;
            this.gender = gender;
            this.date_birthday = date_birthday;
            this.residence_address = residence_address;
            this.position = position;
            this.unit = unit;
            this.date_join= date_join;
            this.date_leave = date_leave;

        }

        public byte getID() => ID;
        public string getSurname() => Surname;
        public string getName() => Name;
        public string getlast_name() => last_name;
        public string getgender() => gender; 
        public string getresidence_address() => residence_address;
        public string getposition() => position;
        public string getunit() => unit;

        public DateTime dates_birthday() => date_birthday;






        public void printEmployee()
        {
            Write($"{ID,3},");
            Write($"{Surname,5},");
            Write($"{Name,5},");
            Write($"{last_name,5},");
            Write($"{gender,3},");
            Write($"{date_birthday,5}.");
            Write($"{residence_address,5},");
            Write($"{position,5},");
            Write($"{unit,5},");
            Write($"{date_join,5}.");
            Write($"{date_leave,5}.");

        }
    }

    struct Subdivision
    {
        private byte ID;
        private string name_of_the_unit;
        

        public Subdivision(byte ID,string name_of_the_unit)
        {
            this.ID = ID;
            this.name_of_the_unit = name_of_the_unit;
            
        }
        public byte getID() => ID;
        public string getname_of_the_unit() => name_of_the_unit;
        

        public void printSubdivision()
        {
            Write($"{ID,5},");
            Write($"{name_of_the_unit,5},");
            
        }
    }
    struct staff
    {
        private byte ID_staf;
        private string name_of_the_staff;


        public staff(byte ID_staf, string name_of_the_staff)
        {
            this.ID_staf = ID_staf;
            this.name_of_the_staff = name_of_the_staff;

        }
        public byte getID_staff() => ID_staf;
        public string getname_of_the_staff() => name_of_the_staff;


        public void printstaff()
        {
            Write($"{ID_staf,5},");
            Write($"{name_of_the_staff,5},");

        }
    }

    struct Employee_Subdivision
    {
        public byte id_employee;
        public byte id_subdivision;
        public string name_subdivision;
        public string name_employee;
        public string Surname_employee;
        public string lastname_employee;
        public DateTime date_birthday_emp;


        public Employee_Subdivision(byte id_employee, byte id_subdivision, string name_subdivision, string name_employee, string Surname_employee, string lastname_employee, DateTime date_birthday_emp)
        {
            this.id_employee = id_employee; ;
            this.id_subdivision = id_subdivision;
            this.name_subdivision = name_subdivision;
            this.name_employee = name_employee;
            this.Surname_employee = Surname_employee;
            this.lastname_employee = lastname_employee;
            this.date_birthday_emp = date_birthday_emp;
        }

        public byte getID_emp() => id_employee;
        public byte getID_sub() => id_subdivision;
        public string name_subdivisions() => name_subdivision;
        public string name_employees() => name_employee;
        public string Surname_employees() => Surname_employee;
        public string lastname_employees() => lastname_employee;
        public DateTime date_birthday_emps() => date_birthday_emp;


        public void print_Employee_Subdivision()
        {
            Write($"{id_employee,15 },");
            Write($"{id_subdivision,15},");
            Write($"{name_subdivision,15},");
            Write($"{name_employee,15},");
            Write($"{Surname_employee,15},");
            Write($"{lastname_employee,15},");

        }
    }
        struct Employee_staffs
        {

            public byte id_employee_staff;
          
            public string name_position;
            public string name_employee;
            public string Surname_employee;
            public string lastname_employee;
            public Employee_staffs(byte id_employee_staff, string name_position, string name_employee, string Surname_employee, string lastname_employee)
            {
                this.id_employee_staff = id_employee_staff; ;
             
                this.name_position = name_position;
                this.name_employee = name_employee;
                this.Surname_employee = Surname_employee;
                this.lastname_employee = lastname_employee;

            }
            public byte getID_emp_St() => id_employee_staff;
           
            public string name_positions() => name_position;
            public string name_employees() => name_employee;
            public string Surname_employees() => Surname_employee;
            public string lastname_employees() => lastname_employee;
            public void print_Employee_Staff()
            {
                Write($"{id_employee_staff,15 },");
                
                Write($"{name_position,15},");
                Write($"{name_employee,15},");
                Write($"{Surname_employee,15},");
                Write($"{lastname_employee,15},");

            }
        }
        
    }





