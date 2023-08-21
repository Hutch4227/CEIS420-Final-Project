using System;
using System.Collections.Generic;

class SalesPerson
{
    public string Name { get; }
    public string Title { get; }
    private List<double> sales;

    public SalesPerson(string name, string title)
    {
        Name = name;
        Title = title;
        sales = new List<double>();
    }

    public void AddSale(double sale)
    {
        sales.Add(sale);
    }

    public IEnumerable<double> IterSales()
    {
        return sales;
    }
}

class SalesReport
{
    static void Main(string[] args)
    {
        List<SalesPerson> salesPeople = new List<SalesPerson>();
        Console.WriteLine("Sales Report:");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Please enter sales person name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter your sales person title: ");
            string title = Console.ReadLine();

            SalesPerson salesPerson = new SalesPerson(name, title);
            Console.Write("How many sales values will you enter for this sales person? ");
            int numSales = int.Parse(Console.ReadLine());

            for (int j = 0; j < numSales; j++)
            {
                Console.Write($"Please enter sales figure for {name}: ");
                double sale = double.Parse(Console.ReadLine());
                salesPerson.AddSale(sale);
            }

            salesPeople.Add(salesPerson);
            Console.WriteLine();
        }

        double totalCompanySales = 0;
        foreach (SalesPerson person in salesPeople)
        {
            Console.WriteLine($"Sales person: {person.Name}");
            double totalSales = 0;
            double minSale = double.MaxValue;
            double maxSale = double.MinValue;

            foreach (double sale in person.IterSales())
            {
                totalSales += sale;
                minSale = Math.Min(minSale, sale);
                maxSale = Math.Max(maxSale, sale);
            }

            double averageSales = totalSales / person.IterSales().Count();
            totalCompanySales += totalSales;

            Console.WriteLine($"Total Sales: ${totalSales:f2}");
            Console.WriteLine($"Min Sales: ${minSale:f2}");
            Console.WriteLine($"Max Sales: ${maxSale:f2}");
            Console.WriteLine($"Average Sales: ${averageSales:f2}");
            Console.WriteLine("----------------------------------------------------\n");
        }

        Console.WriteLine($"Company total sales: ${totalCompanySales:f2}");
    }
}
