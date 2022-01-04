using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.Entities
{
    public class AttachmentEntity
    {
        public int Id { get; set; }

        public PayableItemEntity Payment { get; set; }

        public Guid AttachmentGuid { get; set; }
    }
}
