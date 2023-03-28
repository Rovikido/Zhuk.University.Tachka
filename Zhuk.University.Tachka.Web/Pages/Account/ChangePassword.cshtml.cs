using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Zhuk.University.Tachka.Web.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        [Required(ErrorMessage = "������ ��'�")]
        public string Name { get; set; }
        [Required(ErrorMessage = "������ password")]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        [MinLength(6, ErrorMessage = "Password ������� ���� ������� ����� 6 �������")]
        public string NewPassword { get; set; }

    }
}
