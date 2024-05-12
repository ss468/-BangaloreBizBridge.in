using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Dto;
using InvestHub.Core.Entities;

namespace InvestHub.Core.Interfaces.Service
{
    public interface IPitchService
    {
        void CreatePitch(PitchDto pitchDto);
        GetPitchDto GetPitchById(string pitchId);
        IEnumerable<GetPitchDto> GetPitchs(PitchType? Type);
        void UpdatePitch(string pitchId, PitchDto updatePitchDto);
        void DeletePitch(string pitchId);
    }
}
