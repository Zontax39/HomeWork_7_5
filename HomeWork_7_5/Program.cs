using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.ShowEndedExpiration();
        }

        class Storage
        {
            private List<CannedMeat> _cannedMeats;
            private int _currentYear;
            public Storage()
            {
                _currentYear = 2022;
                _cannedMeats = new List<CannedMeat>();
                _cannedMeats.Add(new CannedMeat("Fish", 2022, 2023));
                _cannedMeats.Add(new CannedMeat("Beef", 2020, 2022));
                _cannedMeats.Add(new CannedMeat("Pork", 2019, 2020));
                _cannedMeats.Add(new CannedMeat("Buck", 2018, 2019));
                _cannedMeats.Add(new CannedMeat("Beef and Buck", 2017, 2023));
            }

            public void ShowEndedExpiration()
            {
                var expiredProducts = _cannedMeats.Where(cannedMeat => cannedMeat.StorageLife < _currentYear);
                
                foreach(var expiredProduct in expiredProducts)
                {
                    expiredProduct.ShowInfo();
                }
            }
        }

        class CannedMeat
        {
            public string Name { get; private set; }
            public int YearOfProduction { get; private set; }
            public int StorageLife { get; private set; }

            public CannedMeat(string name, int yearOfProduction, int storageLife)
            {
                Name = name;
                YearOfProduction = yearOfProduction;
                StorageLife = storageLife;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"{Name}-Год производства:{YearOfProduction} - Срок годности: {StorageLife}");
            }
        }
    }
}
