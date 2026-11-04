using Godot;
using System;

public partial class SceneManager : Node
{
	[Export] string MainMenuFP;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Return"))
		{
			ReturnToMainMenu();
		}
	}

	public void LoadLevel(PackedScene scene)
	{
	 	GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToPacked, scene);
	}

	public void QuitGame()
	{
		GetTree().Quit();
	}

	public void ReturnToMainMenu()
	{
		GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, MainMenuFP);
	}
}
