using System;

class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Designation { get; set; }
    public int Experience { get; set; }
    public double Salary { get; set; }
    public string City { get; set; }

    public Employee(int employeeId, string name, string department,
        string designation, int experience, double salary, string city)
    {
        EmployeeId = employeeId;
        Name = name;
        Department = department;
        Designation = designation;
        Experience = experience;
        Salary = salary;
        City = city;
    }

    public void Display()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Employee ID : {EmployeeId}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Department  : {Department}");
        Console.WriteLine($"Designation : {Designation}");
        Console.WriteLine($"Experience  : {Experience} Years");
        Console.WriteLine($"Salary      : {Salary}");
        Console.WriteLine($"City        : {City}");
    }
}