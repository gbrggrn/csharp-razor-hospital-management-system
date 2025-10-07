using Csharp3_A1.Services;
using Csharp3_A1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Csharp3_A1.Pages.PatientPages
{
    public class PatientPortalModel : PageModel
    {
        private readonly PatientService _patientService;
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public PatientPortalModel(PatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task OnGetAsync()
        {
            Patients = await _patientService.GetAllAsync();
        }
    }
}
