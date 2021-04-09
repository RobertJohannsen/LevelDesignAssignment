using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class animEnemyDMG : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshPro text;
    public int fuckudmg;
    public int lifeCycle, life;
    // Start is called before the first frame update
    void Awake()
    { 
          
        rb = this.GetComponent<Rigidbody>();
        text = this.GetComponent<TextMeshPro>();
    }
    void Start()
    {
        
   
        text.text = "-" + fuckudmg;
    
        rb.AddExplosionForce(Random.Range(-250 , 250), this.gameObject.transform.position, 5 , Random.Range(0,150));
    }

    // Update is called once per frame
    void Update()
    {
        life++;

        if(life > lifeCycle)
        {
            Destroy(this.gameObject);
        }
    }
}
