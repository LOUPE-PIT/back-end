using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizationService.DataLayer.Models.MongoDB.Interfaces
{
    public interface ITransformationsDatabaseSettings
    {
        string TransformationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
