namespace TechAndTools.Data.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Unprocessed = 1,
        //Processed = 2,
        //Delivered = 3
    }
}
