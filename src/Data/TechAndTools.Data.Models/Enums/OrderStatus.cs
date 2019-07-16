namespace TechAndTools.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum OrderStatus
    {
        [Display(Name = "Необработена")]
        Unprocessed = 1,

        [Display(Name = "Обработена")]
        Processed = 2,

        [Display(Name = "Доставена")]
        Delivered = 3
    }
}
