using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAnimCont : MonoBehaviour
{
    public combatLoop cLoop;
    public Animator anim;
    public bool closeBars;
    public int animHash;
    // Start is called before the first frame update
    void Start()
    {
        cLoop = Camera.main.GetComponent<combatLoop>();
        anim = this.GetComponent<Animator>();
        animHash = Animator.StringToHash("showcritz");
    }

    // Update is called once per frame
    void Update()
    {
        if (cLoop.critAnim)
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

    public void EndCrit()
    {
        cLoop.critAnim = false;
    }
}
