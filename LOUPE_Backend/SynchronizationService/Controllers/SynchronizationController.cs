using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.Core.API.Strategies;
using MongoDB.Driver;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]")]
    public class SynchronizationController : Controller
    {
        private readonly Dictionary<string, IActionStrategy> _strategies;

        private readonly ICollection<TransformationViewModel> _groupedTransformations = new List<TransformationViewModel>();
        public SynchronizationController(IEnumerable<IActionStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.Name);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult AllTransformations()
        {
            return Ok();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> SaveSyncronization([FromQuery] string action, [FromBody] TransformationViewModel transformation)
        {
            if (action == string.Empty)
                return BadRequest("No action given");

            try
            {
                if (!_strategies.TryGetValue(action, out IActionStrategy? strategy))
                    return BadRequest("Given action not found");

                bool isChanged = await strategy.AddAction(transformation);

                CheckLastMessage(transformation, isChanged);
            }
            catch (MongoWriteException ex)
            {
                Console.WriteLine("Mongo error: " + ex.Message);
                return StatusCode(500, ex.Message);
            }
            catch (MongoWriteConcernException ex)
            {
                Console.WriteLine("Mongo error: " + ex.Message);
                return StatusCode(500, ex.Message);
            }
            catch (MongoException ex)
            {
                Console.Write("Mongo error: " + ex.Message);
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write("Generic error: " + ex.Message);
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }

        private void CheckLastMessage(TransformationViewModel transformation, bool isChanged)
        {
            if (!transformation.IsLast && isChanged)
            {
                _groupedTransformations.Add(transformation);
            }
            else if (transformation.IsLast)
            {
                //send groupedTransformations to logservice
                _groupedTransformations.Clear();
            }
        }
    }
}
