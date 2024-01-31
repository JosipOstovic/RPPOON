using System;
using System.Collections.Generic;

    public class Equipment
    {
        public string Brand{get; private set;}
    }

    public class CarConfigurator //originator
    {
        public string Model { get; set; }
        private List<Equipment> additionalEquipment = new List<Equipment>();
        public void AddExtra(Equipment package) { additionalEquipment.Add(package); }
        public void Remove(Equipment package) { additionalEquipment.Remove(package); }
        public CarConfiguration Store() { return new CarConfiguration(Model, additionalEquipment); }
    }

    public class CarConfiguration //memento
    {
        private string model;
        private List<Equipment> additionalEquipment;
        public CarConfiguration(string model, List<Equipment> additionalEquipment)
        {
            this.model = model;
            this.additionalEquipment = new List<Equipment>(additionalEquipment);
        }
        public string GetModel() { return model; }
        public List<Equipment> GetPackages() { return additionalEquipment; }
    }

    public class ConfigurationManger //caretaker
    {
        private List<CarConfiguration> configurations = new List<CarConfiguration>();
        public void AddConfiguration(CarConfiguration configuration) { configurations.Add(configuration); }
        public CarConfiguration GetConfiguration(int index) { return configurations[index]; }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
        CarConfigurator configurator = new CarConfigurator();
        ConfigurationManger manager = new ConfigurationManger();

        configurator.Model = "Model J";
        configurator.AddExtra(new Equipment());
        manager.AddConfiguration(configurator.Store());

        configurator.Model = "Model O";
        configurator.AddExtra(new Equipment());
        manager.AddConfiguration(configurator.Store());
        configurator.Model = manager.GetConfiguration(0).GetModel();
    }
}