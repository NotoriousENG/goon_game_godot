using Godot;
using System;

public partial class PlayerRoot : Node3D
{
    public override void _Process(double delta)
    {
        Position += new Vector3(0, 0, 20.0f) * (float)delta;
        if (Position.Z > 1140.0f)
        {
            Position = new Vector3(0, 0, 0);
        }
    }
}
