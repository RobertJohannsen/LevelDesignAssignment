using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyAttAnimCont : MonoBehaviour
{
    public combatLoop cLoop;
    public Animator anim;
    public int animHash;
    // Start is called before the first frame update
    void Start()
    {
        cLoop = Camera.main.GetComponent<combatLoop>();
        anim = this.GetComponent<Animator>();
        animHash = Animator.StringToHash("att");
    }

    // Update is called once per frame
    void Update()
    {
        if (cLoop.plyAtt)
        {
            anim.speed = 1;
            anim.SetTrigger(animHash);
        }
        else
        {
            anim.speed = 30;
            anim.ResetTrigger(animHash);


        }

    }
}
