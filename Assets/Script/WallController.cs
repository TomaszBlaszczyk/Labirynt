using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallController : MonoBehaviour
{
    float timeLeft = 0f;
    public UnityEvent @event;
    private void Update()
    {
        timeLeft += Time.deltaTime;
        if(timeLeft >= 10)
        {
            @event.Invoke();
            timeLeft = 0;
        }
    }
}
