using Godot;
using System;

public partial class Spike : Area2D, IDamager
{
    public void ARDamage(Node2D body)
    {
        if(body.IsInGroup("Fih"))
        {
            (body as MeenData).Die("spike'd");
        }

        if(body is MeenControls)
        {
            (body as MeenControls).CallDeferred(MeenControls.MethodName.Deflate);
        }
    }

    public void Damage(){}
}
