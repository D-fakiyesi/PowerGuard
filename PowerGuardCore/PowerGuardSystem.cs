namespace PowerGuardCore;

public class PowerGuardSystem
{
    public List<Appliance> Appliances = new List<Appliance>();

    public double TotalEnergy { get; private set; }
    public double TotalCost { get; private set; }
    public double TotalRuntime { get; private set; }

    public double Tariff { get; set; } = 200;

    public void AddAppliance(
        string name,
        double power,
        double runtime,
        int priority)
    {
        double energy = (power * runtime) / 1000;
        double cost = energy * Tariff;

        Appliance appliance = new Appliance();

        appliance.Name = name;
        appliance.Power = power;
        appliance.Runtime = runtime;
        appliance.Energy = energy;
        appliance.Cost = cost;
        appliance.IsOn = true;
        appliance.Priority = priority;

        Appliances.Add(appliance);

        TotalEnergy += energy;
        TotalCost += cost;
        TotalRuntime += runtime;
    }

    public string GetPowerMode(double batteryLevel)
    {
        if (batteryLevel >= 80)
            return "NORMAL";

        if (batteryLevel >= 50)
            return "MODERATE";

        if (batteryLevel >= 20)
            return "SAVING";

        return "CRITICAL";
    }

    public void ManagePower(double batteryLevel)
    {
        if (batteryLevel < 20)
        {
            foreach (Appliance appliance in Appliances)
            {
                appliance.IsOn = false;
            }

            return;
        }

        if (batteryLevel < 50)
        {
            Appliance? lowestPriority = null;

            foreach (Appliance appliance in Appliances)
            {
                if (lowestPriority == null ||
                    appliance.Priority < lowestPriority.Priority ||
                    (appliance.Priority == lowestPriority.Priority &&
                     appliance.Energy > lowestPriority.Energy))
                {
                    lowestPriority = appliance;
                }
            }

            if (lowestPriority != null)
            {
                lowestPriority.IsOn = false;
            }
        }
    }
}