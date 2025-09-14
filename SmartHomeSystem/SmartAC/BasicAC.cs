namespace SmartHomeSystem.SmartAC
{

    public class BasicAC : AbstractAC
    {
        public BasicAC()
        {
            Status = ACStatus.Off;
            Type = ACType.BasicAC;
            Temp = 17;
        }
        
        public override void GetDetails()
        {
            if (Status == ACStatus.Off)
            {
                Console.WriteLine($"{Type}: {Status}");
            } else Console.WriteLine($"{Type}: {Status}, Temperature: {Temp}");
        }

        public override void Turn(bool isOn)
        {
            Status = isOn ? ACStatus.On : ACStatus.Off;
        }


        public override void SetTemp(int temp)
        {
            Temp = temp;
        }
    }

}