using System;

namespace EvolveSharp.Reporters
{
    public class ConsoleReporter: IReporter
    {
        public void ReportLine(string message)
        {
            Console.WriteLine(message);
        }

        public void ReportLine(string message, params object[] p )
        {
            Console.WriteLine(message, p);
        }
    }
}