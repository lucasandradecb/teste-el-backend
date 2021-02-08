using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Teste.El.Backend.Application.Interfaces;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using Teste.El.Backend.Domain.Resources;

namespace Teste.El.Backend.Application
{
    /// <summary>
    /// Classe de application de veiculo
    /// </summary>
    public class VeiculoApplication : IVeiculoApplication
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMarcaVeiculoRepository _marcaVeiculoRepository;
        private readonly IModeloVeiculoRepository _modeloVeiculoRepository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="veiculoRepository"></param>
        /// <param name="marcaVeiculoRepository"></param>
        /// <param name="modeloVeiculoRepository"></param>
        public VeiculoApplication(IMapper mapper, 
                                  IVeiculoRepository veiculoRepository,
                                  IMarcaVeiculoRepository marcaVeiculoRepository,
                                  IModeloVeiculoRepository modeloVeiculoRepository)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
            _marcaVeiculoRepository = marcaVeiculoRepository;
            _modeloVeiculoRepository = modeloVeiculoRepository;
        }

        /// <summary>
        /// Realiza o cadastro de um veiculo
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Result<Veiculo>> CadastrarVeiculo(VeiculoModel veiculoModel, CancellationToken ctx)
        {
            var veiculo = _mapper.Map<VeiculoModel, Veiculo>(veiculoModel);         

            if (veiculo.Valid)
            {
                if (!await _veiculoRepository.VerificarSeExiste(veiculo, ctx))
                {
                    await _veiculoRepository.Salvar(veiculo, ctx);
                    return Result<Veiculo>.Ok(veiculo);
                }

                veiculo.AddNotification(nameof(Veiculo), MensagensInfo.Veiculo_PlacaExistente);
            }

            return Result<Veiculo>.Error(veiculo.Notifications);
        }

        /// <summary>
        /// Realiza o cadastro de uma marca de veiculo
        /// </summary>
        /// <param name="marcaVeiculoModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Result<MarcaVeiculo>> CadastrarMarcaVeiculo(MarcaVeiculoModel marcaVeiculoModel, CancellationToken ctx)
        {
            var marca = _mapper.Map<MarcaVeiculoModel, MarcaVeiculo>(marcaVeiculoModel);

            if (marca.Valid)
            {
                if (!await _marcaVeiculoRepository.VerificarSeExiste(marca, ctx))
                {
                    await _marcaVeiculoRepository.Salvar(marca, ctx);
                    return Result<MarcaVeiculo>.Ok(marca);
                }

                marca.AddNotification(nameof(MarcaVeiculo), MensagensInfo.MarcaVeiculo_CodigoExistente);
            }

            return Result<MarcaVeiculo>.Error(marca.Notifications);
        }

        /// <summary>
        /// Realiza o cadastro de um modelo de veiculo
        /// </summary>
        /// <param name="modeloVeiculoModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Result<ModeloVeiculo>> CadastrarModeloVeiculo(ModeloVeiculoModel modeloVeiculoModel, CancellationToken ctx)
        {
            var modelo = _mapper.Map<ModeloVeiculoModel, ModeloVeiculo>(modeloVeiculoModel);

            if (modelo.Valid)
            {
                if (!await _modeloVeiculoRepository.VerificarSeExiste(modelo, ctx))
                {
                    await _modeloVeiculoRepository.Salvar(modelo, ctx);
                    return Result<ModeloVeiculo>.Ok(modelo);
                }

                modelo.AddNotification(nameof(ModeloVeiculo), MensagensInfo.ModeloVeiculo_CodigoExistente);
            }

            return Result<ModeloVeiculo>.Error(modelo.Notifications);
        }
    }
}
