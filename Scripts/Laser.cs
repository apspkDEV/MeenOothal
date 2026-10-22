using Godot;
using System;

public partial class Laser : RayCast2D
{
    [Export] Line2D LaserLine;
    [ExportGroup("Timing")]
    [Export] bool Timed;
    [Export] Timer LaserTime;

    bool Active = true;
    public override void _PhysicsProcess(double delta)
    {
        Vector2 Pos = ToLocal(GetCollisionPoint());
        LaserLine.SetPointPosition(1, Pos);

        if(Active)
        {
            if(GetCollider() is MeenData)
            {
                MeenData Fih = GetCollider() as MeenData;
                Fih.Die();
            }
        }
        base._PhysicsProcess(delta);
    }

    public void ToggleLaser()
    {
        if(!Timed) return;
        Active = !Active;
        Visible = Active;
    }

}
