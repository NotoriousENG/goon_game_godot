using Godot;
using System;
using System.Collections.Generic;

public partial class Level : Node3D
{
    [Export]
    private PackedScene boardwalkScene;

    [Export]
    private PackedScene[] ObstacleScenes;

    private Random random = new Random();

    const float TRACK_LENGTH = 1140.0f;
    const float BOARDWALK_LENGTH = 42.0f;
    public const float LANE_OFFSET = 4.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        for (int i = 0; i < (TRACK_LENGTH + 200.0f) / BOARDWALK_LENGTH; i++)
        {
            // godot spawn a boardwalk scene
            Node3D added = boardwalkScene.Instantiate() as Node3D;
            AddChild(added);
            // set the boardwalk position
            added.Position = (new Vector3(0.0f, 0.0f, i * BOARDWALK_LENGTH));
        }

        for (int i = 1; i < TRACK_LENGTH + 200.0f / BOARDWALK_LENGTH; i++)
        {
            if (ObstacleScenes.Length == 0) // skip if no obstacles
                break;

            // godot spawn a obstacle scene
            var scene = ObstacleScenes[random.Next(0, ObstacleScenes.Length)];
            Obstacle added = scene.Instantiate() as Obstacle;
            List<int> lanes;
            int numSpawned;
            switch (added.ObstacleType)
            {
                case OBSTACLE_TYPE.Low:
                    lanes = new List<int> { -1, 0, 1 };
                    numSpawned = random.Next(1, 4); // can have 3 of these at the same time
                    break;
                case OBSTACLE_TYPE.Full:
                    lanes = new List<int> { -1, 0, 1 };
                    numSpawned = random.Next(1, 3); // can have 2 of these at the same time
                    break;
                default:
                    lanes = new List<int> { 0 };
                    numSpawned = 1; // can have 1 of these at the same time
                    break;
            }

            for (int j = 0; j < numSpawned; j++)
            {
                if (lanes.Count == 0) // no more lanes to spawn on
                    break;
                int lane = lanes[random.Next(0, lanes.Count)];
                lanes.Remove(lane);
                AddChild(added);
                added.Position = (new Vector3(lane * LANE_OFFSET, 0.0f, i * BOARDWALK_LENGTH));
                added = scene.Instantiate() as Obstacle;
            }
        }
    }
}
