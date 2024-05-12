using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InvestHub.Core.Entities;

namespace InvestHub.Core.Dto
{
    public class PitchDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PitchType Type { get; set; }
        public string File { get; set; } // Binary string representing the file
    }
}
