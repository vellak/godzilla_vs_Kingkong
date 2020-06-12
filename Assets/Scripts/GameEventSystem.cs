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
    public event Action OnAnimationFinished = delegate {  };
    public event Action OnAnimationStarted = delegate {  };
    public event Action OnRoundStart = delegate {  };
    public event Action OnScoreUpdate = delegate {  };
    public event Action OnPlayerWinGame = delegate {  };
    public void TriggerWinnerFound(WinnerClass t)
    {
        OnWinnerFound(t);
    }

    public void TriggerRoundStart()
    {
        OnRoundStart();
    }

    public void TriggerPlayerWinGame()
    {
        OnPlayerWinGame();
    }

    public void TriggerAnimationFinished()
    {
        OnAnimationFinished();
    }
    public void TriggerAnimationStarted()
    {
        OnAnimationStarted();
    }

    public void TriggerScoreUpdate()
    {
        OnScoreUpdate();
    }
}