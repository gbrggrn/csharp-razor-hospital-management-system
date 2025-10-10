using Csharp3_A1.Services;
using Csharp3_A1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Csharp3_A1.Pages.PatientPages
{
    [Authorize(Roles = "Patient")]
    public class PatientPortalModel : PageModel
    {
        [BindProperty]
        public Appointment Appointment { get; set; } = new();

        //Services
        private readonly PatientService _patientService;
        private readonly StaffService _staffService;
        private readonly AccountService _accountService;

        //Patient properties
        public Patient CurrentPatient { get; set; } = new();
        public List<MedicalHistory> MedicalHistory { get; set; } = [];
        public List<Appointment> Appointments { get; set; } = [];

        //Staff list property
        public SelectList SelectStaffList { get; set; }


        public PatientPortalModel(PatientService patientService, StaffService staffService, AccountService accountService)
        {
            _patientService = patientService;
            _staffService = staffService;
            _accountService = accountService;
        }

        public async Task OnGetAsync()
        {
            var username = User.Identity?.Name;
            var user = await _accountService.GetByUserNameAsync(username);

            if (user?.PatientId != null)
            {
                CurrentPatient = await _patientService.GetByIdAsync(user.PatientId.Value);
                MedicalHistory = await _patientService.GetMedicalHistoryByPatientIdAsync(user.PatientId.Value);
                Appointments = await _patientService.GetAppointmentsByPatientIdAsync(user.PatientId.Value);
            }

            var staffRetrieved = await _staffService.GetAllAsync();
            SelectStaffList = new SelectList(staffRetrieved, "Id", "Name");
        }

        public async Task<IActionResult> OnPostBookAsync()
        {
            await _patientService.UpdateAppointmentsAsync(Appointment.PatientId, Appointment);
            return Page();
        }
    }
}