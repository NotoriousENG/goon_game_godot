using Godot;
using System;

public partial class Obstacle : Area3D
{
    [Export]
    public OBSTACLE_TYPE ObstacleType;

    public override void _Ready()
    {
        this.BodyEntered += this._on_body_entered;
    }

    private void _on_body_entered(Node3D body)
    {
        if (body is Player)
        {
            (body as Player).HandlePlayerCollision();
        }
    }
}

public enum OBSTACLE_TYPE
{
    Low,
    High,
    Full
}
