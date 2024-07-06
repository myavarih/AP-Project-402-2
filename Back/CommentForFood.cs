using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    internal class CommentForFood
    {
        public string Text { get; set; } = "";
        public CommentForFood? Reply { get; set; } = null;
        public bool IsEdited { get; set; } = false;
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public string FoodName { get; set; } = "";
        public DateTime CreatedTime { get; set; }
        public int Code { get
            {
                DateTimeOffset dtos = new DateTimeOffset(CreatedTime);
                return (int)dtos.ToUnixTimeSeconds();
            } } // unique
    }
}
