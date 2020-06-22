using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }
    public Car(string model, Engine engine, double weight)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
    }
    public Car(string model, Engine engine, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Color = color;
    }
    public Car(string model, Engine engine, double weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string displacement = this.Engine.Displacement != 0.0 ? this.Engine.Displacement.ToString() : "n/a";
        string efficiency = this.Engine.Efficiency != string.Empty && this.Engine.Efficiency != null ? this.Engine.Efficiency : "n/a";
        string weight = this.Weight != 0 ? this.Weight.ToString() : "n/a";
        string color = this.Color != string.Empty && this.Color != null ? this.Color : "n/a";

        sb.AppendLine($"{this.Model}:");
        sb.AppendLine($"  {this.Engine.Model}:");
        sb.AppendLine($"    Power: {this.Engine.Power}");
        sb.AppendLine($"    Displacement: {displacement}");
        sb.AppendLine($"    Efficiency: {efficiency}");
        sb.AppendLine($"  Weight: {weight}");
        sb.AppendLine($"  Color: {color}");

        return sb.ToString();
    }
}

