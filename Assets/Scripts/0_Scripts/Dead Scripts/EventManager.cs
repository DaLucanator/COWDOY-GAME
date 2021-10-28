using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    public delegate IEnumerator HealPlayerEventDelegate(int healAmount);
    public static event HealPlayerEventDelegate HealPlayerEvent;

    public delegate void healStateEndEventDelegate();
    public static event healStateEndEventDelegate HealStateEndEvent;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        HealPLayer(1);
    }

    public void HealPLayer(int healAmount)
    {
        HealPlayerEvent.Invoke(healAmount);
    }

    public void HealStateEnd()
    {
        HealStateEndEvent.Invoke();
    }
}
