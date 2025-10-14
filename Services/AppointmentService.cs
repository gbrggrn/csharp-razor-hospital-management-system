using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A1.Services
{
	public class AppointmentService
	{
		private readonly AppDbContext _context;
		
		public AppointmentService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
		{
			return await _context.Appointments.Where(a => a.PatientId == patientId).Include(a => a.Staff).ToListAsync();
		}

		public async Task<List<Appointment>> GetAppointmentsByStaffIdAsync(int staffId)
		{
			return await _context.Appointments.Where(a => a.StaffId == staffId).Include(a => a.Patient).ToListAsync();
		}

		public async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
		{
			//Refactored
			return await _context.Appointments.Include(a => a.Patient).Include(a => a.Staff).FirstOrDefaultAsync(a => a.Id == appointmentId);
			
			//Explicit
			/*var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
			var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == appointment.PatientId);
			var staff = await _context.Staff.FirstOrDefaultAsync(s => s.Id == appointment.StaffId);

			appointment.Staff = staff;
			appointment.Patient = patient;

			return appointment;*/
		}

		public async Task DeleteAppointmentByIdAsync(int id)
		{
			await _context.Appointments.Where(a => a.Id == id).ExecuteDeleteAsync();
			await _context.SaveChangesAsync();
		}

		/*public async Task UpdateAppointmentAsync(Appointment appointment)
		{
			_context.Appointments.Update(appointment);
			await _context.SaveChangesAsync();
		}*/

		public async Task AddAppointmentAsync(Appointment appointment)
		{
			await _context.Appointments.AddAsync(appointment);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Appointment appointment)
		{
			var itemToUpdate = await _context.Appointments.FindAsync(appointment.Id);
			if (itemToUpdate == null)
				return;

			itemToUpdate.PatientId = appointment.PatientId;
			itemToUpdate.StaffId = appointment.StaffId;
			itemToUpdate.DateOfAppointment = appointment.DateOfAppointment;
			itemToUpdate.Reason = appointment.Reason;

			await _context.SaveChangesAsync();
		}
	}
}
