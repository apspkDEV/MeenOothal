using Godot;
using System;

public partial class Checkpoint : Area2D
{
	[Export] Sprite2D CheckVis;

	public bool Checked = false;

	[Export] Color CheckColor;
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _Process(double delta)
	{
		if (Checked) CheckVis.Modulate = CheckColor;
		base._Process(delta);
	}


	public void Check(Node2D body)
	{
		if(body.IsInGroup("Fih") && Checked == false)
		{
			// GD.Print("Hi");
			Checked = true;
			CheckpointManager.Checkpoint++;
		}
	}

}
