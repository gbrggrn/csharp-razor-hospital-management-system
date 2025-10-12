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

        public async Task OnPostAsync()
        {
            await _appointmentService.UpdateAppointmentAsync(Appointment);
        }
    }
}
