using AutoMapper;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.ValueObjects;

namespace Teste.El.Backend.Application.Mapping
{
    /// <summary>
    /// Mapper de usuario
    /// </summary>
    public class UsuarioMap : Profile
    {
        /// <summary>
        /// Mapeamento de dados
        /// </summary>
        public UsuarioMap()
        {
            CreateMap<Cliente, ClienteModel>()
                .ForMember(dest => dest.Aniversario, m => m.MapFrom(src => src.Aniversario))
                .ForMember(dest => dest.Endereco, m => m.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Cpf, m => m.MapFrom(src => src.Cpf.ToString()))
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome));

            CreateMap<ClienteModel, Cliente>()
                .ForMember(dest => dest.Aniversario, m => m.MapFrom(src => src.Aniversario))
                .ForMember(dest => dest.Endereco, m => m.Ignore())
                .ForMember(dest => dest.Cpf, m => m.Ignore())
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome))
                .ConstructUsing(src =>
                    new Cliente(
                        src.Nome,
                        new CPF(src.Cpf),
                        src.Aniversario,
                        new EnderecoCompleto(src.Endereco.Cep, src.Endereco.Logradouro, src.Endereco.Numero, src.Endereco.Complemento, src.Endereco.Cidade, src.Endereco.Estado)
                    ));

            CreateMap<Operador, OperadorModel>()
                .ForMember(dest => dest.Matricula, m => m.MapFrom(src => src.Matricula))
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome));

            CreateMap<OperadorModel, Operador>()
                .ForMember(dest => dest.Matricula, m => m.MapFrom(src => src.Matricula))
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome))
                .ConstructUsing(src =>
                    new Operador(
                        src.Nome,
                        src.Matricula
                    ));
        }
    }
}
