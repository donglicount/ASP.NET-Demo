using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_查询语法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "Employee_1", Age = 41, Gender = true, Salary = 58217 });
            employees.Add(new Employee { Id = 2, Name = "Employee_2", Age = 48, Gender = true, Salary = 92646 });
            employees.Add(new Employee { Id = 3, Name = "Employee_3", Age = 53, Gender = false, Salary = 78430 });
            employees.Add(new Employee { Id = 4, Name = "Employee_4", Age = 56, Gender = true, Salary = 92825 });
            employees.Add(new Employee { Id = 5, Name = "Employee_5", Age = 46, Gender = false, Salary = 64421 });
            employees.Add(new Employee { Id = 6, Name = "Employee_6", Age = 56, Gender = true, Salary = 47452 });
            employees.Add(new Employee { Id = 7, Name = "Employee_7", Age = 42, Gender = false, Salary = 94322 });
            employees.Add(new Employee { Id = 8, Name = "Employee_8", Age = 54, Gender = false, Salary = 66853 });
            employees.Add(new Employee { Id = 9, Name = "Employee_9", Age = 42, Gender = false, Salary = 79868 });
            employees.Add(new Employee { Id = 10, Name = "Employee_10", Age = 30, Gender = true, Salary = 99941 });
            employees.Add(new Employee { Id = 11, Name = "Employee_11", Age = 27, Gender = false, Salary = 76109 });
            employees.Add(new Employee { Id = 12, Name = "Employee_12", Age = 48, Gender = false, Salary = 99581 });
            employees.Add(new Employee { Id = 13, Name = "Employee_13", Age = 31, Gender = true, Salary = 86610 });
            employees.Add(new Employee { Id = 14, Name = "Employee_14", Age = 42, Gender = false, Salary = 66452 });
            employees.Add(new Employee { Id = 15, Name = "Employee_15", Age = 52, Gender = true, Salary = 81936 });

            var items = employees.Where(e => e.Salary > 3000).OrderBy(e => e.Age)
                .Select(e => new { e.Age, e.Name,Gender= e.Gender ? "男" : "女" });
            foreach (var item in items)
            {
                Console.WriteLine(item.Age+","+item.Name+","+item.Gender);
            }

            var items2=from e in employees
                where e.Salary>3000
                orderby e.Age 
                select new {e.Age,e.Name, Gender=e.Gender?"男":"女"};
            foreach (var item2 in items2)
            {
                Console.WriteLine(item2.Age+","+item2.Name+","+item2.Gender);
            }

            //两种写法效果一致，最终都会编译成相同的代码
        }
    }
}
