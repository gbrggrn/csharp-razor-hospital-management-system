using Csharp3_A1.Models;
using Csharp3_A1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Csharp3_A1.Pages.Appointments
{
	[Authorize(Roles = "Staff, Patient")]
    public class AddAppointmentModel : PageModel
    {
		[BindProperty]
		public Appointment Appointment {  get; set; }

		//Services
		private readonly AccountService _accountService;
		private readonly AppointmentService _appointmentService;
		private readonly PatientService _patientService;
		private readonly StaffService _staffService;

		//User properties
		public User? CurrentUser { get; set; }
		public bool IsPatient = false;
		public bool IsStaff = false;

		//View properties
		public SelectList SelectPatients { get; set; }
		public SelectList SelectStaff {  get; set; }

		public AddAppointmentModel(AccountService accountService, AppointmentService appointmentService, PatientService patientService, StaffService staffService)
		{
			_accountService = accountService;
			_appointmentService = appointmentService;
			_patientService = patientService;
			_staffService = staffService;
		}

		public async Task OnGet()
        {
			var username = User.Identity?.Name;
			if (username == null)
				return;

			CurrentUser = await _accountService.GetByUserNameAsync(username);
			if (CurrentUser == null) 
				return;
				
			if (CurrentUser.PatientId != null)
				IsPatient = true;
			if (CurrentUser.StaffId != null)
				IsStaff = true;

			var patients = await _patientService.GetAllAsync();
			var staff = await _staffService.GetAllAsync();

			SelectPatients = new SelectList(patients, "Id", "Name");
			SelectStaff = new SelectList(staff, "Id", "Name");
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var username = User.Identity?.Name;
			if (username == null)
				return Page();

			CurrentUser = await _accountService.GetByUserNameAsync(username);
			if (CurrentUser == null)
				return Page();

			if (CurrentUser.PatientId != null)
				Appointment.PatientId = (int)CurrentUser.PatientId;
			if (CurrentUser.StaffId != null)
				Appointment.StaffId = (int)CurrentUser.StaffId;

			await _appointmentService.AddAppointmentAsync(Appointment);

			return RedirectToPage("/Appointments/Index");
		}
    }
}
