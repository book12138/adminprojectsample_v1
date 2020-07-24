using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMap.MappingAttribute
{
    public class AtMappingNameAttribute : Attribute
    {
        public string Name { get; set; }

        public AtMappingNameAttribute(string name) => this.Name = name;
    }
}
