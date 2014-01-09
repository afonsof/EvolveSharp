namespace EvolveSharp.Reporters
{
    public interface IReporter
    {
        void ReportLine(string message);
        void ReportLine(string message, params object[] p);
    }
}