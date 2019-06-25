using System.ComponentModel.DataAnnotations;



namespace MvcCookieAuthSample.ViewModels
{
    public class LoginViewModel
      {
          [Required(ErrorMessage = "请输入email")]
          [DataType(DataType.EmailAddress,ErrorMessage = "请输入正确格式的email")]
          public string Email{get;set;}

          [Required]
          [DataType(DataType.Password)]
          public string Password{get;set;}
       

      }
}
