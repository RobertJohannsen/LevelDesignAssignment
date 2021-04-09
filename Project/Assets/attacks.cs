using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks : MonoBehaviour
{
    public Sprite[] state;
    public enum atts{ none , direct , heal , rest };
    public atts attType;
    public atts[] attQueue;
    public int ammo, clip, apCost, baseDmg, index, basecrit, baseacc, attIndex, attQueueLength;
    public bool hasHat, hasWep , doMove;
    public enum enemyState { att , heal , rest , stun}
    public enemyState eState; 


    // Start is called before the first frame update
    void Start()
    {
        hasWep = true;
        hasHat = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (attIndex > 1)
        {
            attIndex = 1;
        }


        if(this.GetComponentInChildren<hatBehaviour>().partHP == 0)
        {
            hasHat = false;
            this.GetComponent<SpriteRenderer>().sprite = state[1];
        }
        if(this.GetComponentInChildren<weaponBehaviour>().partHP == 0)
        {
            hasWep = false;
            this.GetComponent<SpriteRenderer>().sprite = state[2];
        }

        if(!hasHat && !hasWep)
        {
            this.GetComponent<SpriteRenderer>().sprite = state[3];
        }


    }

   public enemyState doAttack()
    {


        int currentap = GetComponentInParent<stats>().currentap;

        if (GetComponentInParent<stats>().currentap > 0)
        {
            if(GetComponentInParent<stats>().hp <= GetComponentInParent<stats>().maxhp / 3)
            {
                int healYes = Random.Range(1, 10);

                Debug.Log(healYes);

                if (healYes > 5)
                {
                    if(currentap - 4 >= 0)
                    {
                        GetComponentInParent<stats>().currentap = Mathf.Clamp(GetComponentInParent<stats>().currentap - 4, 0, GetComponentInParent<stats>().maxap);
                        return enemyState.heal;
                    }
                   
                }
            }

            if (GetComponentInParent<stats>().currentap < GetComponentInParent<stats>().maxap / 2)
            {
                int restVal = Random.Range(1, 10);
                if (restVal > 5) 
                {
                    eState = enemyState.rest;
                }
                else
                {
                    if(GetComponentInParent<stats>().currentap == 0)
                    {
                        eState = enemyState.rest;
                    }
                }
               

            }
            else
            {


                if ((currentap - 2) >= 0)
                {
                    int whatAtt = Random.Range(1, 10);

                    if (whatAtt <= 5)
                    {
                        attType = atts.direct;
                        attIndex = 1;
                        baseDmg = 7;
                        apCost = 2;
                        basecrit = 40;
                        baseacc = 50;
                    }

                    if (whatAtt >= 5)
                    {
                        attType = atts.direct;
                        attIndex = 1;
                        baseDmg = 10;
                        apCost = 4;
                        basecrit = 20;
                        baseacc = 30;
                    }

                    if (whatAtt >= 8)
                    {
                        return enemyState.rest;
                    }

                    if((currentap - apCost) >= 0)
                    {
                        GetComponentInParent<stats>().currentap = Mathf.Clamp(GetComponentInParent<stats>().currentap - apCost, 0, GetComponentInParent<stats>().maxap);
                        return enemyState.att;
                    }
                    else
                    {
                        
                        // set to cheapest move


                            attIndex = 1;
                            baseDmg = 7;
                            apCost = 2;
                            basecrit = 40;
                            baseacc = 50;

                        GetComponentInParent<stats>().currentap = Mathf.Clamp(GetComponentInParent<stats>().currentap - apCost, 0, GetComponentInParent<stats>().maxap);
                        return enemyState.att;



                    }
                }
                else
                {
                    return enemyState.rest;
                }
            }
        }
        else
        {
            return enemyState.rest;
        }

        return enemyState.rest;
    }
}
