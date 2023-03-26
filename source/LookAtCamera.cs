using Godot;
using System;

public partial class LookAtCamera : Camera3D
{
    public override void _Ready()
    {
        // look at (0,transform.y / 1.5f ,0)
        LookAt(new Vector3(0, this.Position.Y / 1.5f, 0), new Vector3(0, 1, 0));
    }
}
