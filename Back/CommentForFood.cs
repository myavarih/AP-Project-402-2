using AP_Project.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace AP_Project
{
    internal class CommentForFood
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
        public string Text { get; set; } = "";
        public RestaurantComment? Reply { get; set; } = null;
        public bool IsEdited { get; set; } = false;
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public string FoodName { get; set; } = "";
        public DateTime CreatedTime { get; set; }
        
    }
}
