using Godot;
using System;

public partial class Shuriken : CharacterBody2D
{
    [Export] Vector2 BulletVelocity;

    [Export] float RotSpeed;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = BulletVelocity;

        Rotate(RotSpeed * (float)delta);

        MoveAndSlide();
        base._PhysicsProcess(delta);
    }

    public void Strike(Node2D body)
    {
        if(body.IsInGroup("Fih"))
        {
            (body as MeenData).Die();
        }
    }

}
