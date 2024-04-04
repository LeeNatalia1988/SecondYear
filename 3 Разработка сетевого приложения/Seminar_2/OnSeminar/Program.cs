namespace OnSeminar
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main start: {Thread.CurrentThread.ManagedThreadId}");
            var task = Method01();
            var result1 = await Method02();
            Console.WriteLine("Method2 End");
            await Task.Delay(5000);
            Console.WriteLine($"Main end: {Thread.CurrentThread.ManagedThreadId}");
        }

        static async Task<int> Method01()
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                count++;
                Console.WriteLine(count);
                Thread.Sleep(10000);
                Console.WriteLine($"Method01 thread : {Thread.CurrentThread.ManagedThreadId}");
            }
            throw new Exception();
            return count;
        }

        static async Task<int> Method02()
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                count++;
                Console.WriteLine(count);
                Console.WriteLine($"Method02 thread : {Thread.CurrentThread.ManagedThreadId}");
            }
            return count;
        }
    }
}
