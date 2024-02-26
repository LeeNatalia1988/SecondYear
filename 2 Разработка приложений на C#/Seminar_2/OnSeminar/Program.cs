namespace OnSeminar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*IBits ibits = new Bits(99);
            Console.WriteLine(ibits.GetBits(0));
            Bits bits = new Bits(22);

            Console.WriteLine(bits.Value);
            Console.WriteLine(sizeof(long)); - Работает*/

            /*Bits bits = new Bits(55);
            Console.WriteLine(bits.GetBits(0));
            bits.SetBits(0, false);
            Console.WriteLine(bits.Value); - работает*/

            /*Bits bits = new Bits(9223372036854775807);
            Console.WriteLine(bits.GetBits(0));
            bits.SetBits(0, false);
            Console.WriteLine(bits.Value); - работает*/

            //Console.WriteLine(sizeof(long));

            /*
            Bits bits = new Bits(123456);
            //bits[1] = false;
            //Console.WriteLine(bits.Value);
            long num = (long)bits;
            Console.WriteLine(num); 
            //это explicit*/
            
            
            /*long num = 123456; 
            Bits bits = num;
            Console.WriteLine(bits.Value); //это implicit*/

        }
    }
}
