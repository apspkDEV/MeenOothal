using Godot;
using System;

public partial class Rotator : AnimatableBody2D
{
	// In degrees per second.
	[Export] float RotSpeed = 0.0f;
	[ExportGroup("Timing")]
	[Export] bool isTimed = false;
	[Export] double phase = 0.0;
	[Export] double dirChangeCD = 0.0;
	double dirChangeTimer;
	[Export] int dir = 1;

	[ExportGroup("Trigger")]
	[Export] bool isTrig = false;

	// In degrees.
	[Export] float finalRot = 0.0f;
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
	public override void _PhysicsProcess(double delta)
	{
		if(Input.IsActionJustPressed("TiltRight")) SetTrigger();
		if(isTimed)
		{	
			dirChangeTimer -= delta;
			Rotate(Mathf.DegToRad(RotSpeed*dir*(float)delta));
			if(dirChangeTimer <= 0)
			{
				ChangeDirection();
			}
		
		}

		if(isTrig)
		{
			if(Triggered)
			{
				RotationDegrees = Mathf.MoveToward(RotationDegrees, finalRot, RotSpeed * dir * (float)delta);
			}
		}
	}

	void ChangeDirection()
	{
		dirChangeTimer = dirChangeCD;
		dir *= -1;
	}

	void SetTrigger()
	{
		Triggered = true;
	}
}
