namespace SmartHomeSystem.SmartLight
{

    public class BasicLight : AbstractLight
    {
        public BasicLight()
        {
            Type = LightType.BasicLight;
            Status = LightStatus.Off;
        }

        public override void Turn(bool isOn)
        {
            Status = isOn ? LightStatus.On : LightStatus.Off;
        }

        public override void GetDetails()
        {
            Console.WriteLine($"{Type}: {Status}");
        }
    }

}