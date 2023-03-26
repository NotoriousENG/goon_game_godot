using Godot;
using System;

public partial class GoblinAnimation : AnimationPlayer
{
    const string ANIM_RUN = "Run";
    const string ANIM_JUMP = "Jump";
    const string ANIM_SLIDE = "Slide";

    private CollisionShape3D CollisionShape;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CollisionShape = GetNode<CollisionShape3D>("../../CollisionShape3D");

        // set the run animation to loop
        GetAnimation(ANIM_RUN).LoopMode = Animation.LoopModeEnum.Linear;

        // play the run animation on loop
        Play(ANIM_RUN);
    }

    public override void _Process(double delta)
    {
        // if we get key input for up
        if (Input.IsActionJustPressed("ui_up"))
        {
            // if our current animation is jump 
            if (CurrentAnimation == ANIM_JUMP)
                return;

            // play the jump animation
            Play(ANIM_JUMP, 0.25);

            CollisionShape.Scale = new Vector3(1.0f, 0.5f, 1.0f);
            CollisionShape.Position = new Vector3(0.0f, 6.3f, 0.0f);
            return;
        }

        // if we get key input for down
        if (Input.IsActionJustPressed("ui_down"))
        {
            if (CurrentAnimation == ANIM_SLIDE)
                return;
            // play the slide animation
            Play(ANIM_SLIDE, 0.25);
            CollisionShape.Scale = new Vector3(1.0f, 0.5f, 1.0f);
            CollisionShape.Position = new Vector3(0.0f, 2.15f, 0.0f);
            return;
        }
    }

    private void _on_animation_finished(string anim_name)
    {
        // if the animation is the jump animation
        if (anim_name == ANIM_JUMP || anim_name == ANIM_SLIDE)
        {
            CollisionShape.Scale = new Vector3(1.0f, 1.0f, 1.0f);
            CollisionShape.Position = new Vector3(0.0f, 4.3f, 0.0f);
            // play the run animation
            Play(ANIM_RUN, 0.25);
        }
    }
}
