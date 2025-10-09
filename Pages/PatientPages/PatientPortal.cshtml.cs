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

        private readonly PatientService _patientService;
        private readonly StaffService _staffService;
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public SelectList SelectPatientList { get; set; }
        public SelectList SelectStaffList { get; set; }


        public PatientPortalModel(PatientService patientService, StaffService staffService)
        {
            _patientService = patientService;
            _staffService = staffService;
        }

        public async Task OnGetAsync()
        {
            var patientsRetrieved = await _patientService.GetAllAsync();
            SelectPatientList = new SelectList(patientsRetrieved, "Id", "Name");
            Patients = patientsRetrieved.ToList();

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
