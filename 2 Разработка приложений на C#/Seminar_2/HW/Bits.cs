using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class Bits : IBits
    {
        public long Value { get; private set; } = 0;
        
        public Bits(long value)
        {
            this.Value = value;
        }

        public long GetBits(long value)
        {
            return value;
        }

        public void SetBits(long value)
        {
            this.Value = value;
        }

        /*Реализуйте операторы неявного приведения из long,int,byte в Bits.*/
        //для long
        public static explicit operator long(Bits b) => b.Value;
        public static implicit operator Bits(long b) => new Bits(b);

        //для int
        public static explicit operator int(Bits b) => (int)b.Value;
        public static implicit operator Bits(int b) => new Bits(b);

        //для byte
        public static explicit operator byte(Bits b) => (byte)b.Value;
        public static implicit operator Bits(byte b) => new Bits(b);
    }
}
