using AutoMapper;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.ValueObjects;

namespace Teste.El.Backend.Application.Mapping
{
    /// <summary>
    /// Mapper de cliente
    /// </summary>
    public class ClienteMap : Profile
    {
        /// <summary>
        /// Mapeamento de dados
        /// </summary>
        public ClienteMap()
        {
            CreateMap<Cliente, ClienteModel>()
                .ForMember(dest => dest.Aniversario, m => m.MapFrom(src => src.Aniversario))
                .ForMember(dest => dest.Endereco, m => m.MapFrom(src => src.Endereco))
                //.ForMember(dest => dest.Endereco.Cep, m => m.MapFrom(src => src.Endereco.Cep))
                //.ForMember(dest => dest.Endereco.Cidade, m => m.MapFrom(src => src.Endereco.Cidade))
                //.ForMember(dest => dest.Endereco.Complemento, m => m.MapFrom(src => src.Endereco.Complemento))
                //.ForMember(dest => dest.Endereco.Estado, m => m.MapFrom(src => src.Endereco.Estado))
                //.ForMember(dest => dest.Endereco.Logradouro, m => m.MapFrom(src => src.Endereco.Logradouro))
                //.ForMember(dest => dest.Endereco.Numero, m => m.MapFrom(src => src.Endereco.Numero))
                .ForMember(dest => dest.Cpf, m => m.MapFrom(src => src.Cpf.ToString()))
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome));

            CreateMap<ClienteModel, Cliente>()
                .ForMember(dest => dest.Aniversario, m => m.MapFrom(src => src.Aniversario))
                .ForMember(dest => dest.Endereco, m => m.Ignore())
                //.ForMember(dest => dest.Endereco.Cep, m => m.MapFrom(src => src.Endereco.Cep))
                //.ForMember(dest => dest.Endereco.Cidade, m => m.MapFrom(src => src.Endereco.Cidade))
                //.ForMember(dest => dest.Endereco.Complemento, m => m.MapFrom(src => src.Endereco.Complemento))
                //.ForMember(dest => dest.Endereco.Estado, m => m.MapFrom(src => src.Endereco.Estado))
                //.ForMember(dest => dest.Endereco.Logradouro, m => m.MapFrom(src => src.Endereco.Logradouro))
                //.ForMember(dest => dest.Endereco.Numero, m => m.MapFrom(src => src.Endereco.Numero))
                .ForMember(dest => dest.Cpf, m => m.Ignore())
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome))
                .ConstructUsing(src =>
                    new Cliente(
                        src.Nome,
                        new CPF(src.Cpf),
                        src.Aniversario,
                        new EnderecoCompleto(src.Endereco.Cep, src.Endereco.Logradouro, src.Endereco.Numero, src.Endereco.Complemento, src.Endereco.Cidade, src.Endereco.Estado)
                    ));
        }
    }
}
