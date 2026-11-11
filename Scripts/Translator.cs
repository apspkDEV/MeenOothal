using Godot;
using System;

public partial class Translator : AnimatableBody2D
{
	[Export] float TraSpeed = 0.0f;
	[ExportGroup("Timing")]
	[Export] bool isTimed = false;
	[Export] double phase = 0.0;
	[Export] double dirChangeCD = 0.0;
	double dirChangeTimer;

	[ExportGroup("Trigger")]
	[Export] bool isTrig = false;

	[Export] Vector2 finalPos = Vector2.Zero;
	bool Triggered = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(isTimed)
		{
			dirChangeTimer = phase;	
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("TiltRight")) SetTrigger();

		if(isTimed)
		{	
			dirChangeTimer -= delta;
			Vector2 Velocity = Transform.X.Normalized() * TraSpeed;	
			MoveAndCollide(Velocity*(float)delta);
			if(dirChangeTimer <= 0)
			{
				ChangeDirection();
			}
		
		}
		if(isTrig)
		{
			if(Triggered)
			{
				GlobalPosition = GlobalPosition.MoveToward(finalPos, TraSpeed * (float)delta);
			}
		}
	}

	void ChangeDirection()
	{
		dirChangeTimer = dirChangeCD;
		TraSpeed *= -1;
	}

	void SetTrigger()
	{
		Triggered = true;
	}
}
