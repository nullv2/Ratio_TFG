namespace Ratio.Application.Services.Abstraction
{
    public interface ISimulationProgressReporter
    {
        void ReportProgress(int current, int total, string message);
    }
}
