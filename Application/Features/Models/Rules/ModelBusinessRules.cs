using Application.Features.Brands.Constants;
using Application.Features.Models.Constans;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Rules
{
    public class ModelBusinessRules : BaseBusinessRules
    {
        IModelRepository _modelRepository;

        public ModelBusinessRules(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task ModelFuelFiveLimitControlWhenInserted(int fuelId)
        {
            var models = await _modelRepository.GetListAsync(x => x.FuelId == fuelId);
            if (models.Count == 5)
                throw new BusinessException(ModelMessages.ModelFuelFiveLimitFull);
        }

        public async Task ModelTransmissionFiveLimitControlWhenInserted(int transmissionId)
        {
            var models = await _modelRepository.GetListAsync(x => x.TransmissionId == transmissionId);
            if (models.Count == 5)
                throw new BusinessException(ModelMessages.ModelTransmissionFiveLimitFull);
        }
    }
}
