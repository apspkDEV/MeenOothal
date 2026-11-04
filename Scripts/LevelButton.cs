using Godot;
using System;

public partial class LevelButton : Button
{
	[Export] PackedScene Level;
	SceneManager SM;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SM = GetTree().CurrentScene.GetNode("SceneManager") as SceneManager;
		GD.Print(SM.Name);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnPress()
	{
		SM.LoadLevel(Level);
	}
}
