using System;
using System.Collections.Generic;

namespace composit
{
    abstract class employee
    {
        public string name { get; set; }
        public abstract void addsubordinate(employee employee);
        public abstract void Removesubordinate(employee employee);
        public abstract void display();
    }

    class manager : employee
    {
        public List<employee> employes { get; set; } = new List<employee>();
        public override void addsubordinate(employee employee)
        {
                employes.Add(employee);
                if (employes.Count > 4)
                {
                    throw new Error1();
                }
        }
        public override void Removesubordinate(employee employee)
        {
            employes.Remove(employee);
        }
        public override void display() 
        {
            Console.WriteLine(name);
            foreach (var emp in employes)
            {
                emp.display();
            }
        }
    }

    class Operator: employee
    {
       
        public override void Removesubordinate(employee employee)
        {
            employee.Removesubordinate(employee);
        }
        public override void addsubordinate(employee employee)
        {
            employee.addsubordinate(employee);
           
        }
        public override void display()
        {
            Console.WriteLine(name);
        }
        
    }

    class director : employee
    {
        public List<employee> employesd { get; set; } = new List<employee>();
        public override void addsubordinate(employee employee)
        {
            employesd.Add(employee);
            if (employesd.Count > 3)
            {
                throw new Error3();
            }
            
        }

       
        public override void Removesubordinate(employee employee)
        {
           if (employesd.Count>2)
            {
                employesd.Remove(employee);
            }
        }
        public override void display()
        {
            Console.WriteLine(name);
            foreach (var emp in employesd)
            {
                emp.display();
            }
        }
    }

    public class Error3 : Exception
    {
        public override string Message => "Директор может только 3 менеджеров взять на работу ";
        
    }
    public class Error1 : Exception
    {
        public override string Message => "Менеджер не может иметь больше 4 операторов ";

    }
    public class Error2 : Exception
    {
        public override string Message => "Оператор не может снова добавлен ";

    }





    class Program
    {
        static void Main(string[] args)
        {
            employee manager = new manager() { name = "Alex" };
            employee manager1 = new manager() { name = "Tom" }; 
            employee manager2 = new manager() { name = "Ben" };
            employee manager4 = new manager() { name = "Nurbol" };
            director director = new director();
            try
            {
                Console.WriteLine("Managers:");
                director.addsubordinate(manager);
                director.addsubordinate(manager1);
                director.addsubordinate(manager2);
                director.addsubordinate(manager4);
                director.display();


            }
            catch (Error3 e)
            {
                Console.WriteLine(e.Message);

            }
            employee operator1 = new Operator() { name = "---John" };
            employee operator2 = new Operator() { name = "---Billy" };
            employee operator3 = new Operator() { name = "---Azamat" };
            try
            {
                Console.WriteLine("Manager:");
                manager.addsubordinate(operator1);
                manager.addsubordinate(operator2);
                manager.addsubordinate(operator3);
                manager.display();
            }
            catch (Error1 f)
            {
                Console.WriteLine(f.Message);
            }
            employee operator4 = new Operator() { name = "---Люси" };
            employee operator5 = new Operator() { name = "---Джони" };
            employee operator6 = new Operator() { name = "---Иван" };
            employee operator7 = new Operator() { name = "---Vanya" };
            try
            {
                Console.WriteLine("Manager:");
                manager1.addsubordinate(operator4);
                manager1.addsubordinate(operator5);
                manager1.addsubordinate(operator6);
                manager1.addsubordinate(operator7);
                manager1.display();
            }
            catch (Error1 g)
            {

                Console.WriteLine(g.Message);
            }
            try
            {
                manager1.addsubordinate(operator7);
            }
            catch (Error2 c)
            {

                Console.WriteLine(c.Message);
            }

        }
    }
}
