using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompareUI
{
    public class Parent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Child> children { get; set; }
    }
}
