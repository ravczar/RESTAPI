using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer.Models
{
    public class Item
    {
        private static uint Iterator;
        public uint Id { get; set; }
        public DateTime DateOfProduction { get; set; }

        public Item(DateTime DateOfProduction)
        {
            Id = Iterator++;
            this.DateOfProduction = DateOfProduction;
        }

        public override string ToString() => $"{GetType().Name} = Id:{Id}, Date:{DateOfProduction}, ";
    }
}
