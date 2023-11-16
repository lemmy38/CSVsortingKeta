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


        static void Main()
        {
            //link the text file to read as a string
            {
                string filePath = @"D:\c#learning\sorting.txt";


                // Convert the text file into a list

                List<Customer> customers = new List<Customer>();


                /*user input to select and filter fields option 1. Firstname 2.Lastname 3.Date of Birthday
                once the user chooses an option only the select data should be printed to console */

                Console.WriteLine("Select sorting option (1: First Name, 2: LastName, 3: Date of Birth):");



                //read the string, datetime format yyyy-dd-MM


                {

                    string[] items = File.ReadAllLines(filePath);


                    foreach (string item in items)
                    {
                        items = item.Split(','); // split the data at the comma 

                        if (items.Length >= 3 && DateTime.TryParseExact(items[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                        {


                            customers.Add(new Customer
                            {
                                FirstName = items[0],
                                LastName = items[1],
                                DateOfBirth = dateOfBirth,
                            });
                        }

                    }

                    //Apply sorting according to user choice
                    int sortingOption = 0;
                    if (sortingOption == 1)
                        customers = customers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ThenBy(c => c.DateOfBirth).ToList();
                    else if (sortingOption == 2)
                        customers = customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ThenBy(c => c.DateOfBirth).ToList();
                    else if (sortingOption == 3)
                        customers = customers.OrderBy(c => c.DateOfBirth).ToList();

                    customers = customers.Where(c => c.DateOfBirth != DateTime.MinValue).ToList();

                    Console.WriteLine("Sorted and filtered customer data:");

                    for (int i = 0; i < customers.Count; i++) // used var to enable reading different data types
                    {
                        Customer customer = customers[i];
                        Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.DateOfBirth:yyyy-MM-dd}");



                        // had to comment out the else because can'nt start  else with a statement

              //  else
                        
                           // Console.WriteLine("Invalid sorting option. Please enter 1, 2, or 3. You entered: " + sortingOption.ToString());
                        



                        //List<Customer> customers = ReadCustomersFromCsv(filePath);

                        //lines = File.ReadAllLines(filePath).ToList();
                        Console.ReadLine();

                    }


                }

            }

        }
    }
}









