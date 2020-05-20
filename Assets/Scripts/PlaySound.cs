using UnityEngine;

public class PlaySound : StateMachineBehaviour
{
    public AudioClip sfx;
    public bool playOnLoop;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioSource source = animator.gameObject.GetComponent<AudioSource>();
        source.clip = sfx;
        source.loop = playOnLoop;
        if(playOnLoop)
        {
            source.Play();
        }
        else
        {
            source.PlayOneShot(sfx);
        }
    }
}
