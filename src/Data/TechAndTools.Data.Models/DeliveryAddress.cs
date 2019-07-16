namespace TechAndTools.Data.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int PostCode { get; set; }

        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }
}
}
