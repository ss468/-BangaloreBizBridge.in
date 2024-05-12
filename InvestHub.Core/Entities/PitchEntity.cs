using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InvestHub.Core.Entities
{
    public class PitchEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public PitchType Type { get; set; }
        public byte[] FileBytes { get; set; }
    }

    public enum PitchType
    {
        Technology,
        Healtcare,
        RealEstate,
        Other
    }
}
