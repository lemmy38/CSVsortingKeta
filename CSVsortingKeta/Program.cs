using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


namespace CSVsortingKeta
{
    class Program
    {

      public  static void Main ()
        {
            //link the text file to read as a string
            {
                string filePath = @"D:\C#learning\sorting.txt";

                //string[] lines = File.ReadAllLines(filePath);

                // Convert the text file into a list
                List<string> lines = new List<string>();
                List<Customer> customers = new List<Customer>();

                lines = File.ReadAllLines(filePath).ToList();
                /*user input to choose filtered field option 1. Firstname 2.Lastname 3.Date of Birthday
                once the user choose an option the only the select deta show be printed to console */
                {
                    Console.WriteLine("Select sorting option (1: First Name, 2: LastName, 3: Date of Birth):");

                    Console.ReadLine();

                    if (int.TryParse(Console.ReadLine(), out int sortingOption) && sortingOption >= 0 && sortingOption <= 2)
                    {
                        //                  List<Customer> customers = ReadCustomersFromCsv(filePath);

                        if (sortingOption == 1)
                            customers = customers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ThenBy(c => c.DateOfBirth).ToList();
                        else if (sortingOption == 2)
                            customers = customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ThenBy(c => c.DateOfBirth).ToList();
                        else if (sortingOption == 3)
                            customers = customers.OrderBy(c => c.DateOfBirth).ToList();

                        customers = customers.Where(c => c.DateOfBirth != DateTime.MinValue).ToList();

                        Console.WriteLine("Sorted and filtered customer data:");
                        foreach (var customer in customers) // used var to enable reading different data types
                        {
                            Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.DateOfBirth:yyyy-MM-dd}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid sorting option. Please enter 1, 2, or 3. You entered: " + sortingOption.ToString());

                    }


                    foreach (string line in lines)
                    {
                        string[] items = line.Split(','); // split the data at the comma 

                        if (line.Length >= 3 && DateTime.TryParseExact(lines[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                        {


                            customers.Add(new Customer
                            {
                                FirstName = lines[0],
                                LastName = lines[1],
                                DateOfBirth = dateOfBirth,
                            });
                            {
                                {


                                    Console.ReadLine();

                                }
                            }
                        }
                    }
                }
            }
        }
    }

}




                        

      
        
    
