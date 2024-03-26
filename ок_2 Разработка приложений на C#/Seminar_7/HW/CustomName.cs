using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    [AttributeUsage(AttributeTargets.Field)]
    
    public class CustomName(string customName) : Attribute
    {
        public string CN { get; set; } = customName;
    }
}
