using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Zhuk.University.Tachka.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [Required(ErrorMessage = "������ ��'�")]
        [MaxLength(30,ErrorMessage = "��'� ������� ���� ������� 3-30 �������")]
        [MinLength(3, ErrorMessage = "��'� ������� ���� ������� 3-30 �������")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "������ Password")]
        [MinLength(6, ErrorMessage = "Password ������� ���� ������� ����� 6 �������")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ϳ�������� Password")]
        [Compare("Password", ErrorMessage = "Passwords �� ����������")]
        public string ConfirmPassword { get; set;}
    }
}
