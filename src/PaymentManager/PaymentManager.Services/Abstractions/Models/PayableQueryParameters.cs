using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Models
{
    public class PayableQueryParameters
    {
        const int maxSize = 50;
        public int Index { get; set; } = 1;
        private int _size = 10;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = (value > maxSize) ? maxSize : value;
            }
        }
        public string OrderBy { get; set; } = "CreatedAt";
        public string Search { get; set; }
    }
}
