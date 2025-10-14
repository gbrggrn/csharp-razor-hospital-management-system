using Csharp3_A1.Models;
using Csharp3_A1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Csharp3_A1.Pages.Appointments
{
    public class EditAppointmentModel : PageModel
    {
        [BindProperty]
        public Appointment Appointment { get; set; }

        //Service
		private readonly AppointmentService _appointmentService;

		public EditAppointmentModel(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task OnGetAsync(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            if (appointment == null)
                throw new Exception("Appointment not found");
            else
                Appointment = appointment;
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
				return Page();

			var itemToUpdate = await _appointmentService.GetAppointmentByIdAsync(Appointment.Id);
			if (itemToUpdate == null)
				return NotFound();

			itemToUpdate.PatientId = Appointment.PatientId;
			itemToUpdate.StaffId = Appointment.StaffId;
			itemToUpdate.DateOfAppointment = Appointment.DateOfAppointment;
			itemToUpdate.Reason = Appointment.Reason;

			await _appointmentService.UpdateAsync(itemToUpdate);
			return RedirectToPage("/Appointments/Index");
		}

	}
}
