using System.Collections.Generic;

namespace TourEntities.Service.Food
{
    public class Menu
    {
        /**
         * List containing location of pdf files describing the menu.
         */
        public List<string> Attachments { get; set; }
        public string Tags { get; set; }
    }
}