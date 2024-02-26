using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    internal interface IBits
    {
        public bool GetBits(int num);
        public void SetBits(int num, bool value);

    }
}
