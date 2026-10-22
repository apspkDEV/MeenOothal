using Godot;
using System;

public partial class GameManager : Node
{
    public void RestartGame()
    {
        GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);
    }
}
