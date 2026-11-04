using Godot;
using System;

public partial class GameManager : Node
{
    public static string DeathMsg = "";

    [Export] RichTextLabel DeathText;

    [Export] PackedScene MainMenu;

    public override void _Ready()
    {
        GD.Print(MainMenu.ResourceName);
        DeathMsg = "";
        Engine.TimeScale = 1;
        base._Ready();
    }

    public override void _Process(double delta)
    {
        DeathText.Text = DeathMsg;
        base._Process(delta);
    }


    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionJustPressed("Restart"))
        {
            CallDeferred(MethodName.RestartGame);
        }

        if(Input.IsActionJustPressed("Return"))
        {
            CallDeferred(MethodName.ReturnToMainMenu);
        }
        base._PhysicsProcess(delta);
    }

    public void RestartGame()
    {
        GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);
    }

    public void ReturnToMainMenu()
    {
        GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToPacked, MainMenu);
    }
}
