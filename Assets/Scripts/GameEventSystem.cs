using System;
using components;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;

    private void Awake()
    {
        current = this;
        
    }
    public event Action<WinnerClass> OnWinnerFound = delegate {  };

    public void TriggerWinnerFound(WinnerClass t)
    {
        OnWinnerFound?.Invoke(t);
    }
}
