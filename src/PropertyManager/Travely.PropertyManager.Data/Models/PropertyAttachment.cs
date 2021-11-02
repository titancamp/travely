namespace Travely.PropertyManager.Data.Models
{
    public class PropertyAttachment
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public string FileId { get; set; }

        public string Name { get; set; }


        public Property Property { get; set; }
    }
}
