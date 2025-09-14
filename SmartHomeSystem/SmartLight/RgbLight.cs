namespace SmartHomeSystem.SmartLight
{

    public class RgbLight : BasicLight
    {
        public enum LightColor
        {
            White,
            Red,
            MutedYellow,
            Blue,
            Pink
        };

        private LightColor _color;
        public LightColor Color { get; set; }

        public RgbLight() : base()
        {
            Type = LightType.RgbLight;
            Color = LightColor.White;
        }

        public override void GetDetails()
        {
            if (Status == LightStatus.Off)
            {
                Console.WriteLine($"{Type}: {Status}");
            } else Console.WriteLine($"{Type}: {Status}, Color: {Color}");
        }

        public void SetStatus(LightStatus status, LightColor color)
        {
            base.SetStatus(status);
            SetLightColor(color);
        }

        public void SetLightColor(LightColor color)
        {
            Color = color;
        }
    }

}