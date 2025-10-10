using Csharp3_A1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Csharp3_A1.Models;

namespace Csharp3_A1.Pages.Appointments
{
    [Authorize(Roles = "Staff, Patient")]
    public class IndexModel : PageModel
    {
        private readonly AppointmentService _appointmentService;
        private readonly AccountService _accountService;
        private readonly UserService _userService;

        //User properties
        public Patient? Patient { get; set; }
        public Staff? Staff { get; set; }

        //Appointments for display
        public List<Appointment> Appointments { get; set; }

        public IndexModel(AppointmentService appointmentService, AccountService accountService, UserService userService)
        {
            _appointmentService = appointmentService;
            _accountService = accountService;
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            var username = User.Identity?.Name;
            var user = await _accountService.GetByUserNameAsync(username);

            if (User.IsInRole("Staff"))
            {
                Staff = await _userService.GetStaffByUserAsync(user);
                Appointments = await _appointmentService.GetAppointmentsByStaffIdAsync(Staff!.Id);
            }
            if (User.IsInRole("Patient"))
            {
                Patient = await _userService.GetPatientByUserAsync(user);
                Appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(Patient!.Id);
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _appointmentService.DeleteAppointmentByIdAsync(id);
            return RedirectToPage();
        }
    }
}
