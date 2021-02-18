using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediaValet.OrderSupervisor.Business.DTOs;
using DAL = MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.Business.Mapper.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            MappingProfile();
        }

        private void MappingProfile()
        {
            CreateMap<DAL.Order, Order>()
                .ForMember(d => d.MagicNumber, opt => opt.MapFrom(s => s.RandomNumber))
                .ForMember(d => d.OrderDetails, opt => opt.MapFrom(s => s.OrderText));
            CreateMap<Order, DAL.Order>()
                .ForMember(d => d.RandomNumber, opt => opt.MapFrom(s => s.MagicNumber))
                .ForMember(d => d.OrderText, opt => opt.MapFrom(s => s.OrderDetails));
        }
    }
}
