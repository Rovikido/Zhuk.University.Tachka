using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Zhuk.University.Tachka.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "������ ��'�")]
        [MaxLength(30, ErrorMessage = "��'� ������� ���� ������� 3-30 �������")]
        [MinLength(3, ErrorMessage = "��'� ������� ���� ������� 3-30 �������")]
        public string Name { get; set; }
        [Required(ErrorMessage = "������ Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password ������� ���� ������� ����� 6 �������")]
        public string Password { get; set; }
    }
}
