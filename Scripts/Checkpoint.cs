using Godot;
using System;

public partial class Checkpoint : Area2D
{
    [Export] Sprite2D CheckVis;

    public bool Checked = false;
    public override void _Ready()
    {
        base._Ready();
    }

    public void Check(Node2D body)
    {
        if(body.IsInGroup("Fih") && Checked == false)
        {
            GD.Print("Hi");
            Checked = true;
            CheckVis.Modulate = new Color(0.279f, 0.624f, 0f, 1f);
            CheckpointManager.Checkpoint++;
        }
    }

}
