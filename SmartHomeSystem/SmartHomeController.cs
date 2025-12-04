namespace SmartHomeSystem {
    public class SmartHomeController {
        private readonly List<ISwitchable> devices = new List<ISwitchable>();
        private readonly List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device) { devices.Add(device); }
        public void AddEnergyDevice(IEnergyConsumer device) { energyDevices.Add(device); }

        public void TurnAllOn() {
            for (int index = 0; index < devices.Count; index++) devices[index].TurnOn();
        }

        public void TurnAllOff() {
            for (int index = 0; index < devices.Count; index++) devices[index].TurnOff();
        }

        public void ShowEnergyReport(int hours) {
            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

            double total = 0;

            for (int index = 0; index < energyDevices.Count; index++) {
                IEnergyConsumer device = energyDevices[index];
                double energy = device.GetEnergyUsage(hours);
                total += energy;

                Console.WriteLine($"{device.DeviceName}: {energy:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            }

            Console.WriteLine($"Загальне споживання: {total:F2} кВт·год");
            double price = total * 4;
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {price:F2} грн");
        }
    }
}
