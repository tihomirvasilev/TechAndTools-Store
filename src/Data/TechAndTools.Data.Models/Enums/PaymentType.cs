namespace TechAndTools.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum PaymentType
    {
        [Display(Name = "Наложен платеж")]
        CashОnDelivery = 1,

        [Display(Name = "PayPal")]
        PayPal = 2,

        [Display(Name = "ePay")]
        ePay
    }
}
