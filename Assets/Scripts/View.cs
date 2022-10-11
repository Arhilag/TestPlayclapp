using System;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private InputListener _timeSpawn;
    [SerializeField] private InputListener _speed;
    [SerializeField] private InputListener _distance;
    public Action<string> OnEndEditTime;
    public Action<string> OnEndEditSpeed;
    public Action<string> OnEndEditDistance;

    private void Awake()
    {
        _timeSpawn.OnEndEdit += SubscribeTimeEvent;
        _speed.OnEndEdit += SubscribeSpeedEvent;
        _distance.OnEndEdit += SubscribeDistanceEvent;
    }

    private void OnDestroy()
    {
        _timeSpawn.OnEndEdit -= SubscribeTimeEvent;
        _speed.OnEndEdit -= SubscribeSpeedEvent;
        _distance.OnEndEdit -= SubscribeDistanceEvent;
    }

    private void SubscribeTimeEvent(string time)
    {
        OnEndEditTime?.Invoke(time);
    }

    private void SubscribeSpeedEvent(string speed)
    {
        OnEndEditSpeed?.Invoke(speed);
    }

    private void SubscribeDistanceEvent(string distance)
    {
        OnEndEditDistance?.Invoke(distance);
    }
}
