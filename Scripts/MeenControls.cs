using Godot;
using System;

public partial class MeenControls : RigidBody2D
{
    [Export] CollisionShape2D GumCol;
    [Export] Sprite2D GumSpr;

    [Export] float GrowRate;

    [Export] float RiseRate;

    [Export] float TiltForce;

    [Export] float MinRadius;

    [Export] float MaxRadius;

    [Export] float MinShape;

    CircleShape2D GumShape;

    bool SprFixed = true;

    bool Inflating = false;

    public bool IsDed = false;

    public override void _Ready()
    {
        GumShape = GumCol.Shape as CircleShape2D;
        MinRadius = GumShape.Radius;
        MinShape = GumSpr.Scale.Length();
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        SprFixed = GumShape.Radius == MinRadius || GumShape.Radius == MaxRadius;

        if(Input.IsActionPressed("Inflate") && !IsDed)
        {
            Inflating = true;
            GumShape.Radius += GrowRate*(float)delta;
            if(!SprFixed) GumSpr.Scale += GumSpr.Scale.Normalized() * 2 * GrowRate * (float)delta;
            ApplyCentralForce(-GetGravity() + Vector2.Up * RiseRate);
        }

        else
        {
            Inflating = false;
            GumShape.Radius -= GrowRate * (float)delta * 10;
            if(!SprFixed) 
            {
                GumSpr.Scale -= GumSpr.Scale.Normalized() * 2 * GrowRate * (float)delta * 10;
            }
            else
            {
                GumSpr.Scale = GumSpr.Scale.Normalized() * MinShape;
            }
        }

        GumShape.Radius = Mathf.Clamp(GumShape.Radius, MinRadius, MaxRadius);


        if(Inflating)
        {
            if(Input.IsActionPressed("TiltRight"))
            {
                ApplyCentralForce(Vector2.Right * TiltForce);
            }
            else if(Input.IsActionPressed("TiltLeft"))
            {
                ApplyCentralForce(Vector2.Left * TiltForce);
            }
        }
        base._PhysicsProcess(delta);
    }

}
