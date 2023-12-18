using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

namespace TestSimpleDB
{

    class MainClass
    {


        static Random rnd = new Random();

        static GenerateData gendata = new GenerateData();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            List<Employee> emp;
            List<Subdivision> sub;
            List<staff> staffs = new List<staff>();
            List<Employee_Subdivision> emp_sub;
            List<Employee_staffs> emp_st;

            (emp, sub, staffs, emp_sub, emp_st) = CreateDB4empoyee();

            PrintEmployees(emp);
            PrintSubdivisions(sub);
            emp_sub = create1task(emp, sub);
            PrintEmployee_Subdivision(emp_sub);
            sort(emp_sub, sub);
            Printstaff(staffs);
            emp_st = task3(emp);
            PrintStaffs(emp_st);
            sort1(emp_st, staffs);

            ReadLine();
        }
        static List<Employee_Subdivision> create1task(List<Employee> employees, List<Subdivision> subdivisions)
        {
            List<Employee_Subdivision> emp_sub = new List<Employee_Subdivision>();
            for (int i = 0; i < gendata.getNamesCount(); i++)
            {
                ;
                emp_sub.Add(new Employee_Subdivision(employees[i].getID(), employees[i].getID(),
                    employees[i].getunit(),
                    employees[i].getName(),
                    employees[i].getSurname(),
                    employees[i].getlast_name(),
                    employees[i].dates_birthday()));


            }
            return emp_sub;
        }
        static (List<Employee>, List<Subdivision>, List<staff>, List<Employee_Subdivision>, List<Employee_staffs>) CreateDB4empoyee()
        {
            List<Employee> employees = new List<Employee>();
            List<Subdivision> subdivisions = new List<Subdivision>();
            List<staff> staffs = new List<staff>();
            List<Employee_Subdivision> emp_sub = new List<Employee_Subdivision>();
            List<Employee_staffs> emp_st = new List<Employee_staffs>();


            for (byte i = 0; i < gendata.getNamesCount(); i++)
            {
                DateTime dates_birthday = new DateTime(rnd.Next(1959, 2000), rnd.Next(12) + 1, rnd.Next(29) + 1, rnd.Next(9, 17), rnd.Next(60), rnd.Next(60));
                DateTime dt_join = new DateTime(rnd.Next(2000, 2005), rnd.Next(12) + 1, rnd.Next(29) + 1, rnd.Next(9, 17), rnd.Next(60), rnd.Next(60));
                DateTime dt_leave = new DateTime(rnd.Next(2005, 2021), rnd.Next(12) + 1, rnd.Next(29) + 1, rnd.Next(9, 17), rnd.Next(60), rnd.Next(60));
                int k = rnd.Next(4);
                int m = rnd.Next(13);


                if (k == 0)
                {
                    m = rnd.Next(9);
                    employees.Add(new Employee(
                                (byte)(i + 1),
                                gendata.getSurname(i),
                                gendata.getName(i),
                                gendata.getLast_Names(i),
                                gendata.getGender(i),
                                dates_birthday,
                                gendata.getresidence_addresses(i),
                                gendata.getUnit(k),
                                gendata.getPosition(m),
                                dt_join,
                                dt_leave));
                }
                else if (k == 1)
                {
                    m = rnd.Next(4, 10);
                    employees.Add(new Employee(
                                (byte)(i + 1),
                                gendata.getSurname(i),
                                gendata.getName(i),
                                gendata.getLast_Names(i),
                                gendata.getGender(i),
                                dates_birthday,
                                gendata.getresidence_addresses(i),
                                gendata.getUnit(k),
                                gendata.getPosition(m),
                                dt_join,
                                dt_leave));
                }
                else if (k == 2)
                {
                    m = rnd.Next(4, 11);
                    employees.Add(new Employee(
                                (byte)(i + 1),
                                gendata.getSurname(i),
                                gendata.getName(i),
                                gendata.getLast_Names(i),
                                gendata.getGender(i),
                                dates_birthday,
                                gendata.getresidence_addresses(i),
                                gendata.getUnit(k),
                                gendata.getPosition(m),
                                dt_join,
                                dt_leave));

                }
                else
                {
                    m = rnd.Next(10, 12);
                    employees.Add(new Employee(
                                (byte)(i + 1),
                                gendata.getSurname(i),
                                gendata.getName(i),
                                gendata.getLast_Names(i),
                                gendata.getGender(i),
                                dates_birthday,
                                gendata.getresidence_addresses(i),
                                gendata.getUnit(k),
                                gendata.getPosition(m),
                                dt_join,
                                dt_leave));
                }

            }
            for (byte k = 0; k < 4; k++)
            {


                subdivisions.Add(new Subdivision(
                    (byte)(k + 1),
                    gendata.getUnit(k)));
            }
            for (byte v = 0; v < 3; v++)
            {


                staffs.Add(new staff(
                    (byte)(v + 1),
                    gendata.getStaff(v)));
            }



            return (employees, subdivisions, staffs, emp_sub, emp_st);
        }
        static void PrintEmployees(List<Employee> ListOfEmployee)
        {
            foreach (Employee S in ListOfEmployee)
            {
                S.printEmployee();
                WriteLine();
            }
            WriteLine();
        }
        static void PrintSubdivisions(List<Subdivision> ListOfSubdivisions)
        {
            foreach (Subdivision S in ListOfSubdivisions)
            {
                S.printSubdivision();
                WriteLine();
            }
            WriteLine();

        }
        static void PrintEmployee_Subdivision(List<Employee_Subdivision> emp_sub)
        {
            foreach (Employee_Subdivision S in emp_sub)
            {
                S.print_Employee_Subdivision();
                WriteLine();
            }
            WriteLine();

        }
        static void PrintStaffs(List<Employee_staffs> emp_st)
        {
            foreach (Employee_staffs S in emp_st)
            {
                S.print_Employee_Staff();
                WriteLine();
            }
            WriteLine();

        }
        static void Printstaff(List<staff> staffs)
        {
            foreach (staff S in staffs)
            {
                S.printstaff();
                WriteLine();
            }
            WriteLine();

        }
        static void sort(List<Employee_Subdivision> emp_sub, List<Subdivision> subdivisions)
        {
            bool cnt = true;
            while (cnt)
            {
                int sum = 0;
                double sump = 0;
                double sum1 = 0;
                WriteLine("input ID of unit : "); int x = int.Parse(ReadLine());
                if (x == 1)
                {

                    string unit = subdivisions[0].getname_of_the_unit();
                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_sub[i].name_subdivisions() == unit)
                        {
                            WriteLine($"{emp_sub[i].getID_emp(),3}{emp_sub[i].name_employees(),3}{emp_sub[i].Surname_employees(),3}");
                            sum++;
                            int r = 2021 - emp_sub[i].date_birthday_emp.Year;
                            sump += r;

                        }
                    }
                    sum1 = sump / sum;
                    Round(sum1, 3);
                    WriteLine("avg years old :" + sum1);
                }
                else if (x == 2)
                {
                    string unit = subdivisions[1].getname_of_the_unit();

                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_sub[i].name_subdivisions() == unit)
                        {
                            WriteLine($"{emp_sub[i].getID_emp(),5}{emp_sub[i].name_employees(),5}{emp_sub[i].Surname_employees(),5}");
                            sum++;
                            int r = 2021 - emp_sub[i].date_birthday_emp.Year;
                            sump += r;
                        }
                    }
                    sum1 = sump / sum;
                    Round(sum1, 3);
                    WriteLine("avg years old :" + sum1);
                }
                else if (x == 3)
                {
                    string unit = subdivisions[2].getname_of_the_unit();

                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_sub[i].name_subdivisions() == unit)
                        {
                            WriteLine($"{emp_sub[i].getID_emp(),5}{emp_sub[i].name_employees(),5}{emp_sub[i].Surname_employees(),5}");
                            sum++;
                            int r = 2021 - emp_sub[i].date_birthday_emp.Year;
                            sump += r;
                        }
                    }
                    sum1 = sump / sum; Round(sum1, 3);
                    WriteLine("avg years old :" + sum1);
                }
                else if (x == 4)
                {
                    string unit = subdivisions[3].getname_of_the_unit();

                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_sub[i].name_subdivisions() == unit)
                        {
                            WriteLine($"{emp_sub[i].getID_emp(),5}{emp_sub[i].name_employees(),5}{emp_sub[i].Surname_employees(),5}");
                            sum++;
                            int r = 2021 - emp_sub[i].date_birthday_emp.Year;
                            sump += r;
                        }
                    }
                    sum1 = sump / sum;
                    Round(sum1, 3);
                    WriteLine("avg years old :" + sum1);
                }
                else
                {
                    cnt = false;
                }
            }
        }
        static List<Employee_staffs> task3(List<Employee> employees)
        {
            List<Employee_staffs> emp_st = new List<Employee_staffs>();
            for (int i = 0; i < gendata.getNamesCount(); i++)
            {

                emp_st.Add(new Employee_staffs(employees[i].getID(),
                    employees[i].getposition(),
                    employees[i].getName(),
                    employees[i].getSurname(),
                    employees[i].getlast_name()
                    ));


            }
            return emp_st;
        }
        static void sort1(List<Employee_staffs> emp_st, List<staff> staffs)
        {
            
            bool cnt = true;
            while (cnt)
            {
                WriteLine("input ID of staff : "); int p = int.Parse(ReadLine());
                if (p == 1)
                {

                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_st[i].name_position == "Професор")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Доцент")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Завідувач_кафедри")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Асистент")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }  
                    }
                }
                else if (p == 2)
                {
                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_st[i].name_position == "Завідувач_навчальної_лабораторії")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Cтарший_лаборант_кафедри")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Cтарший_лаборант_навчальної_лабораторії")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Завідувач_відділу")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Медичний_працівник")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                    }
                }
                else if (p == 3)
                {
                    for (int i = 0; i < gendata.getSurnamesCount(); i++)
                    {
                        if (emp_st[i].name_position == "Завідувач_складу")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Прибиральниця")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                        else if (emp_st[i].name_position == "Сантехнік")
                        {
                            WriteLine($"{emp_st[i].getID_emp_St(),5}{emp_st[i].name_employees(),5}{emp_st[i].Surname_employees(),5}");
                        }
                    }
                }
                else
                {
                    cnt = false;
                }
            }
        }
    }
}
        
