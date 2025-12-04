namespace SmartHomeSystem {
    public class Program {
        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SmartHomeController controller = new SmartHomeController();

            Light livingRoomLight = new Light();
            livingRoomLight.Name = "Лампа у вітальні";

            AirConditioner bedroomAirConditioner = new AirConditioner();
            bedroomAirConditioner.Name = "Кондиціонер у спальні";

            CoffeeMachine kitchenCoffeeMachine = new CoffeeMachine();
            kitchenCoffeeMachine.Name = "Кавомашина на кухні";

            MotionSensor hallMotionSensor = new MotionSensor();
            hallMotionSensor.Name = "Датчик руху у коридорі";

            controller.AddDevice(livingRoomLight);
            controller.AddDevice(bedroomAirConditioner);
            controller.AddDevice(kitchenCoffeeMachine);
            controller.AddDevice(hallMotionSensor);

            controller.AddEnergyDevice(livingRoomLight);
            controller.AddEnergyDevice(bedroomAirConditioner);
            controller.AddEnergyDevice(kitchenCoffeeMachine);

            controller.TurnAllOn();

            livingRoomLight.PrintStatus();
            bedroomAirConditioner.PrintStatus();
            kitchenCoffeeMachine.PrintStatus();
            hallMotionSensor.PrintStatus();

            controller.ShowEnergyReport(5);

            controller.TurnAllOff();
        }
    }
}
