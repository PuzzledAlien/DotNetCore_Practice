using System.Text.RegularExpressions;
using AutoMapper;
using Demo.MyJob.Entity;
using Demo.MyJob.Entity.Dto;

namespace Demo.MyJob.MapperProfiles
{
    class MyMapperProfile : Profile
    {
        private static string HideTel(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            var outReplace = Regex.Replace(input, "(\\d{3})\\d{4}(\\d{4})", "$1****$2");
            return outReplace;
        }
        public MyMapperProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(u => u.Tel, options => options.MapFrom(input => HideTel(input.PhoneNumber)));

            CreateMap<(Order, OrderAddress), OrderDto>()
                .ForMember(u => u.Tel, options => options.MapFrom(input => HideTel(input.Item1.PhoneNumber)))
                .ForMember(u => u.OrderName, options => options.MapFrom(input => input.Item1.OrderName))
                .ForMember(u => u.PostalAddress, options => options.MapFrom(input => input.Item2.PostalAddress))
                .ForMember(u => u.DeliveryAddress, options => options.MapFrom(input => input.Item2.DeliveryAddress))
                ;
        }
    }
}
