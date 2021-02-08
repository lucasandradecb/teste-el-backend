﻿using AutoMapper;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;

namespace Teste.El.Backend.Application.Mapping
{
    /// <summary>
    /// Mapper de veiculo
    /// </summary>
    public class VeiculoMap : Profile
    {
        /// <summary>
        /// Mapeamento de dados
        /// </summary>
        public VeiculoMap()
        {
            CreateMap<MarcaVeiculoModel, MarcaVeiculo>()
                .ForMember(dest => dest.Codigo, m => m.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Descricao, m => m.MapFrom(src => src.Descricao))
                .ReverseMap();

            CreateMap<ModeloVeiculoModel, ModeloVeiculo>()
                .ForMember(dest => dest.Codigo, m => m.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Descricao, m => m.MapFrom(src => src.Descricao))
                .ReverseMap();

            CreateMap<VeiculoModel, Veiculo>()
                .ForMember(dest => dest.Ano, m => m.MapFrom(src => src.Ano))
                .ForMember(dest => dest.Categoria, m => m.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.CodigoMarca, m => m.MapFrom(src => src.Marca))
                .ForMember(dest => dest.CodigoModelo, m => m.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.Combustivel, m => m.MapFrom(src => src.Combustivel))
                .ForMember(dest => dest.LimitePortaMalas, m => m.MapFrom(src => src.LimitePortaMalas))
                .ForMember(dest => dest.Placa, m => m.MapFrom(src => src.Placa))
                .ReverseMap();
        }
    }
}
