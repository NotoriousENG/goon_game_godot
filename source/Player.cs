using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [Signal]
    public delegate void PlayerCollisionEventHandler();

    private CollisionShape3D CollisionShape;

    private int lane = 0;

    public override void _Ready()
    {
        CollisionShape = GetNode<CollisionShape3D>("CollisionShape3D");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // get key input as a float
        int x = (Input.IsActionJustPressed("ui_right") ? 1 : 0) - (Input.IsActionJustPressed("ui_left") ? 1 : 0);

        if (x != 0)
        {
            lane -= x;
            // clamp lane to 0-2
            lane = Mathf.Clamp(lane, -1, 1);
            // set x position based on lane
            Position = new Vector3(lane * Level.LANE_OFFSET, 0, 0);
        }
    }

    public void HandlePlayerCollision()
    {
        GetParent<PlayerRoot>().Position = new Vector3(0, 0, 0);
    }
}
