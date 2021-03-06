using AutoMapper;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Services;
using AutonomoApp.Data.Repository;
using AutonomoApp.WebApi.Controllers;
using AutonomoApp.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutonomoApp.WebApi.Controllers.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/categorias")]
    [Produces("application/json")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly IServicoService _servicoService;
        private readonly IMapper _mapper;

        public CategoriaController(
                    ICategoriaRepository categoriaRepository,
                    IServicoRepository servicoRepository,
                    IServicoService servicoService,
                    IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _servicoRepository = servicoRepository;
            _servicoService = servicoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="subcategoria"></param>
        /// <returns></returns>
        [HttpPost("categoria/{categoria:int}/subcategoria/{subcategoria:int}")]
        public ActionResult<string> ObterCategoria(int categoria, int subcategoria)
        {
            try
            {
                ArgumentNullException.ThrowIfNull((categoria, subcategoria));
                var result = new CategoriaBuilder(categoria, subcategoria);
                return Ok(result.ToString());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }
        }

        /// <summary>
        /// Obtem todas as categorias e suas respectivas subcategorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterTodasCategorias")]
        public async Task<List<CategoriaViewModel>> ObterTodasCategorias()
        {
            // var fornecedor = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return _mapper.Map<List<CategoriaViewModel>>(await _categoriaRepository.ObterTodasCategorias());

        }

        [HttpGet("ObterSubcategorias")]
        public async Task<List<Subcategoria>> ObterSubcat()
        {
            return await _categoriaRepository.ObterTodasCategoriasESubcategorias();
        }

        [HttpGet("ObterServicoPorID")]
        public async Task<ServicoDTO> ObterServico()
        {
            var idServico = Guid.Parse("062932e5-7aa2-4cf0-8bea-a406233fdcf0");

            var tt = await _categoriaRepository.ObterTodos();
            var result = _servicoRepository
                .Consultar<Categoria>().ToList();


            var dto = await _servicoService.ObterServicoDTO(idServico);

            return dto;
        }


    }

}
