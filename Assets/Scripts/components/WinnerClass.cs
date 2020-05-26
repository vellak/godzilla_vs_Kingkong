using UnityEngine;
using UnityEngine.Rendering;

namespace components
{
    public class WinnerClass
    {
        public Animator w;
        public Animator l;
        public string a1;
        public string a2;
        public int score;
        public int damage;
        public int winNumb;

        public WinnerClass(Animator w, Animator l,int winNumb,string a1, string a2,  int score, int damage)
        {
            this.w = w;
            this.l = l;
            this.winNumb = winNumb;
            this.a1 = a1;
            this.a2 = a2;
            this.score = score;
            this.damage = damage;
        }
    }
}