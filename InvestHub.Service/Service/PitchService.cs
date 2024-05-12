using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Dto;
using InvestHub.Core.Entities;
using InvestHub.Core.ExtensionMethod;
using InvestHub.Core.Interfaces.Repository;
using InvestHub.Core.Interfaces.Service;
using InvestHub.Core.Models;
using MongoDB.Bson;

namespace InvestHub.Service.Service
{
    public class PitchService : IPitchService
    {
        private readonly IPitchRepository _pitchRepository;

        public PitchService(IPitchRepository pitchRepository)
        {
            _pitchRepository = pitchRepository ?? throw new ArgumentNullException(nameof(pitchRepository));
        }

        public void CreatePitch(PitchDto pitchDto)
        {
            List<byte[]> bytes = new List<byte[]>();
            // Convert file from base64 string to byte array if needed
            
            var pitchModel = MapperExtension.ToPitchModel(pitchDto);
                
            //    new PitchModel
            //{
            //    Title = pitchDto.Title,
            //    Description = pitchDto.Description,
            //    Type = pitchDto.Type,
            //    FileBytes = !string.IsNullOrWhiteSpace(pitchDto.FileBytes) ? Convert.FromBase64String(pitchDto.FileBytes) : null
            //};


            var pitchEntity = MapperExtension.ToPitchEntity(pitchModel);
            pitchEntity.Id = Guid.NewGuid();
            //    new PitchEntity
            //{
            //    Id = new Guid(),
            //    Title = pitchModel.Title,
            //    Description = pitchModel.Description,
            //    FileBytes =pitchModel.FileBytes
            //};

            _pitchRepository.Insert(pitchEntity);
        }

        public GetPitchDto GetPitchById(string pitchId)
        {
            if (!Guid.TryParse(pitchId, out Guid objectId))
            {
                throw new ArgumentException("Invalid ObjectId format");
            }

            var pitch = _pitchRepository.GetById(objectId);
            var pitchModel = MapperExtension.ToPitchModel(pitch);
            var pitchDto = MapperExtension.ToPitchDto(pitchModel);
            return pitchDto;
        }

        public IEnumerable<GetPitchDto> GetPitchs(PitchType? Type)
        {
            var pitchEntities = _pitchRepository.GetAllPitch(Type);
            var pitchModel = MapperExtension.ToPitchModel(pitchEntities);
            var pitchDtos = MapperExtension.ToPitchDto(pitchModel);
            return pitchDtos;
        }

        public void UpdatePitch(string pitchId, PitchDto updatePitchDto)
        {
            if (!Guid.TryParse(pitchId, out Guid objectId))
            {
                throw new ArgumentException("Invalid ObjectId format");
            }

            var pitch = _pitchRepository.GetById(objectId);
            if (pitch == null)
            {
                throw new ArgumentException("Pitch not found");
            }

            pitch.Title = updatePitchDto.Title;
            pitch.Description = updatePitchDto.Description;
            pitch.Type = updatePitchDto.Type;
            // Update file if provided
            
            if (!string.IsNullOrEmpty(updatePitchDto.File))
            {
                pitch.FileBytes = Convert.FromBase64String(updatePitchDto.File);
            }

            _pitchRepository.Update(pitch);
        }

        public void DeletePitch(string pitchId)
        {
            if (!Guid.TryParse(pitchId, out Guid objectId))
            {
                throw new ArgumentException("Invalid ObjectId format");
            }

            _pitchRepository.Delete(objectId);
        }
    }
}
