using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1 реализовать интерфейс из прошлой задачи применив его к классу bits из примера предыдущей лекции.
 2 Оптимизировать для long*/

namespace OnSeminar
{
    internal class Bits : IBits
    {
        public long Value { get; private set; } = 0;
        public Bits(/*byte везде меняем на long*/long value) 
        {
            this.Value = value;
            size = sizeof(long);
        }
        public bool GetBits(int index)
        {
            return this[index];
        }

        private readonly int size = 0;

        //public static implicit operator long(Bits b) => (long)b.Value;
        //public static explicit operator Bits(long b) => new Bits(b);

        //public static explicit operator long(Bits b) => (long)b.Value;
        //explicit нужен, чтобы класс преобразовать в другой тип
        public static explicit operator long(Bits b) => b.Value;
        //implicit нужен, чтобы другой тип преобразовать в класс
        public static implicit operator Bits(long b) => new Bits(b);

        public void SetBits(int index, bool value)
        {
            this[index] = value;
        }
        public bool this[int index]
        {
            get
            {
                if (index > size || index < 0)
                    return false;
                return ((Value >> index) & 1) == 1;
            }

            set
            {
                if (index > size || index < 0)
                    return;
                if (value == true)
                    Value = (long)(Value | (1 << index));
                else
                {

                    /*var mask = (byte)(1 << index);
                    mask = (byte)(0xffffffffffffffff - не работает, так как ^ для long невозможна, поэтому ~, см ниже, смысл тот же
                    /*0xff - маска для 1 байт/ ^ mask);
                    Value &= (byte)(Value & mask);*/

                    var mask = (long)(1 << index);
                    mask = ~mask;
                    Value &= (long)(Value & mask);
                }
            }
        }
    }
}
