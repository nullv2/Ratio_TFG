using Ratio.Application.DTO;
using Ratio.Application.Enums;
using Ratio.Application.Services.Abstraction;

namespace Ratio.Application.Services
{
    public class SimulationStateService : ISimulationProgressReporter
    {
        public OperativeToSim? Attacker { get; private set; }
        public OperativeToSim? Defender { get; private set; }

        public ActionType ActionType { get; private set; }


        // Progress state
        public int ProgressCurrent { get; private set; }
        public int ProgressTotal { get; private set; }
        public string ProgressMessage { get; private set; } = string.Empty;

        public event Action? ProgressChanged;


        public void SetAttacker(OperativeToSim operative) => Attacker = operative;
        public void SetDefender(OperativeToSim operative) => Defender = operative;

        public void SetActionType(ActionType actionType)
        {
            ActionType = actionType;
        }

        public void Clear()
        {
            Attacker = null;
            Defender = null;
        }

        public void ReportProgress(int current, int total, string message)
        {
            ProgressCurrent = current;
            ProgressTotal = total;
            ProgressMessage = message;
            ProgressChanged?.Invoke();
        }
    }
}
