using CellarManager.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CellarManager
{
    internal class Tui
    {

        private ILogic _logic;
        public Tui(ILogic logic)
        {
            _logic = logic;
        }

        internal void Start()
        {
            Console.WriteLine("Welcome to Styx Bistrò");

            while (true)
            {
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1) Consult our drink list");
                Console.WriteLine("2) Add new WINE to the list");
                Console.WriteLine("3) Add new BEER to the list");
                Console.WriteLine("4) Quit");
                string choiche = Console.ReadLine();

                if (choiche != null)
                {
                    var choiceNumeber = int.Parse(choiche);
                    if (choiceNumeber > 0 && choiceNumeber <= 4)
                    {
                        switch (choiceNumeber)
                        {
                            case 1:
                                {
                                List<Beverage> beverages = _logic.GetAllBeverages();
                                    string report = "Here's our selection \n";
                                foreach (var beverage in beverages)
                                {
                                    var type = beverage.GetType().Name;
                                        if (type == "Wine")
                                        {
                                            Wine wine = (Wine)beverage; 
                                            report += type + " " + wine.Name + " " + wine.Degree + "° " + wine.Type + "\n";
                                        } else
                                        {
                                            Beer beer = (Beer)beverage;
                                            report += type + " " + beer.Name + " " + beer.Degree + "° " + beer.Style + "\n";
                                        }
                                }
                                    Console.WriteLine(report);
                                break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("What's the wine Name?");
                                    string name= Console.ReadLine();
                                    Console.WriteLine("What's the wine Alchoolic Percentage?");
                                    double degrees = double.Parse(Console.ReadLine());
                                    Console.WriteLine("What's the wine Vite?");
                                    string vite = Console.ReadLine();
                                    Console.WriteLine("What's the wine Color?");
                                    string color = Console.ReadLine();
                                    Console.WriteLine($@"Wine Name: {name}
Wine Degrees: {degrees}°
Wine Vite: {vite}
Wine Name: {color}
Is it correct? (Y/n)");
                                    string response = Console.ReadLine().ToLower();
                                    if (response == "y")
                                    {
                                        _logic.AddWine(name, degrees, vite, color);
                                        Console.WriteLine("New Wine added correctly");
                                        break;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("What's the beer Name?");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("What's the beer Alchoolic Percentage?");
                                    double degrees = double.Parse(Console.ReadLine());
                                    Console.WriteLine("What's the beer Style?");
                                    string style = Console.ReadLine();
                                    Console.WriteLine($@"Beer Name: {name}
Beer Degrees: {degrees}°
Beer Style: {style}
Is it correct? (Y/n)");
                                    string response = Console.ReadLine().ToLower();
                                    if (response == "y")
                                    {
                                        _logic.AddBeer(name, degrees, style);
                                        Console.WriteLine("New Beer added correctly");
                                        break;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Are you sure? (y/n)");
                                    string response = Console.ReadLine().ToLower();
                                    if (response == "y")
                                    {
                                        return;
                                    }
                                    break;
                                }    
                                
                        }
                    }
                    else
                    {
                        Console.WriteLine("Select a valid choice");
                    }

                }
                else
                {
                    Console.WriteLine("Select a valid choice");
                }
            }
        }
    }
}
