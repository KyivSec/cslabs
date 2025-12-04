namespace HospitalManagementSystem {
    public class HospitalDemo {
        public void Run() {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            Doctor doctorOne = new Doctor(1, "Джордж Флойдович", "Терапевт");
            Doctor doctorTwo = new Doctor(2, "Чарлі Кіркович", "Хірург");
            Doctor doctorThree = new Doctor(3, "Дональд Трамп", "Кардіолог");

            hospital.AddDoctor(doctorOne);
            hospital.AddDoctor(doctorTwo);
            hospital.AddDoctor(doctorThree);

            Patient patientOne = new Patient(1, "Володя Механік", 55);
            Patient patientTwo = new Patient(2, "Оксана Манікюр", 28);
            Patient patientThree = new Patient(3, "Вова СБУ", 34);
            Patient patientFour = new Patient(4, "Богдан Адвокат", 40);

            hospital.RegisterPatient(patientOne);
            hospital.RegisterPatient(patientTwo);
            hospital.RegisterPatient(patientThree);
            hospital.RegisterPatient(patientFour);

            HospitalRoom roomOne = new HospitalRoom(101, 2);
            HospitalRoom roomTwo = new HospitalRoom(102, 2);
            HospitalRoom roomThree = new HospitalRoom(201, 1);

            hospital.CreateRoom(roomOne);
            hospital.CreateRoom(roomTwo);
            hospital.CreateRoom(roomThree);

            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 102);
            hospital.HospitalizePatient(4, 201);
            hospital.HospitalizePatient(4, 201);

            MedicalRecord recordOne = new MedicalRecord(
                patientOne,
                doctorOne,
                DateTime.Today.AddDays(-2),
                "Звичайний огляд, призначено аналізи.");

            MedicalRecord recordTwo = new MedicalRecord(
                patientOne,
                doctorTwo,
                DateTime.Today.AddDays(-1),
                "Проведено операцію.");

            MedicalRecord recordThree = new MedicalRecord(
                patientThree,
                doctorThree,
                DateTime.Today,
                "Обстеження серця, призначено лікування.");

            hospital.AddMedicalRecord(recordOne);
            hospital.AddMedicalRecord(recordTwo);
            hospital.AddMedicalRecord(recordThree);

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            List<MedicalRecord> history = hospital.GetPatientHistory(1);

            for (int index = 0; index < history.Count; index++)
            {
                MedicalRecord record = history[index];

                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            Console.WriteLine(hospital.GetStatistics());
        }
    }
}