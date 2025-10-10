using Csharp3_A1.Data;
using Csharp3_A1.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp3_A1.Services
{
	public class PatientService
	{
		private readonly AppDbContext _context;

		public PatientService(AppDbContext context)
		{
			_context = context;
		}

		//Logic

		public async Task<List<Patient>> GetAllAsync() => await _context.Patients.ToListAsync();

		public async Task<Patient?> GetByIdAsync(int id) => await _context.Patients.FindAsync(id);

		public async Task AddAsync(Patient patient)
		{
			_context.Patients.Add(patient);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Patient patient)
		{
			_context.Patients.Update(patient);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAppointmentsAsync(int patientId, Appointment appointment)
		{
			var patient = await _context.Patients.FindAsync(patientId);

			if (patient == null)
			{
				throw new Exception("Patient not found");
			}

			patient.Appointments.Add(appointment);
			await _context.SaveChangesAsync();
		}

		//Move to appointmentservice
		public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
		{
			return await _context.Appointments.Where(a => a.PatientId == patientId).Include(a => a.Staff).ToListAsync();
		}

		public async Task<List<MedicalHistory>> GetMedicalHistoryByPatientIdAsync(int patientId)
		{
			return await _context.MedicalHistories.Where(m => m.PatientId == patientId).ToListAsync();
		}
	}
}
