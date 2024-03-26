using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    internal class CustomEmumerable : IEnumerable<int>, IEnumerator<int>
    {
        int position = -1;
        public int Current => this.position;
        object IEnumerator.Current => Current;

        public CustomEmumerable()
        {
            List<int> list = new List<int>();
        }
        public void Dispose() { Console.WriteLine("Вывод закончился."); }

        
        public IEnumerator<int> GetEnumerator()
        {
            return (IEnumerator<int>)this;
        }

        public bool MoveNext()
        {
            if(position < 10)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomEmumerable();
        }
    }
}
