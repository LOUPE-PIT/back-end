using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GroupingService.DataAccessLayer.Models
{
    public class GroupUser
    {
        public Guid UserID { get; set; }
        public Guid GroupID { get; set; }

    }
}
