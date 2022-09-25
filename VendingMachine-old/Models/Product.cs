using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    internal class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string SourseImg { get; private set; }

        public Product(int id, string name, string sourseImg)
        {
            Id = id;
            Name = name;
            SourseImg = sourseImg;
        }
    }
}
