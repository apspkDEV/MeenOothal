using Godot;
using System;

public partial class Spike : Area2D
{
    public void Impale(Node2D body)
    {
        if(body.IsInGroup("Fih"))
        {
            (body as MeenData).Die();
        }
    }
}
