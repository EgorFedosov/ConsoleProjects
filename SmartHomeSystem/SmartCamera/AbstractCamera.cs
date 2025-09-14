namespace SmartHomeSystem.SmartCamera
{

    public abstract class AbstractCamera : ISmartCamera
    {
        public enum CameraStatus
        {
            On,
            Off
        };
        
        public CameraStatus Status { get; set; }

        public abstract void Turn(bool isOn);
    }

}