using SmartHomeSystem.SmartLight;

namespace SmartHomeSystem.SmartAC
{

    public interface ISmartAC
    {
        void Turn(bool isOn);
        AbstractAC.ACStatus Status { get; set; }
        void GetDetails(); 
    }

}