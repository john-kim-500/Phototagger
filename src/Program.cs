using Phototagger.UserOptions;
using System;
namespace Phototagger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IOptionRunner runner = OptionRunnerFactory.Build(args);
                runner.Run();
            }
            catch (ArgumentException)
            {
                Console.Write(OptionRunnerFactory.Usage());
            }
        }
    }
}
