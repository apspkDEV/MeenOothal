using Godot;
using System;

public partial class MeenData : RigidBody2D
{
    [Signal]
    public delegate void FihDedEventHandler();

    public override void _Ready()
    {
        base._Ready();
    }

    public void Die()
    {
        EmitSignal(SignalName.FihDed);
    }
}
