using Godot;
using System;

public partial class Shuriken : CharacterBody2D
{
    [Export] public Vector2 ShuriVelocity;

    [Export] float RotSpeed;

    [Export] GpuParticles2D ShuriImpact;

    [Export] Sprite2D ShuriGraphic;

    double Lifetime = 20;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = ShuriVelocity;

        ShuriGraphic.Rotate(RotSpeed * (float)delta);

        MoveAndSlide();

        Lifetime -= delta;

        if (Lifetime < 0) CallDeferred(MethodName.QueueFree);
        base._PhysicsProcess(delta);
    }

    public void Strike(Node2D body)
    {
        ShuriImpact.Reparent(GetTree().Root);
        ShuriImpact.Emitting = true;
        if(body.IsInGroup("Fih"))
        {
            (body as MeenData).Die("ya got shuriken'd");
        }

        QueueFree();
    }

}
