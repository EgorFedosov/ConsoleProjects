using SmartHomeSystem.SmartAC;
using SmartHomeSystem.SmartCamera;
using SmartHomeSystem.SmartLight;

namespace SmartHomeSystem
{

    public class Controller
    {
        public enum Scenario
        {
            Home,
            Leave,
            GoodNight,
            GoodMorning,
            Party
        }

        private Scenario _currentScenario;

        private List<ISmartLight> _allLights = new(64);
        private List<ISmartAC> _allAcs = new(32);
        private List<ISmartCamera> _allCameras = new(32);

        public Controller()
        {
            InitializeLights();
            InitializeCameras();
            InitializeACs();
        }

        private void InitializeLights()
        {
            for (var i = 0; i < 5; i++) _allLights.Add(new BasicLight());

            for (var i = 0; i < 3; i++) _allLights.Add(new PartyLight());

            for (var i = 0; i < 2; i++) _allLights.Add(new RgbLight());
        }

        private void InitializeCameras()
        {
            for (var i = 0; i < 10; i++) _allCameras.Add(new BasicCamera());
        }

        private void InitializeACs()
        {
            for (var i = 0; i < 2; i++) _allAcs.Add(new BasicAC());

            for (var i = 0; i < 2; i++) _allAcs.Add(new AdvancedAC());

            for (var i = 0; i < 2; i++) _allAcs.Add(new AromaAC());
        }

        private void HomeScenario()
        {
            var basicLightCount = 0;
            var rgbLightCount = 0;
            foreach (var light in _allLights)
            {
                light.Turn(false);
                if (light is BasicLight && basicLightCount < 5)
                {
                    basicLightCount++;
                    light.Turn(true);
                }

                else if (light is RgbLight rgbLight && rgbLightCount <= 2)
                {
                    rgbLightCount++;
                    rgbLight.Turn(true);
                    rgbLight.SetLightColor(RgbLight.LightColor.MutedYellow);
                }
            }

            var basicAcCount = 0;
            foreach (var ac in _allAcs)
            {
                ac.Turn(false);

                if (ac is BasicAC basicAc && basicAcCount < 2)
                {
                    basicAcCount++;
                    basicAc.Settings(true, 17);
                }
            }
        }

        private void LeaveScenario()
        {
            foreach (var light in _allLights) light.Turn(false);

            foreach (var ac in _allAcs) ac.Turn(false);
        }

        private void GoodNightScenario()
        {
            var rgbLightCount = 0;
            foreach (var light in _allLights)
            {
                light.Turn(false);
                if (light is RgbLight rgbLight && rgbLightCount <= 1)
                {
                    rgbLightCount++;
                    rgbLight.Turn(true);
                    rgbLight.SetLightColor(RgbLight.LightColor.MutedYellow);
                }
            }

            foreach (var ac in _allAcs)
            {
                ac.Turn(false);

                if (ac is AromaAC aromaAc)
                {
                    aromaAc.Settings(true, 15, AdvancedAC.FlowSpeed.Low, AromaAC.FlowZone.All, AromaAC.ScentAC.Eucalyptus);
                    break;
                }
            }
        }

        private void GoodMorningScenario()
        {
            var basicAcCount = 0;
            foreach (var ac in _allAcs)
            {
                ac.Turn(false);
                if (ac is BasicAC basicAc && basicAcCount < 2)
                {
                    basicAc.Settings(true, 17);
                    basicAcCount++;
                }
            }

            foreach (var light in _allLights) light.Turn(false);
        }

        private void PartyScenario()
        {
            var random = new Random();
            foreach (var light in _allLights)
            {
                light.Turn(false);
                if (light is RgbLight rgbLight)
                {
                    rgbLight.Turn(true);
                    rgbLight.SetLightColor((RgbLight.LightColor)random.Next(0, 5));
                }
                else if (light is PartyLight partyLight)
                {
                    partyLight.Turn(true);
                    partyLight.SetStatus(AbstractLight.LightStatus.On, RgbLight.LightColor.Red, PartyLight.DiscoLight.On);
                }
            }

            foreach (var ac in _allAcs)
            {
                ac.Turn(false);
                if (ac is AromaAC aromaAc)
                {
                    aromaAc.Settings(true, 18, AdvancedAC.FlowSpeed.Medium, AromaAC.FlowZone.All, AromaAC.ScentAC.Freshness);
                }
                else
                {
                    ac.Turn(true);
                }
            }
        }

        public void SetScenario(Scenario scenario)
        {
            _currentScenario = scenario;
            switch (scenario)
            {
                case Scenario.Home:
                    HomeScenario();
                    break;

                case Scenario.Leave:
                    LeaveScenario();
                    break;

                case Scenario.GoodNight:
                    GoodNightScenario();
                    break;

                case Scenario.GoodMorning:
                    GoodMorningScenario();
                    break;

                case Scenario.Party:
                    PartyScenario();
                    break;

                default:
                    Console.WriteLine("unknown scenario");
                    break;
            }
        }

        public void DeviceInfo()
        {
            Console.WriteLine($"House condition: \n" +
                              $" Current scenario: {_currentScenario} ");
            var lightOn = _allLights.Count(light => light.Status == AbstractLight.LightStatus.On);
            var acOn = _allAcs.Count(ac => ac.Status == AbstractAC.ACStatus.On);
            var cameraOn = _allCameras.Count(camera => camera.Status == AbstractCamera.CameraStatus.On);

            Console.WriteLine($"Light: \n " +
                              $"{lightOn} out of {_allLights.Count} work");
            foreach (var light in _allLights)
            {
                light.GetDetails();
            }
            Console.WriteLine();
            Console.WriteLine($"AC: \n " +
                              $"{acOn} out of {_allAcs.Count} work");
            foreach (var ac in _allAcs)
            {
               ac.GetDetails();
            }
            Console.WriteLine();
            Console.WriteLine($"Cameras: \n " +
                              $"{cameraOn} out of {_allCameras.Count} work");
        }
    }

}