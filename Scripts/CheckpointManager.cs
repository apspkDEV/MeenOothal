using Godot;
using System;

public partial class CheckpointManager : Node
{
    public static int Checkpoint = 0;

    [Export] Node2D Assembly;

    [Export] Godot.Collections.Array<Node2D> Checkpoints;

    public override void _Ready()
    {
        for(int i = 0; i <= Checkpoint; i++)
        {
            GD.Print("Hi");
            (Checkpoints[i] as Checkpoint).Checked = true;
        }
        Assembly.GlobalPosition = Checkpoints[Checkpoint].GlobalPosition;
        base._Ready();
    }

}
