using Godot;
using System;

public partial class MeenData : RigidBody2D
{
    [Signal]
    public delegate void FihDedEventHandler();

    [Export] MeenControls FihControls;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        if(GlobalPosition.Y > 1500)
        {
            Die("dawg how did you even achieve this one");
        }
        base._PhysicsProcess(delta);
    }


    public void Die(string WoD)
    {
        GameManager.DeathMsg = WoD;
        FihControls.IsDed = true;
        EmitSignal(SignalName.FihDed);
    }
}
