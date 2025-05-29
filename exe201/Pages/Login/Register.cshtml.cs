using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using exe201.Models;

namespace exe201.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly EcommerceContext _context;

        public RegisterModel(EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == Input.Email);
            if (existingUser != null)
            {
                ErrorMessage = "Email đã tồn tại.";
                return Page();
            }

            var user = new User
            {
                Email = Input.Email,
                Password = Input.Password, // ❗ Nên hash mật khẩu trong thực tế
                Role = UserRole.Customer.ToString()
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login/Index"); // Chuyển hướng về trang login
        }

        public class RegisterInputModel
        {
            [Required, EmailAddress]
            public string Email { get; set; }

            [Required, DataType(DataType.Password)]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự.")]
            public string Password { get; set; }

            [Required, DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
