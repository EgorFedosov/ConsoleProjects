namespace SmartHomeSystem.SmartAC
{

    public abstract class AbstractAC : ISmartAC
    {
        public enum ACType
        {
            BasicAC,
            AdvancedAC,
            AromaAC
        };

        public enum ACStatus
        {
            On,
            Off
        };

        private int _temp;
        public int Temp
        {
            get => _temp;
            set
            {
                if (value < 10)
                    _temp = 10;

                else if (value > 24)
                    _temp = 25;

                else _temp = value;
            }
        }

        public ACStatus Status { get; set; }
        public ACType Type { get; set; }

        public abstract void Turn(bool isOn);
        public abstract void GetDetails();
        public abstract void SetTemp(int temp);

        public virtual void Settings(bool isOn, int temp)
        {
            Turn(isOn);
            SetTemp(temp);
        }
    }

}