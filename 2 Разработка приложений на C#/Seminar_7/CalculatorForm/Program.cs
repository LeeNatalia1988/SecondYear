namespace CalculatorForm
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Графика*/

            ApplicationConfiguration.Initialize();
            Application.Run(new MyCalculator());
        }
    }
}
