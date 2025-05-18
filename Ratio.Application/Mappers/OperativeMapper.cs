using Ratio.Application.DTO;
using Ratio.Application.Enums;
using Ratio.Application.Services;
using Ratio.Domain.Entities;

namespace Ratio.Application.Mappers
{
    public class OperativeMapper
    {
        private readonly OperativeBuilderService _operativeBuilderService;

        public OperativeMapper(OperativeBuilderService operativeBuilderService)
        {
            _operativeBuilderService = operativeBuilderService;
        }

        public async Task<Operative> ToOperativeAsync(OperativeToSim operativeToSim, ActionType actionType, OperativeType operativeType)
        {
            if (operativeToSim == null)
                throw new ArgumentNullException(nameof(operativeToSim));

            return await _operativeBuilderService.BuildOperativeAsync(operativeToSim, actionType, operativeType);
        }
    }

}
