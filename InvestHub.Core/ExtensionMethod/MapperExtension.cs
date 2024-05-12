using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InvestHub.Core.Dto;
using InvestHub.Core.Entities;
using InvestHub.Core.Models;

namespace InvestHub.Core.ExtensionMethod
{
    public static class MapperExtension
    {
        public static IMapper _mapper { get; set; }
        public static void mapperExtension() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserEntity>().ReverseMap();
                cfg.CreateMap<CreateUserDto, UserModel>().ReverseMap();
                cfg.CreateMap<GetUserDto, UserModel>().ReverseMap();
                cfg.CreateMap<PitchEntity, PitchModel>().ReverseMap();
                cfg.CreateMap<PitchModel, GetPitchDto>().ReverseMap();
                cfg.CreateMap<PitchModel, PitchDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();

        }

        public static UserEntity ToUserEntity(this UserModel userModel)
        {
            if (userModel == null)
                throw new ArgumentNullException(nameof(userModel));

            mapperExtension();

            return _mapper.Map<UserEntity>(userModel);
        }
        public static UserModel ToUserModel(this CreateUserDto userModel)
        {
            if (userModel == null)
                throw new ArgumentNullException(nameof(userModel));
            mapperExtension();

            return _mapper.Map<UserModel>(userModel);
        }
        public static UserModel ToUserModel(this UserEntity userEntity)
        {
            if (userEntity == null)
                throw new ArgumentNullException(nameof(userEntity));
            mapperExtension();

            return _mapper.Map<UserModel>(userEntity);
        }
        public static GetUserDto ToGetUserDto(this UserModel userModel)
        {
            if (userModel == null)
                throw new ArgumentNullException(nameof(userModel));
            mapperExtension();

            return _mapper.Map<GetUserDto>(userModel);
        }
        public static IEnumerable<GetUserDto> ToGetUserListDto(this IEnumerable<UserModel> userModels)
        {
            if (userModels == null)
                throw new ArgumentNullException(nameof(userModels));
            mapperExtension();

            return _mapper.Map<IEnumerable<GetUserDto>>(userModels);
        }

        public static IEnumerable<UserModel> ToUserModel(this IEnumerable<UserEntity> userEntities)
        {
            if (userEntities == null)
                throw new ArgumentNullException(nameof(userEntities));
            mapperExtension();

            return _mapper.Map<IEnumerable<UserModel>>(userEntities);
        }

        // ---------------- PITCH ------------------- //
        public static PitchModel ToPitchModel(this PitchEntity pitch)
        {
            if (pitch == null)
                throw new ArgumentNullException(nameof(pitch));
            mapperExtension();

            return _mapper.Map<PitchModel>(pitch);
        }
        public static PitchEntity ToPitchEntity(this PitchModel pitch)
        {
            if (pitch == null)
                throw new ArgumentNullException(nameof(pitch));
            mapperExtension();

            return _mapper.Map<PitchEntity>(pitch);
        }
        public static PitchModel ToPitchModel(this PitchDto pitchDto)
        {
            if (pitchDto == null)
                throw new ArgumentNullException(nameof(pitchDto));
            mapperExtension();

            var pitchModel = _mapper.Map<PitchModel>(pitchDto);
            pitchModel.FileBytes = !string.IsNullOrWhiteSpace(pitchDto.File) ? Convert.FromBase64String(pitchDto.File) : null;
            return pitchModel;
        }
        public static IEnumerable<PitchModel> ToPitchModel(this IEnumerable<PitchEntity> pitch)
        {
            if (pitch == null)
                throw new ArgumentNullException(nameof(pitch));
            mapperExtension();

            return _mapper.Map<IEnumerable<PitchModel>>(pitch);
        }
        public static GetPitchDto ToPitchDto(this PitchModel pitchModel)
        {
            if (pitchModel == null)
                throw new ArgumentNullException(nameof(pitchModel));
            mapperExtension();
            var pitchDto = _mapper.Map<GetPitchDto>(pitchModel);
            pitchDto.File = pitchModel.FileBytes != null ? Convert.ToBase64String(pitchModel.FileBytes) : null;


            return pitchDto;
        }
        public static IEnumerable<GetPitchDto> ToPitchDto(this IEnumerable<PitchModel> pitch)
        {
            if (pitch == null)
                throw new ArgumentNullException(nameof(pitch));
            mapperExtension();
            var pitchDto = _mapper.Map<IEnumerable<GetPitchDto>>(pitch);
            foreach ( var dto in pitchDto)
                foreach ( var item in pitch)
                    if(item.Id == dto.Id)
                        dto.File = item.FileBytes != null ? Convert.ToBase64String(item.FileBytes) : null;

            return pitchDto;
        }
    }

}
