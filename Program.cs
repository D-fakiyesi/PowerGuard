using System;
using System.IO;
using System.Collections.Generic;

class Appliance
{
    public string Name { get; set; }
    public double Power { get; set; }
    public double Runtime { get; set; }
    public double Energy { get; set; }
    public double Cost { get; set; }
    public bool IsOn { get; set; }
    public int Priority { get; set; }
}

class Program
{
    static void Main()
    {
        List<Appliance> appliances = new List<Appliance>();

        double totalEnergy = 0;
        double totalCost = 0;
        double totalRuntime = 0;

        Console.WriteLine("================================");
        Console.WriteLine("        POWERGUARD ⚡");
        Console.WriteLine("================================");

        Console.Write("Enter appliance name:");
        string applianceName = Console.ReadLine();

        Console.WriteLine("Enter your appliance power here (watts):");
        double power = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter your runtime (hours): ");
        double runtime = Convert.ToDouble(Console.ReadLine());

        double powerKw = power / 1000; // Convert watts to kilowatts
        double energy = powerKw * runtime; // Calculate energy in kwh

        Console.WriteLine();
        Console.WriteLine($"Energy used: {energy} kwh");

        Console.WriteLine("Enter electricity tariff (Naira per kwh):");
        double tariff = Convert.ToDouble(Console.ReadLine());

        double cost = energy * tariff; //Calculate cost in Naira

        Console.WriteLine($"Estimated cost:  ₦{cost}");

        File.AppendAllText("usage_history.txt", $"Appliance: {applianceName} | Runtime: {runtime} hours | Energy: {energy} kwh | Cost: ₦{cost}\n");

        totalEnergy += energy;
        totalCost += cost;
        totalRuntime += runtime;

        Console.Write("Enter appliance priority (1 = High, 2 = Medium, 3 = Low): ");
        int priority = Convert.ToInt32(Console.ReadLine());

        Appliance firstAppliance = new Appliance
        {
            Name = applianceName,
            Power = power,
            Runtime = runtime,
            Energy = energy,
            Cost = cost,
            IsOn = true,
            Priority = priority
        };

        appliances.Add(firstAppliance);

        Console.WriteLine();
        Console.WriteLine("Would you like to enter another appliance? (y/n)");

        string answer = Console.ReadLine();

        while (answer == "y")
        {
            Console.WriteLine("Enter appliance name: ");
            applianceName = Console.ReadLine();

            Console.WriteLine("Enter your appliance power here (watts): ");
            power = Convert.ToDouble(Console.ReadLine());   
            
            Console.WriteLine("Enter runtime (hours): ");
            runtime = Convert.ToDouble(Console.ReadLine());

            powerKw = power / 1000; // Convert watts to kilowatts
            energy = powerKw * runtime; // Calculate energy in kwh

            Console.WriteLine($"Energy used: {energy} kwh");

            Console.WriteLine("Enter electricity tariff (Naira per kwh): ");
            tariff = Convert.ToDouble(Console.ReadLine());

            cost = energy * tariff; // Calculate cost in Naira

            Console.WriteLine($"Estimated cost: ₦{cost}");

            File.AppendAllText("usage_history.txt", $"Appliance: {applianceName} | Runtime: {runtime} hours | Energy: {energy} kwh | Cost: ₦{cost}\n");

            totalEnergy += energy;
            totalCost += cost;
            totalRuntime += runtime;

            Console.Write("Enter appliance priority (1 = High, 2 = Medium, 3 = Low): ");
            int newPriority = Convert.ToInt32(Console.ReadLine());

            Appliance appliance = new Appliance
            {
                Name = applianceName,
                Power = power,
                Runtime = runtime,
                Energy = energy,
                Cost = cost,
                IsOn = true,
                Priority = newPriority
            };

            appliances.Add(appliance);

            Console.WriteLine();
            Console.WriteLine("Would you like to enter another appliance? (y/n)");
            answer = Console.ReadLine();
        }

        // Display summary
        Console.WriteLine();
        Console.WriteLine("========== POWERGUARD SUMMARY ==========");
        Console.WriteLine($"Total runtime: {totalRuntime} hours");
        Console.WriteLine($"Total energy used: {totalEnergy} kwh");
        Console.WriteLine($"Total estimated cost: ₦{totalCost}");
        Console.WriteLine("=========================================");

        // View usage history
        Console.WriteLine();
        Console.WriteLine("Would you like to view your usage history? (y/n)");
        string viewHistory = Console.ReadLine();

        if (viewHistory == "y")
        {
            Console.WriteLine();
            Console.WriteLine("========== USAGE HISTORY ==========");

            string history = File.ReadAllText("usage_history.txt");
            Console.WriteLine(history);

            Console.WriteLine("===================================");
        }

        Console.WriteLine();
        Console.WriteLine("============ APPLIANCES ============");

        foreach (Appliance appliance in appliances)
        {
            Console.WriteLine($"Name: {appliance.Name}");
            Console.WriteLine($"Power: {appliance.Power} W");
            Console.WriteLine($"Runtime: {appliance.Runtime} hours");
            Console.WriteLine($"Energy: {appliance.Energy} kWh");
            Console.WriteLine($"Cost: ₦{appliance.Cost}");
            Console.WriteLine("-----------------------------------");
        }

        Console.WriteLine("==================================");

        // Find the highest energy user
        double highestEnergy = 0;
        Appliance highestEnergyAppliance = null;

        foreach (Appliance appliance in appliances)
        {
            if (appliance.Energy > highestEnergy)
            {
                highestEnergy = appliance.Energy;
                highestEnergyAppliance = appliance;
            }
        }

        Console.WriteLine();
        Console.WriteLine("========== HIGHEST ENERGY USER ==========");

        if (highestEnergyAppliance != null)
        {
            Console.WriteLine($"Appliance: {highestEnergyAppliance.Name}");
            Console.WriteLine($"Energy: {highestEnergyAppliance.Energy} kWh");
            Console.WriteLine($"Cost: ₦{highestEnergyAppliance.Cost}");
        }
        else
        {
            Console.WriteLine("No appliances recorded.");
        }

        Console.WriteLine("=========================================");

        Console.WriteLine();

        if (highestEnergyAppliance != null && highestEnergyAppliance.Energy > 1)
        {
            Console.WriteLine("⚠ POWERGUARD RECOMMENDATION");
            Console.WriteLine($"{highestEnergyAppliance.Name} is using a relatively high amount of energy");
            Console.WriteLine("Consider reducing its runtime where approprate");
        }
        else
        {
            Console.WriteLine("✓ PowerGuard: No high energy usage detected.");
        }

        Console.WriteLine();
        Console.Write("Enter current battery level (%): ");
        double batterylevel = Convert.ToDouble(Console.ReadLine());

        string powerMode;

        if (batterylevel >= 80)
        {
            powerMode = "NORMAL";
        }
        else if (batterylevel >= 50)
        {
            powerMode = "MODERATE";
        }
        else if (batterylevel >= 20)
        {
            powerMode = "SAVING";
        }
        else
        {
           powerMode = "CRITICAL";
        }

        Console.WriteLine($"Power mode: {powerMode}");

        if (batterylevel < 50 && appliances.Count > 0)
        {
            Console.WriteLine("⚠ LOW BATTERY WARNING");

            Appliance lowestPriorityAppliance = appliances[0];

            foreach (Appliance appliance in appliances)
            {
                if ((appliance.Priority > lowestPriorityAppliance.Priority) ||
                    (appliance.Priority == lowestPriorityAppliance.Priority && appliance.Energy > lowestPriorityAppliance.Energy))
                {
                    lowestPriorityAppliance = appliance;
                }
            }

            Console.WriteLine($"Consider reducing usage of {lowestPriorityAppliance.Name} to conserve battery.");

            lowestPriorityAppliance.IsOn = false;

            Console.WriteLine($"🔴 {lowestPriorityAppliance.Name} → OFF");
        }

        if (batterylevel < 20)
        {
            Console.WriteLine();
            Console.WriteLine("⚠ CRITICAL BATTERY MODE");
            Console.WriteLine("PowerGuard is switching off all appliances to conserve battery.");

            foreach (Appliance appliance in appliances)
            {
                appliance.IsOn = false;
            }   
        }

        Console.WriteLine();
        Console.WriteLine("========== POWER STATUS ==========");

        foreach (Appliance appliance in appliances)
        {
            if (appliance.IsOn)
            {
                Console.WriteLine($"🟢 {appliance.Name} → ON");
            }
            else
            {
                Console.WriteLine($"🔴 {appliance.Name} → OFF");
            }
        }
    }
}
