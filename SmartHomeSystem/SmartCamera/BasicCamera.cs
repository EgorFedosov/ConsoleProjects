namespace SmartHomeSystem.SmartCamera
{

    public class BasicCamera : AbstractCamera
    {
        public BasicCamera()
        {
            Status = CameraStatus.On;
        }

        public override void Turn(bool isOn)
        {
            Status = isOn ? CameraStatus.On : CameraStatus.Off;
        }
    }

}