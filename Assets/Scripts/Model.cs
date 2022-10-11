using System;
using UnityEngine;

public class Model
{
    public float TimeSpawn { get; private set; }
    public float Speed { get; private set; }
    public float Distance { get; private set; }
    
    public CubeMover CubePrefab { get; private set; }

    public void SetTimeToSpawn(string time)
    {
        TimeSpawn = float.Parse(time);
    }

    public void SetSpeed(string speed)
    {
        Speed = float.Parse(speed);
    }

    public void SetDistance(string distance)
    {
        Distance = float.Parse(distance);
    }

    public void SetPrefab(CubeMover cube)
    {
        CubePrefab = cube;
    }
}
