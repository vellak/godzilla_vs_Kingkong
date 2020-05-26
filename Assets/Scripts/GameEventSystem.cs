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
    public event Action<int> OnUpdateTimer = delegate {  };
    public event Action<WinnerClass> OnWinnerFound = delegate {  };
    public event Action OnAnimationFinished = delegate {  };
    public event Action OnAnimationStarted = delegate {  };
    public event Action OnRoundStart = delegate {  };
    
    public event Action OnCharacterDie = delegate {  };
    public void TriggerWinnerFound(WinnerClass t)
    {
        OnWinnerFound(t);
    }
    public void TriggerUpdateTimer(int time)
    {
        OnUpdateTimer(time);
    }

    public void TriggerRoundStart()
    {
        OnRoundStart();
    }

    public void TriggerCharacterDie()
    {
        OnCharacterDie();
    }

    public void TriggerAnimationFinished()
    {
        OnAnimationFinished();
    }
    public void TriggerAnimationStarted()
    {
        OnAnimationStarted();
    }
}