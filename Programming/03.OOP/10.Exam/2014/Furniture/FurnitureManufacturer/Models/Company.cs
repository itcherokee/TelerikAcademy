using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class Company : ICompany
    {
        private readonly ICollection<IFurniture> furnitures;
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length >= 5)
                    {
                        this.name = value;
                    }
                    else
                    {
                        throw new ArgumentException("Name cannot be with less than 5 symbols!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Name cannot be null, empty or only white spaces!");
                }
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length == 10)
                    {
                        if (value.Any(char.IsLetter))
                        {
                            throw new ArgumentException("Registration Number must contains only digits!");
                        }

                        this.registrationNumber = value;
                    }
                    else
                    {
                        throw new ArgumentException("Registration Number must be exactly 10 symbols!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Registration Number cannot be null, empty or only white spaces!");
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures.ToList().AsReadOnly();
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture != null)
            {
                this.furnitures.Add(furniture);
            }
            else
            {
                throw new ArgumentNullException("It is not allowed to add 'null' as a furniture!");
            }
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture != null)
            {
                if (this.Furnitures.Contains(furniture))
                {
                    this.furnitures.Remove(furniture);
                }
            }
            else
            {
                throw new ArgumentNullException("It is not allowed to try to remove furniture with 'value' null!");
            }

        }

        public IFurniture Find(string model)
        {
            if (model != null)
            {
                return this.Furnitures.FirstOrDefault(x => String.Equals(x.Model, model, StringComparison.OrdinalIgnoreCase));
            }

            throw new ArgumentNullException("You can not search furniture by 'null'!");
        }

        public string Catalog()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString(CultureInfo.InvariantCulture) : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count != 0)
            {
                var sortedCatalog = this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
                output.Append(Environment.NewLine);
                output.AppendFormat(string.Join("\n", sortedCatalog));
            }

            return output.ToString();
        }
    }
}
