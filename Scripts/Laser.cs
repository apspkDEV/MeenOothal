using Godot;
using System;

public partial class Laser : RayCast2D
{
    [Export] Line2D LaserLine;
    [Export] GpuParticles2D LaserParticles;
    [Export] Sprite2D LaserSpr;
    [ExportGroup("Timing")]
    [Export] bool Timed;
    [Export] Timer LaserTime;

    bool Active = true;
    public override void _PhysicsProcess(double delta)
    {
        if(!Timed) LaserSpr.Modulate = new Color(0.209f, 0.005f, 0.212f, 1f);
        Vector2 Pos = ToLocal(GetCollisionPoint());
        LaserLine.SetPointPosition(1, Pos);
        LaserParticles.Position = Pos;

        if(Active)
        {
            if(GetCollider() is MeenData)
            {
                MeenData Fih = GetCollider() as MeenData;
                Fih.Die("laser'd");
            }
        }
        base._PhysicsProcess(delta);
    }

    public void ToggleLaser()
    {
        if(!Timed) return;
        Active = !Active;
        LaserLine.Visible = Active;
        LaserParticles.Emitting = Active;
    }

}
