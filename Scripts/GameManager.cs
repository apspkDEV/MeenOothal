using Godot;
using System;

public partial class GameManager : Node
{
    public static string DeathMsg = "";

    [Export] RichTextLabel DeathText;
    [Export] SceneManager SM;

    [Export] PackedScene MainMenu;

    public override void _Ready()
    {
        SM = GetTree().CurrentScene.GetNode("SceneManager") as SceneManager;
        // GD.Print(MainMenu.ResourceName);
        DeathMsg = "";
        Engine.TimeScale = 1;
        GD.Print("Huh");
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
            SM.CallDeferred(SceneManager.MethodName.ReturnToMainMenu);
        }
        base._PhysicsProcess(delta);
    }

    public void RestartGame()
    {
        GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);
    }
}
