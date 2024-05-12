using InvestHub.Core.Entities;

namespace InvestHub.Core.Models
{
    public class PitchModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PitchType Type { get; set; }
        public byte[] FileBytes { get; set; } // Binary string representing the file
    }
}
