using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.Models
{
    public class PaymentQueryParameters
    {
        const int MaxSize = 50;
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
                _size = (value > MaxSize) ? MaxSize : value;
            }
        }
        public string OrderBy { get; set; } = "CreatedAt";
        public string Search { get; set; }
    }
}
