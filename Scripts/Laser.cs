using Godot;
using System;

public partial class Laser : RayCast2D, IDamager
{
    [Export] Line2D LaserLine;
    [Export] GpuParticles2D LaserParticles;
    [Export] Sprite2D LaserSpr;
    [ExportGroup("Timing")]
    [Export] bool Timed;
    [Export] Timer LaserTime;

    [ExportGroup("Visuals")]

    [Export] Color PermColor;

    [ExportSubgroup("Laser Line")]
    [Export] Color ActiveColor;
    [Export] Color FadeColor;

    bool Active = true;

    public override void _Ready()
    {
        LaserLine.DefaultColor = Active ? ActiveColor : FadeColor;
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        if(!Timed) LaserSpr.SelfModulate = PermColor;
        Vector2 Pos = ToLocal(GetCollisionPoint());
        LaserLine.SetPointPosition(1, Pos);
        LaserParticles.Position = Pos;

        if(Active)
        {
            Damage();
        }
        base._PhysicsProcess(delta);
    }

    public void ToggleLaser()
    {
        if(!Timed) return;
        Active = !Active;
        LaserLine.DefaultColor = Active ? ActiveColor : FadeColor;
        CollideWithBodies = Active ? true : false;
        LaserParticles.Emitting = Active;
    }

    public void Damage()
    {
        if(GetCollider() is MeenData)
        {
            MeenData Fih = GetCollider() as MeenData;
            Fih.Die("laser'd");
        }

        if(GetCollider() is MeenControls)
        {
            MeenControls Gum = GetCollider() as MeenControls;
            Gum.CallDeferred(MeenControls.MethodName.Deflate);
        }
    }

    public void ARDamage(Node2D body){}
}
