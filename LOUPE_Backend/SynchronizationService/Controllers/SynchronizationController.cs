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
        public SynchronizationController(RotationActionStrategy rotationStrategy, TranslationActionStrategy translationStrategy)
        {
            _strategies = new Dictionary<string, IActionStrategy>
            {
                {"Rotate", rotationStrategy },
                {"Translate", translationStrategy },
            };
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult AllTransformations()
        {
            return Ok();
        }

        [HttpPost("Test")]
        public async Task<IActionResult> Test([FromQuery] string action, [FromBody] TransformationViewModel transformation)
        {
            if (action == string.Empty)
                return BadRequest("No action given");

            try
            {
                if (_strategies.TryGetValue(action, out IActionStrategy? strategy))
                {
                    var r = await strategy.AddAction(transformation);
                }
                else
                {
                    return BadRequest("Given action not found");
                }

                if (!transformation.IsLast)
                {
                    _groupedTransformations.Add(transformation);
                }
                else
                {
                    //send groupedTransformations to logservice
                    _groupedTransformations.Clear();
                }
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
    }
}
