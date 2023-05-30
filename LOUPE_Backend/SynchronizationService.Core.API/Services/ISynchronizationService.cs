using SynchronizationService.Core.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizationService.Core.API.Services
{
    public interface ISynchronizationService
    {
        public Task Add(TransformationViewModel transformation);
    }
}
