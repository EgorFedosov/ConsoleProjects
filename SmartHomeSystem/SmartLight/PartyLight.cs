namespace SmartHomeSystem.SmartLight
{

    public class PartyLight : RgbLight
    {
        public enum DiscoLight
        {
            On,
            Off
        };
        
        public DiscoLight Disco { get; set; }

        public PartyLight() : base()
        {
            Type = LightType.PartyLight;
            Disco = DiscoLight.Off;
        }

        public override void GetDetails()
        {
            if (Status == LightStatus.Off)
            {
                Console.WriteLine($"{Type}: {Status}");
            } else Console.WriteLine($"{Type}: {Status}, Color: {Color}, Disco mode: {Disco}");
        }

        public void SetStatus(LightStatus status, LightColor color, DiscoLight discoLight)
        {
            base.SetStatus(status, color);
            if (discoLight == DiscoLight.On)
            {
                SetDiscoMode(true);
            } else SetDiscoMode(false);
        }
        
        public void SetDiscoMode(bool isDisco)
        {
            Disco = isDisco ? DiscoLight.On : DiscoLight.Off;
        }
    }

}