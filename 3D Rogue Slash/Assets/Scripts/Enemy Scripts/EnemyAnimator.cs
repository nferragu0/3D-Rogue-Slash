using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;

    //death attack sound
    private AudioSource death_Sound;
    [SerializeField]
    private AudioClip death_Clip;

    void Awake()
    {

        //get Enemy's audio source
        death_Sound = GetComponentInChildren<AudioSource>();

        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool("Walk", walk);
    }
    public void Run(bool run)
    {
        anim.SetBool("Run", run);
    }
    public void Attack()
    {
        death_Sound.volume = Random.Range(0.75f, 1f);
        death_Sound.clip = death_Clip;
        death_Sound.Play();
        anim.SetTrigger("Attack");
    }
    public void Dead()
    {
        //play death sound
        death_Sound.volume = Random.Range(0.75f, 1f);
        death_Sound.clip = death_Clip;
        death_Sound.Play();
        anim.SetTrigger("Death");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
