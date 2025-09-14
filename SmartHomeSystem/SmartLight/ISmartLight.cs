namespace SmartHomeSystem.SmartLight
{

    public interface ISmartLight
    {
        void Turn(bool isOn);
        void GetDetails();
        AbstractLight.LightStatus Status{ get; set; }
    }

}