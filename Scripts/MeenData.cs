using Godot;
using System;

public partial class MeenData : RigidBody2D
{
    [Signal]
    public delegate void FihDedEventHandler();

    [Export] MeenControls FihControls;

    [Export] Camera2D FihCam;

    public override void _Ready()
    {
        GD.Print(FihCam.GetParent().Name);
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print(FihCam.GlobalPosition);
        if(GlobalPosition.Y > 1500)
        {
            Die("dawg how did you even achieve this one");
        }
        base._PhysicsProcess(delta);
    }


    public void Die(string WoD)
    {
        if(FihControls.IsDed) return;
        
        GameManager.DeathMsg = WoD;
        FihControls.IsDed = true;

        FihCam.LimitEnabled = false;
        FihCam.PositionSmoothingEnabled = false;
        FihCam.Reparent(GetTree().CurrentScene);

        Engine.TimeScale = 0.05;

        Tween CamTween = GetTree().CreateTween();
        CamTween.SetIgnoreTimeScale(true);
        CamTween.TweenProperty(FihCam, "position", GlobalPosition, 1f);
        CamTween.Parallel().TweenProperty(FihCam, "zoom", Vector2.One * 3.5f, 0.75f).SetTrans(Tween.TransitionType.Quad).SetEase(Tween.EaseType.Out);

        EmitSignal(SignalName.FihDed);
    }
}
