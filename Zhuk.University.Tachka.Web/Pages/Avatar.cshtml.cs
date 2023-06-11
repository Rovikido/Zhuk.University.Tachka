using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class AvatarModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AvatarModel(UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public IFormFile AvatarFile { get; set; }

        public async Task<IActionResult> OnPostUploadAvatarAsync()
        {
            // �������� ������������� ��������� �����������
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                try
                {
                    // �������� �������� ��'� ��� �����
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + AvatarFile.FileName;

                    // �������� ���� ��� ���������� �������
                    var avatarPath = Path.Combine(_hostingEnvironment.WebRootPath, "avatars", uniqueFileName);

                    // �������� ���� ������� �� ������
                    using (var stream = new FileStream(avatarPath, FileMode.Create))
                    {
                        await AvatarFile.CopyToAsync(stream);
                    }

                    // �������� ��'��� ����������� � ���� �����
                    var user = await _userManager.FindByIdAsync(userId);

                    // ���������� ���� AvatarPath ���� �� �������
                    user.AvatarPath = "/avatars/" + uniqueFileName;

                    // ��������� ��� ����������� � ��� �����
                    await _userManager.UpdateAsync(user);

                    return RedirectToPage("Profile");
                }
                catch (Exception ex)
                {
                    // ������� �������
                    ModelState.AddModelError(string.Empty, "������� �� ��� ������������ �������: " + ex.Message);
                }
            }

            return RedirectToPage("Profile");
        }
    }
}
