using AutoMapper;
using CarRental.Helpers;
using CarRental.Models;

namespace CarRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model nach VM
            CreateMap<Car, CarVm>()
                .ForMember(a => a.Name,
                    src => src.MapFrom(opt => opt.CarName))
                .ForMember(a => a.Producer,
                    src => src.MapFrom(opt => opt.CarProducer))
                .ForMember(a => a.Age,
                    src => src.ResolveUsing(a => a.YearOfConstruction?.Year.CalcAge()));
        }
    }
}