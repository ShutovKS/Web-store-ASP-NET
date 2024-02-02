using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Web_store.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Введите адрес")]
        public string Address { get; set; }

        [Display(Name = "Введите номер телефона"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Введите электронную почту"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Заполните платёжную систему")]
        public Payment Payment { get; set; }
        
        [BindNever, ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
    }

    public class Payment
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationData { get; set; }
        public string CVV { get; set; }
    }
    public enum PaymentType
    {
        CreditCard,
        DebitCard,
        PayPal
    }
}
