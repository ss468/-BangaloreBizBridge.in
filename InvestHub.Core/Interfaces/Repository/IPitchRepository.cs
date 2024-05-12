using InvestHub.Core.Entities;
using MongoDB.Bson;

namespace InvestHub.Core.Interfaces.Repository
{
    public interface IPitchRepository
    {
        void Insert(PitchEntity pitch);
        PitchEntity GetById(Guid id);
        IEnumerable<PitchEntity> GetAllPitch(PitchType? pitchType);
        void Update(PitchEntity pitch);
        void Delete(Guid id);
    }
}
