using System.Drawing;
using System.Windows.Forms;

namespace PowerGuardDashboard;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        double batteryLevel = 75;
        double energyUsed = 6.5;
        double tariff = 200;
        double totalRuntime = 12.5;

        double estimatedCost = energyUsed * tariff;

        string powerMode;

        if (batteryLevel >= 80)
        {
            powerMode = "NORMAL";
        }
        else if (batteryLevel >= 50)
        {
            powerMode = "MODERATE";
        }
        else if (batteryLevel >= 20)
        {
            powerMode = "SAVING";
        }
        else
        {
            powerMode = "CRITICAL";
        }

        bool acOn = true;
        bool fridgeOn = true;
        bool microwaveOn = true;

        if (batteryLevel < 50)
        {
            microwaveOn = false;
        }

        if (batteryLevel < 20)
        {
            acOn = false;
            fridgeOn = false;
            microwaveOn = false;
        }

        this.Text = "PowerGuard";
        this.Width = 1000;
        this.Height = 700;
        this.BackColor = Color.FromArgb(25, 25, 35);
        this.StartPosition = FormStartPosition.CenterScreen;

        Label title = new Label();
        title.Text = "⚡ POWERGUARD";
        title.Font = new Font("Arial", 26, FontStyle.Bold);
        title.ForeColor = Color.White;
        title.AutoSize = true;
        title.Location = new Point(35, 25);
        this.Controls.Add(title);

        Label subtitle = new Label();
        subtitle.Text = "Energy Management Dashboard";
        subtitle.Font = new Font("Arial", 12);
        subtitle.ForeColor = Color.LightGray;
        subtitle.AutoSize = true;
        subtitle.Location = new Point(40, 70);
        this.Controls.Add(subtitle);

        Label batteryLabel = new Label();
        batteryLabel.Text = "🔋 Battery Level";
        batteryLabel.Font = new Font("Arial", 14, FontStyle.Bold);
        batteryLabel.ForeColor = Color.White;
        batteryLabel.AutoSize = true;
        batteryLabel.Location = new Point(50, 130);
        this.Controls.Add(batteryLabel);

        Label batteryValue = new Label();
        batteryValue.Text = batteryLevel + "%";
        batteryValue.Font = new Font("Arial", 28, FontStyle.Bold);
        batteryValue.ForeColor = Color.LimeGreen;
        batteryValue.AutoSize = true;
        batteryValue.Location = new Point(50, 165);
        this.Controls.Add(batteryValue);

        Label modeLabel = new Label();
        modeLabel.Text = "⚡ Power Mode";
        modeLabel.Font = new Font("Arial", 14, FontStyle.Bold);
        modeLabel.ForeColor = Color.White;
        modeLabel.AutoSize = true;
        modeLabel.Location = new Point(300, 130);
        this.Controls.Add(modeLabel);

        Label modeValue = new Label();
        modeValue.Text = powerMode;
        modeValue.Font = new Font("Arial", 28, FontStyle.Bold);
        modeValue.ForeColor = Color.Gold;
        modeValue.AutoSize = true;
        modeValue.Location = new Point(300, 165);
        this.Controls.Add(modeValue);

        Label energyLabel = new Label();
        energyLabel.Text = "⚡ Energy Used";
        energyLabel.Font = new Font("Arial", 14, FontStyle.Bold);
        energyLabel.ForeColor = Color.White;
        energyLabel.AutoSize = true;
        energyLabel.Location = new Point(50, 250);
        this.Controls.Add(energyLabel);

        Label energyValue = new Label();
        energyValue.Text = energyUsed + " kWh";
        energyValue.Font = new Font("Arial", 24, FontStyle.Bold);
        energyValue.ForeColor = Color.LightSkyBlue;
        energyValue.AutoSize = true;
        energyValue.Location = new Point(50, 285);
        this.Controls.Add(energyValue);

        Label costLabel = new Label();
        costLabel.Text = "💰 Estimated Cost";
        costLabel.Font = new Font("Arial", 14, FontStyle.Bold);
        costLabel.ForeColor = Color.White;
        costLabel.AutoSize = true;
        costLabel.Location = new Point(300, 250);
        this.Controls.Add(costLabel);

        Label costValue = new Label();
        costValue.Text = "₦" + estimatedCost;
        costValue.Font = new Font("Arial", 24, FontStyle.Bold);
        costValue.ForeColor = Color.LightGreen;
        costValue.AutoSize = true;
        costValue.Location = new Point(300, 285);
        this.Controls.Add(costValue);

        Label runtimeLabel = new Label();
        runtimeLabel.Text = "⏱️ Total Runtime";
        runtimeLabel.Font = new Font("Arial", 14, FontStyle.Bold);
        runtimeLabel.ForeColor = Color.White;
        runtimeLabel.AutoSize = true;
        runtimeLabel.Location = new Point(550, 250);
        this.Controls.Add(runtimeLabel);

        Label runtimeValue = new Label();
        runtimeValue.Text = totalRuntime + " hours";
        runtimeValue.Font = new Font("Arial", 24, FontStyle.Bold);
        runtimeValue.ForeColor = Color.LightYellow;
        runtimeValue.AutoSize = true;
        runtimeValue.Location = new Point(550, 285);
        this.Controls.Add(runtimeValue);

        Label applianceTitle = new Label();
        applianceTitle.Text = "🔌 Appliance Status";
        applianceTitle.Font = new Font("Arial", 17, FontStyle.Bold);
        applianceTitle.ForeColor = Color.White;
        applianceTitle.AutoSize = true;
        applianceTitle.Location = new Point(50, 370);
        this.Controls.Add(applianceTitle);

        Label acStatus = new Label();
        acStatus.Text = acOn
            ? "❄️ AC                 🟢 ON"
            : "❄️ AC                 🔴 OFF";
        acStatus.Font = new Font("Arial", 14);
        acStatus.ForeColor = Color.White;
        acStatus.AutoSize = true;
        acStatus.Location = new Point(50, 420);
        this.Controls.Add(acStatus);

        Label fridgeStatus = new Label();
        fridgeStatus.Text = fridgeOn
            ? "🧊 Fridge             🟢 ON"
            : "🧊 Fridge             🔴 OFF";
        fridgeStatus.Font = new Font("Arial", 14);
        fridgeStatus.ForeColor = Color.White;
        fridgeStatus.AutoSize = true;
        fridgeStatus.Location = new Point(50, 460);
        this.Controls.Add(fridgeStatus);

        Label microwaveStatus = new Label();
        microwaveStatus.Text = microwaveOn
            ? "🍲 Microwave      🟢 ON"
            : "🍲 Microwave      🔴 OFF";
        microwaveStatus.Font = new Font("Arial", 14);
        microwaveStatus.ForeColor = Color.White;
        microwaveStatus.AutoSize = true;
        microwaveStatus.Location = new Point(50, 500);
        this.Controls.Add(microwaveStatus);

        Label warning = new Label();

        if (batteryLevel < 20)
        {
            warning.Text = "🚨 CRITICAL BATTERY — ALL APPLIANCES OFF";
            warning.ForeColor = Color.Red;
        }
        else if (batteryLevel < 50)
        {
            warning.Text = "⚠️ LOW BATTERY — NON-ESSENTIAL APPLIANCES LIMITED";
            warning.ForeColor = Color.Orange;
        }
        else
        {
            warning.Text = "✅ POWER SYSTEM OPERATING NORMALLY";
            warning.ForeColor = Color.LightGreen;
        }

        warning.Font = new Font("Arial", 13, FontStyle.Bold);
        warning.AutoSize = true;
        warning.Location = new Point(50, 560);
        this.Controls.Add(warning);

        Label relayTitle = new Label();
        relayTitle.Text = "🔄 Automatic Switch System";
        relayTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        relayTitle.ForeColor = Color.White;
        relayTitle.AutoSize = true;
        relayTitle.Location = new Point(550, 370);
        this.Controls.Add(relayTitle);

        Label relayStatus = new Label();

        if (batteryLevel < 20)
        {
            relayStatus.Text = "🔴 RELAYS ACTIVE — ALL APPLIANCES DISCONNECTED";
            relayStatus.ForeColor = Color.Red;
        }
        else if (batteryLevel < 50)
        {
            relayStatus.Text = "🟡 RELAYS ACTIVE — NON-ESSENTIAL LOADS LIMITED";
            relayStatus.ForeColor = Color.Gold;
        }
        else
        {
            relayStatus.Text = "🟢 SYSTEM READY — NORMAL LOAD";
            relayStatus.ForeColor = Color.LightGreen;
        }

        relayStatus.Font = new Font("Arial", 13, FontStyle.Bold);
        relayStatus.AutoSize = true;
        relayStatus.Location = new Point(550, 420);
        this.Controls.Add(relayStatus);

        Label summaryTitle = new Label();
        summaryTitle.Text = "📊 System Summary";
        summaryTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        summaryTitle.ForeColor = Color.White;
        summaryTitle.AutoSize = true;
        summaryTitle.Location = new Point(550, 480);
        this.Controls.Add(summaryTitle);

        Label summary = new Label();
        summary.Text =
            "Battery: " + batteryLevel + "%" +
            "\nEnergy: " + energyUsed + " kWh" +
            "\nCost: ₦" + estimatedCost +
            "\nRuntime: " + totalRuntime + " hours";

        summary.Font = new Font("Arial", 13);
        summary.ForeColor = Color.LightGray;
        summary.AutoSize = true;
        summary.Location = new Point(550, 520);
        this.Controls.Add(summary);
    }
}

