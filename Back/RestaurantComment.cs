using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back
{
    class RestaurantComment
    {
        [Key]
        public int Code
        {
            get
            {
                DateTimeOffset dtos = new DateTimeOffset(CreatedTime);
                return (int)dtos.ToUnixTimeSeconds();
            }
            set
            {

            }
        }
        string Text { get; set; } = "";
        string RestaurantUsername { get; set; } = "";

        public DateTime CreatedTime { get; set; }
    }
}
