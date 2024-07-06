using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back
{
    class Complaint
    {
        [Key]
        public int Code { get
            {
                DateTimeOffset dtos = new DateTimeOffset(CreatedTime);
                return (int)dtos.ToUnixTimeSeconds();
            }
            set
            {

            }
        }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public bool IsSolved { get; set; } = false;
        public DateTime CreatedTime { get; set; }

    }
}
