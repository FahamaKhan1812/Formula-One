using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.Api.MappingProfiles;
public class DomainToResponse : Profile
{
	public DomainToResponse()
	{
        CreateMap<Achievement, DriverAchievementResponse>()
            //.ForMember
            //    (
            //        dest => dest.Id,
            //        opt => opt.MapFrom(src => src.DriverId)
            //    )
            .ForMember
                (
                    dest => dest.Wins,
                    opt => opt.MapFrom(src => src.RaceWins)
                );

        CreateMap<Driver, DriverResponse>()
            .ForMember
                (
                    dest => dest.DriverId,
                    opt => opt.MapFrom(src => src.Id)
                )
           .ForMember
                (
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                );
    }
}
