using Godot;
using System;

public partial class GameManager : Node
{
    public static string DeathMsg = "";

    [Export] RichTextLabel DeathText;

    public override void _Ready()
    {
        DeathMsg = "";
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
        base._PhysicsProcess(delta);
    }

    public void RestartGame()
    {
        GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);
    }
}
