namespace SmartHomeSystem.SmartAC
{

    public class AdvancedAC : BasicAC
    {
        public enum FlowSpeed
        {
            Low,
            Medium,
            High
        };

        public FlowSpeed Speed { get; set; }

        public AdvancedAC() : base()
        {
            Type = ACType.AdvancedAC;
            Speed = FlowSpeed.Medium;
        }
        
        public override void GetDetails()
        {
            if (Status == ACStatus.Off)
            {
                Console.WriteLine($"{Type}: {Status}");
            }else Console.WriteLine($"{Type}: {Status}, Temperature: {Temp}, Speed: {Speed}");
        }

        public void ChangeSpeed(FlowSpeed speed)
        {
            Speed = speed;
        }

        public void Settings(bool isOn, int temp, FlowSpeed speed)
        {
            base.Settings(isOn, temp);
            ChangeSpeed(speed);
        }
    }

}