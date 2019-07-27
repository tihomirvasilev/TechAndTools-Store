namespace TechAndTools.Data.Models
{
    public class DescriptionProperty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DescriptionId { get; set; }
        public virtual Description Description { get; set; }
    }
}