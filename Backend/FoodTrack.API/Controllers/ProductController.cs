using FoodTrack.Application.DTOs;
using FoodTrack.Application.Features.Products.Commands;
using FoodTrack.Application.Features.Products.Queries;
using FoodTrack.Application.Features.StockProducts.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack.API.Controllers
{
    /// <summary>
    /// Contrôleur ASP.NET Core responsable de la gestion des opérations liées aux produits, telles que la récupération
    /// des informations produit à partir d'un code-barres.
    /// </summary>
    /// <remarks>Ce contrôleur utilise le modèle Mediator pour déléguer la logique métier et faciliter la
    /// séparation des responsabilités. Toutes les actions exposées sont accessibles via des routes HTTP et retournent
    /// des résultats adaptés aux conventions RESTful.</remarks>
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Récupère les informations d'un produit à partir de son code-barres et le stocke dans la base de données.
        /// </summary>
        /// <param name="barCode">Code barre du produit</param>
        /// <returns></returns>
        [HttpGet("{barCode}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct(string barCode)
        {
            var productDto = await _mediator.Send(new ScanProductCommand(barCode));
            var totalStockQuantity = await _mediator.Send(new GetTotalStockByProductQuery(productDto.ProductId));
            productDto.TotalStockQuantity = totalStockQuantity;

            return Ok(productDto);
        }

        /// <summary>
        /// Récupère la liste de tous les produits
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return Ok(products);
        }
    }
}
