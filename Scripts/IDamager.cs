using Godot;
using System;

public interface IDamager
{
    void Damage();
    void ARDamage(Node2D body);
}
