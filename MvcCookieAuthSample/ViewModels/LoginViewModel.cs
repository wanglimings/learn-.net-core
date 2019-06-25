using System.ComponentModel.DataAnnotations;



namespace MvcCookieAuthSample.ViewModels
{
    public class LoginViewModel
      {
          [Required(ErrorMessage = "������email")]
          [DataType(DataType.EmailAddress,ErrorMessage = "��������ȷ��ʽ��email")]
          public string Email{get;set;}

          [Required]
          [DataType(DataType.Password)]
          public string Password{get;set;}
       

      }
}
