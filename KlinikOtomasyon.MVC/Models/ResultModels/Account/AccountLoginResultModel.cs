using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KlinikOtomasyon.MVC.Models.ResultModels.Account
{
    public class AccountLoginResultModel
    {
        [DisplayName("Kullanıcı Adı")]
        // [Required(ErrorMessage = "Lütfen Geçerli Bir {0} Giriniz")]
        // [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Lütfen Mail Adresinizi Kontrol Ediniz")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir {0} Giriniz")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}