using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("Attachment")]
    public class Attachment
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("AttachmentName")]
        public string AttachmentName { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }
        public virtual Group GroupAttachment { get; set; }
    }
}
