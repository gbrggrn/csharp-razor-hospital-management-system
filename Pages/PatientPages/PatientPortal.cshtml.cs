using Csharp3_A1.Services;
using Csharp3_A1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Csharp3_A1.Pages.PatientPages
{
    public class PatientPortalModel : PageModel
    {
        [BindProperty]
        public Appointment Appointment { get; set; } = new();

        private readonly PatientService _patientService;
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public SelectList SelectPatientList { get; set; }


        public PatientPortalModel(PatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task OnGetAsync()
        {
            var patientsRetrieved = await _patientService.GetAllAsync();
            SelectPatientList = new SelectList(patientsRetrieved, "Id", "Name");
            Patients = patientsRetrieved.ToList();
        }

        public async Task<IActionResult> OnPostBookAsync()
        {
            await _patientService.UpdateAppointmentsAsync(Appointment.PatientId, Appointment);
            return Page();
        }
    }
}
