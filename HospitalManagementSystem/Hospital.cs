namespace HospitalManagementSystem {
    public class Hospital {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HospitalRoom> Rooms { get; set; }
        public List<MedicalRecord> Records { get; set; }

        public Hospital() {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        public void AddDoctor(Doctor doctor) {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
        }

        public void RegisterPatient(Patient patient) {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
        }

        public void CreateRoom(HospitalRoom room) {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
        }

        public void HospitalizePatient(int patientId, int roomNumber) {
            Patient patient = Patients.Find(p => p.Id == patientId);
            if (patient == null) {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
                return;
            }

            HospitalRoom room = Rooms.Find(r => r.RoomNumber == roomNumber);
            if (room == null) {
                Console.WriteLine($"Палата №{roomNumber} не знайдена!");
                return;
            }

            room.AddPatient(patient);
        }

        public void AddMedicalRecord(MedicalRecord record) {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
        }

        public List<MedicalRecord> GetPatientHistory(int patientId) {
            List<MedicalRecord> result = new List<MedicalRecord>();

            for (int index = 0; index < Records.Count; index++) {
                MedicalRecord record = Records[index];
                if (record.Patient.Id == patientId) result.Add(record);
            }

            return result;
        }

        public string GetStatistics() {
            int totalPatientsInRooms = 0;

            for (int roomIndex = 0; roomIndex < Rooms.Count; roomIndex++) totalPatientsInRooms += Rooms[roomIndex].Patients.Count;

            string result =
                "\n=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                $"Кількість лікарів: {Doctors.Count}\n" +
                $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                $"Кількість палат: {Rooms.Count}\n" +
                $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
                $"Кількість медичних записів: {Records.Count}\n";

            return result;
        }
    }
}