using Godot;
using System;

public partial class Ninja : Node2D
{
    [Export] PackedScene Shuriken;

    [Export] float ShootSpeed;

    [Export] double ShootRate;

    [Export] Timer ShootCD;

    public override void _Ready()
    {
        if(ShootRate > 0) ShootCD.WaitTime = ShootRate;
        base._Ready();
    }


    public void Fire()
    {
        Shuriken ShuriInst = Shuriken.Instantiate() as Shuriken;
        GetTree().Root.AddChild(ShuriInst);
        ShuriInst.GlobalPosition = GlobalPosition;
        ShuriInst.ShuriVelocity = GlobalTransform.Y * ShootSpeed;
    }
}
