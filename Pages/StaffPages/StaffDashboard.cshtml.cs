using Csharp3_A1.Services;
using Csharp3_A1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Csharp3_A1.Pages.StaffDashboard
{
    [Authorize(Roles = "Staff")]
    public class StaffDashboardModel : PageModel
    {
        //Services
        private readonly StaffService _staffService;
        private readonly PatientService _patientService;
        private readonly AccountService _accountService;

        //Staff properties
        public Staff CurrentStaff { get; set; }
        public List<Patient> Patients { get; set; } = [];
        public List<Appointment> Appointments { get; set; } = [];
        public List<MedicalHistory> MedicalHistory { get; set; } = [];
        public Patient? SelectedPatient { get; set; }
		public string ActiveTab { get; set; } = "tab1";

		public StaffDashboardModel(StaffService staffService, PatientService patientService, AccountService accountService)
        {
            _staffService = staffService;
            _patientService = patientService;
            _accountService = accountService;
        }

        public async Task OnGetAsync(int? id, string? tab)
        {
			ActiveTab = tab ?? "tab1";

			var username = User.Identity?.Name;
            var user = await _accountService.GetByUserNameAsync(username);

            if (user?.StaffId != null)
            {
                CurrentStaff = await _staffService.GetByIdAsync(user.StaffId.Value);
                Patients = await _patientService.GetAllAsync();
                Appointments = await _staffService.GetAllAppointmentsByIdAsync(user.StaffId.Value);
            }

            if (id.HasValue)
            {
                SelectedPatient = await _patientService.GetByIdAsync(id.Value);
                if (SelectedPatient != null)
                {
                    MedicalHistory = await _patientService.GetMedicalHistoryByPatientIdAsync(SelectedPatient.Id);
				}
            }
        }
    }
}
