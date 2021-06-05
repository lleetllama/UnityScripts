using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Create clock in clocks dictionary. call with FindClock("key") then subscribe to tock event. 
/// TickManager.Instance.FindClock("ClockKey").Tock -= MyMethod;
/// </summary>
public class TickManager : Singleton<TickManager>
{
    #region TickClock class
    public class TickClock
    {
        public class OnTickEventArgs : EventArgs
        {
            public int tick;
        }

        int tick = 0;
        float tickTimer;
        [SerializeField] float tickFrequency;

        public event EventHandler<OnTickEventArgs> Tock;

        public TickClock(float frequency)
        {
            tick = 0;
            tickFrequency = frequency;
        }

        public void Tick(float timeIn)
        {
            tickTimer += timeIn;

            if (tickTimer >= tickFrequency)
            {
                tickTimer -= tickFrequency;
                tick++;
                Tock?.Invoke(this, new OnTickEventArgs { tick = tick });
                // Debug.Log("Tock!");
            }
        }
    }
    #endregion

    public Dictionary<string, TickClock> clocks = new Dictionary<string, TickClock>{
        {"AiClock", new TickClock(.2f)}
    };

    public TickClock FindClock(string clockKey)
    {
        return clocks[clockKey];
    }

    private void Update()
    {
        var delta = Time.deltaTime;

        foreach (TickClock clock in clocks.Values)
        {
            clock.Tick(delta);
        }
    }
}
