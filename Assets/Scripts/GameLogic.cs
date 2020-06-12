using System;
using System.Collections;
using System.Collections.Generic;
using components;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    
    [SerializeField] internal float timerLength;
    [SerializeField] private GodzillaGestureListener gzListener;
    [SerializeField] private KingKongGestureListener kkListener;

    [SerializeField] private Animator gzAnimator;
    [SerializeField] private Animator kkAnimator;
    private List<Vector3Int> winnerTable = new List<Vector3Int>();
    private KinectGestures.Gestures kkl = KinectGestures.Gestures.None;
    private KinectGestures.Gestures gzl = KinectGestures.Gestures.None;

    [SerializeField] [Range(1, 20)] public int turnAmount;
    private int winningMove = 0;
    private bool gameLoopRun = true;
    internal int bestOutOf;


    public bool overrideWinner;
    public int newWinner;
    //Singleton
    public static GameLogic current;

    public int CurrentRound { get; private set; } = 0;

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        
        if (turnAmount%2==0)
        {
            turnAmount++;
        }
        bestOutOf = 1 + (int) Mathf.Floor(turnAmount/2f);
        /*/
         initialize 2d Matrix
         start timer for round
         capture first moves of the player.
         */
        /*
         * 2D zero sum Matrix
         */
        winnerTable.Add(new Vector3Int(0, -1, 1));
        winnerTable.Add(new Vector3Int(1, 0, -1));
        winnerTable.Add(new Vector3Int(-1, 1, 0));
    }
    private void Update()
    {
        
        #region get User Input
        //print("update");
        if (kkl == KinectGestures.Gestures.None)
        {
            kkl = kkListener.GetGesture();
            //print(kkl.ToString());
        }
        if (gzl == KinectGestures.Gestures.None)
        {
            gzl = gzListener.GetGesture();
            //print(gzl.ToString());
        }
        #endregion
        #region Game Loop
        if (gameLoopRun)
        {
            //print("gameloop");
            StartCoroutine(Timer(timerLength));
        }
        #endregion GameLoop
    }
    private IEnumerator Timer(float time)
    {
        gameLoopRun = false;
        winningMove = 0;
        GameEventSystem.current.TriggerRoundStart();
        yield return new WaitForSeconds(time);
        FightingSim(gzl, kkl);
        yield return new WaitForSeconds(time);
        gameLoopRun = true;
    }

    private void FightingSim(KinectGestures.Gestures gzl, KinectGestures.Gestures kkl)
    {
        //print("fighting Sim");
        var gzmove = 0;
        var kkMove = 0;
        WinnerEnum winner;

        gzmove = SetGzmove(gzl, gzmove);
        kkMove = SetKkMove(kkl, kkMove);
        
        winner = DecideWinner(gzmove, kkMove, out var numb);
        winningMove = numb;
        if (overrideWinner)
        {
            winner = (WinnerEnum) newWinner;
            winningMove = 1;
        }
        
        //print(winner);
        // runs code depending on the winner and the move used to win.
        // used for running animations and sounds mainly.
        WinnerCode(winner, winningMove);
        // this sets the gestures back to their original Values so they can be set again in the next round.
        this.gzl = KinectGestures.Gestures.None;
        this.kkl = KinectGestures.Gestures.None;
    }    

    private void WinnerCode(WinnerEnum winner, int numb)
    {
        //print("Winner Code");
        switch (winner)
        {
            case WinnerEnum.Draw:
                //print("Draw case");
                RoundFinalCode(0, null, null, null);
                break;
            case WinnerEnum.Godzilla:
                print("GZ case");
                RoundFinalCode(1, gzAnimator, kkAnimator, numb.ToString());
                break;
            case WinnerEnum.Kong:
                print("kk case");
                RoundFinalCode(2, kkAnimator, gzAnimator, numb.ToString());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void RoundFinalCode(int winnernum, Animator winner, Animator loser, string animationTriggerWinner)
    {
        CurrentRound++;
        var wc = new WinnerClass(winner, loser,winnernum, "IsAttacked", animationTriggerWinner, 1, winningMove);
        GameEventSystem.current.TriggerWinnerFound(wc);
        //print("roundFinal Code");
    }
    
    private WinnerEnum DecideWinner(int gzmove, int kkMove, out int number)
    {
        number = 0;
        WinnerEnum winner;
        if (gzmove == 0 && kkMove == 0)
        {
            winningMove = 0;
            winner = WinnerEnum.Draw;
        }
        //checks king kong
        else if (kkMove == 0)
        {
            winningMove= number = gzmove;
            
            winner = WinnerEnum.Godzilla;
        }
        //checks Godzilla
        else if (gzmove == 0)
        {
            winningMove=number = kkMove;
            winner = WinnerEnum.Kong;
        }
        else
        {
            //if both of them did a move, then decipher the moves to see who wins
            winner = TwoDMatrixLookup(kkMove, gzmove,out var num);
            number = num;
            if (winner == WinnerEnum.Kong )
            {
                winningMove = kkMove;
            }
            else
            {
                winningMove = gzmove;
            }
        }
        return winner;
    }
    private static int SetKkMove(KinectGestures.Gestures kkl, int kkMove)
    {
        switch (kkl)
        {
            case KinectGestures.Gestures.KPunch:
                kkMove = 1;
                break;
            case KinectGestures.Gestures.SwipeUp:
                kkMove = 2;
                break;
            case KinectGestures.Gestures.Pull:
                kkMove = 3;
                break;
        }

        return kkMove;
    }

    private static int SetGzmove(KinectGestures.Gestures gzl, int gzmove)
    {
        switch (gzl)
        {
            // moves are only comprised of these 3.
            // sets the value of gzmove in order to make comparisions easier.
            case KinectGestures.Gestures.Push:
                gzmove = 1;
                break;
            case KinectGestures.Gestures.SwipeDown:
                gzmove = 2;
                break;
            case KinectGestures.Gestures.GTailSmack:
                gzmove = 3;
                break;
        }

        return gzmove;
    }

    private WinnerEnum TwoDMatrixLookup(int kkMove, int gzmove, out int number)
    {
        // we do -1 on all our indexes due to the index range from 1 to 3

        // lookup on the 2D Matrix
        //row first
        var r = winnerTable[kkMove - 1];
        //gets the value of the column within row r.
        // since r is a vector we use VToIArray to convert the vector to an array of ints and returns index [gzmove-1] from that array
        var c = VToIArray(r);
        var v = c[gzmove - 1];

        switch (v)
        {
            case 0:
                number = 0;
                return WinnerEnum.Draw;
            case -1:
                number = gzmove;
                return WinnerEnum.Godzilla;
            case 1:
                number = kkMove;
                return WinnerEnum.Kong;
            default:
                number = 0;
                return WinnerEnum.Draw;
        }
    }

    private static int[] VToIArray(Vector3Int v)
    {
        var array = new int[3];
        array[0] = v.x;
        array[1] = v.y;
        array[2] = v.z;
        return array;
    }
}
public enum WinnerEnum
{
    Kong,
    Godzilla,
    Draw
}