namespace SmartHomeSystem.SmartLight
{

    public abstract class AbstractLight : ISmartLight
    {
        public enum LightType
        {
            BasicLight,
            RgbLight,
            PartyLight
        };

        public enum LightStatus
        {
            On,
            Off
        };
        
        public LightStatus Status { get; set; }
        public LightType Type { get; set; }

        public abstract void Turn(bool isOn);

        public abstract void GetDetails();

        public virtual void SetStatus(LightStatus status)
        {
            if (status == LightStatus.On)
                Turn(true);
            else
                Turn(false);

            Status = status;
        }
    }

}