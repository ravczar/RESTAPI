using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer.Models
{
    public class Car : Item
    {
        public string Model { get; set; }
        public string Brand { get; set; }

        public Car(DateTime dateOfProduction, string model, string brand):base(dateOfProduction)
        {
            this.Model = model;
            this.Brand = brand;
        }

        public override string ToString() => base.ToString() + $" modle:{Model}, brand:{Brand}";
    }
}
