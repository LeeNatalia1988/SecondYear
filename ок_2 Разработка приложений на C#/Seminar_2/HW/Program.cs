namespace HW
{
    internal class Program
    {
        public static void Main(string[] args) {

            //для long:
            //Console.WriteLine(long.MaxValue);
            Bits bits = new Bits(9223372036854775807);
            long num = (long)bits;
            Console.WriteLine(num);
            long num1 = 9223372036854775807; 
            Bits bits1 = num1;
            Console.WriteLine(bits1.Value);

            //для int
            //Console.WriteLine(int.MaxValue);
            Bits bits2 = new Bits(2147483647);
            int num2 = (int)bits2;
            Console.WriteLine(num2);
            int num3 = 2147483647;
            Bits bits3 = num3;
            Console.WriteLine(bits3.Value);

            //для byte
            //Console.WriteLine(byte.MaxValue);
            Bits bits4 = new Bits(255);
            byte num4 = (byte)bits4;
            Console.WriteLine(num4);
            byte num5 = 255;
            Bits bits5 = num5;
            Console.WriteLine(bits5.Value);


        }
    }
}
