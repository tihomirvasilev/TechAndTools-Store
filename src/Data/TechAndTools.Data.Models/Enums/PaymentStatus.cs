namespace TechAndTools.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum PaymentStatus
    {
        [Display(Name = "Платено")]
        Paid = 1,

        [Display(Name = "Очаква плащане")]
        Unpaid = 2,

        [Display(Name = "Отказана")]
        Denied = 3
    }
}
