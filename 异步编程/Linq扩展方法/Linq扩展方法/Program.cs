using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq扩展方法
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


            IEnumerable<Employee> items1= employees.Where(a => a.Age > 45);
            foreach (var i in items1)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine(items1.Count());
            Console.WriteLine(items1.Count(e=>e.Age>50));
            Console.WriteLine(items1.Count(e=>e.Age>50&&e.Salary> 78430));
            Console.WriteLine(items1.Any(e=>e.Salary>80000));
            Console.WriteLine(items1.Any(e=>e.Salary>800000));
            //有且只有一条满足要求的数据，没有满足条件的将会报错
            Console.WriteLine(items1.Single(e=>e.Name== "Employee_15"));
            //最多只有一条满足要求的数据，如果没有满足条件的数据，将会返回一个默认值null
            Console.WriteLine(items1.SingleOrDefault(e=>e.Name== "Employee_17"));
            //有多条满足条件的数据，会报错
            //Console.WriteLine(items1.SingleOrDefault());

            //多排序规则,第一个条件相同，在按第二个条件排序
            var employeeorder = items1.OrderBy(e => e.Age).ThenBy(e => e.Salary);
            foreach (var e in employeeorder)
            {
                Console.WriteLine(e);
            }

            #region 打印结果
            // Id = 5,Name = Employee_5,Age = 46,Gender = False,Salary = 64421
            // Id = 2,Name = Employee_2,Age = 48,Gender = True,Salary = 92646
            // Id = 12,Name = Employee_12,Age = 48,Gender = False,Salary = 99581
            // Id = 15,Name = Employee_15,Age = 52,Gender = True,Salary = 81936
            // Id = 3,Name = Employee_3,Age = 53,Gender = False,Salary = 78430
            // Id = 8,Name = Employee_8,Age = 54,Gender = False,Salary = 66853
            // Id = 6,Name = Employee_6,Age = 56,Gender = True,Salary = 47452
            // Id = 4,Name = Employee_4,Age = 56,Gender = True,Salary = 92825
            #endregion


            //限制结果集，获取部分数据
            
            //Skip(n)跳过n条数据，
            //Take(n)获取n条数据
            Console.WriteLine("跳过2条数据，再获取3条数据");
            var employeeByOrder = items1.Skip(2).Take(3);
            foreach (var e in employeeByOrder)
            {
                Console.WriteLine(e);
            }

            //聚合函数
            Console.WriteLine("聚合函数");

            var a = items1.Max(a => a.Age);
            Console.WriteLine("最大年龄"+a);
            var avaSalary = items1.Average(a => a.Salary);
            Console.WriteLine("平均工资"+avaSalary);

            IEnumerable<IGrouping<int, Employee>> items = items1.GroupBy(e => e.Age);
            foreach (var item in items)
            {
                Console.WriteLine("年龄:"+item.Key);
                Console.WriteLine("最大工资："+item.Max(e=>e.Salary));
                foreach (var i in item)
                {
                    Console.WriteLine("信息："+i);
                }

                Console.WriteLine("-------------------------------------");
            }

            //投影
            //把集合中的每一项转换为另外一种类型
            IEnumerable<int> ages = items1.Select(e => e.Age);
            foreach (var age in ages)
            {
                Console.WriteLine(age);
            }
            IEnumerable<string> stingItems=items1.Select(e => e.Name+":"+e.Salary);
            foreach (var s in stingItems)
            {
                Console.WriteLine(s);
            }
            IEnumerable<string> genderItems = items1.Select(e => e.Gender? "男":"女");
            foreach (var s in genderItems)
            {
                Console.WriteLine(s);
            }

            IEnumerable<Dog> dogs = items1.Select(e => new Dog() { Id = e.Id, Name = e.Name });
            foreach (var dog in dogs)
            {
                Console.WriteLine("dog:"+dog.Name+"-"+dog.Id);
            }

            //匿名类型
            var cat = new { Id="1",Name="Cat"};
            //投影与匿名类型
            var students = items1.Select(e => new { XingMing = e.Name, Id = e.Id });
            foreach (var student in students)
            {
                Console.WriteLine("学生："+student.Id+","+student.XingMing);
            }

            var lastItems = items1.GroupBy(e => e.Age).Select(g => new
            {
                Nianling = g.Key, MaxSalary = g.Max(e => e.Age),
                MinSalary = g.Min(e => e.Salary), RenShu = g.Count()
            });
            foreach (var lastItem in lastItems)
            {
                Console.WriteLine(lastItem.MaxSalary+","+lastItem.MinSalary+","+lastItem.Nianling+","+lastItem.RenShu);
            }

            //获取Id>2的数据，然后按照Age分组，并且把分组按照Age排序，然后取出前3条，最后再投影取得年龄、人数、平均工资
            var thelastItems = employees.Where(e => e.Id > 2).GroupBy(e => e.Age).OrderByDescending(g => g.Key).Take(3)
                .Select(g => new { NianLing = g.Key, RenShu = g.Count(), Average = g.Average(e => e.Salary) });
            foreach (var thelastItem in thelastItems)
            {
                Console.WriteLine("年龄："+thelastItem.NianLing+","+"人数："+thelastItem.RenShu+"平均工资："+thelastItem.Average);
            }
        }
    }
}
