namespace EvolveSharp.Reporters
{
    public class VoidReporter : IReporter
    {
        public void ReportLine(string message){}

        public void ReportLine(string message, params object[] p){}
    }
}