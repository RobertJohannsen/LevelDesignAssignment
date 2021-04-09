using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCritAnim : MonoBehaviour
{
    public combatLoop cLoop;
    public Animator barGamer;
    public bool closeBars;
    public int closeHash;
    // Start is called before the first frame update
    void Start()
    {
        cLoop = Camera.main.GetComponent<combatLoop>();
        barGamer = this.GetComponent<Animator>();
        closeHash = Animator.StringToHash("closeBarr");
    }

    // Update is called once per frame
    void Update()
    {
        if (cLoop.critAnim)
        {
            barGamer.speed = 1;
            barGamer.SetTrigger(closeHash);
        }
        else
        {
            barGamer.speed = 30;
            barGamer.ResetTrigger(closeHash);
            
        }
        
    }

    public void EndCrit()
    {
        cLoop.critAnim = false;
    }
}
