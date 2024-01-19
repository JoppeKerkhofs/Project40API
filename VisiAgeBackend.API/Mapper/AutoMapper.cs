using AutoMapper;
using VisiAgeBackend.API.Dto;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<GetUserDto, User>();
            CreateMap<CreateUserDto, User>();
            CreateMap<EditUserDto, User>();
            CreateMap<User, GetUserDto>();

            CreateMap<GetRoleDto, Role>();
            CreateMap<CreateRoleDto, Role>();
            CreateMap<EditRoleDto, Role>();
            CreateMap<Role, GetRoleDto>();

            CreateMap<GetCoughDto, Cough>();
            CreateMap<CreateCoughDto, Cough>();
            CreateMap<Cough, GetCoughDto>();

            CreateMap<GetCameraRoomDto, CameraRoom>();
            CreateMap<CreateCameraRoomDto, CameraRoom>();
            CreateMap<CameraRoom, GetCameraRoomDto>();

            CreateMap<GetIncidentTypeDto, IncidentType>();
            CreateMap<CreateIncidentTypeDto, IncidentType>();
            CreateMap<IncidentType, GetIncidentTypeDto>();

            CreateMap<GetAlertDto, Alert>();
            CreateMap<CreateAlertDto, Alert>();
            CreateMap<Alert, GetAlertDto>();

            CreateMap<GetAlertStatusDto, AlertStatus>();
            CreateMap<CreateAlertStatusDto, AlertStatus>();
            CreateMap<EditAlertStatusDto, AlertStatus>();
            CreateMap<AlertStatus, GetAlertStatusDto>();

            CreateMap<GetAlertStatusTypeDto, AlertStatusType>();
            CreateMap<CreateAlertStatusTypeDto, AlertStatusType>();
            CreateMap<AlertStatusType, GetAlertStatusTypeDto>();
        }
    }
}
