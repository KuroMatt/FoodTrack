using FoodTrack.Application.Features.StockProducts.Commands;
using FoodTrack.Application.Features.StockProducts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack.API.Controllers
{
    /// <summary>
    /// Contrôleur API permettant de récupérer les informations d'un produit à partir de son code-barres et de les
    /// stocker dans la base de données.
    /// </summary>
    /// <remarks>Utilise le médiateur pour déléguer la logique métier liée à la gestion des produits en stock.
    /// Ce contrôleur expose des points de terminaison RESTful pour l'intégration avec des clients externes.</remarks>
    [ApiController]
    [Route("[controller]")]
    public class StockProductController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public StockProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Récupère tous les produits en stock disponibles dans la base de données, y compris leurs détails tels que la quantité, la date d'expiration et l'emplacement de stockage.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Stocks")]
        public async Task<IActionResult> GetAllStock()
        {
            var result = await _mediator.Send(new GetAllStockProductsQuery());
            return Ok(result);
        }


        /// <summary>
        /// Confirme le stock d'un produit en fonction de son identifiant et de sa date d'expiration
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Enregistrer")]
        public async Task<IActionResult> RegisterStock([FromBody] RegisterStockCommand command)
        {
            var result = await _mediator.Send(new RegisterStockCommand(command.productId, command.purchaseDate, command.expirationDate, command.locationId, command.quantity));
            return Ok(result);
        }

        /// <summary>
        /// Confirme le stock d'un produit en fonction de son identifiant et de sa date d'expiration
        /// </summary>
        /// 
        /// 
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("Consommer")]
        public async Task<IActionResult> ConsumeStock([FromBody] ConsumeStockCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }



    }
}
