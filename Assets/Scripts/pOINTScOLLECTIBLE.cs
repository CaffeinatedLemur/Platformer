/***************
 * NAME: THOMAS ALLEN
 * date: 1/72021
 * desc: gives you points when touching object
 * **************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pOINTScOLLECTIBLE : MonoBehaviour
{
    public int pointValue = 10;
    public bool destroyOnCollide = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Score += pointValue;
        if (destroyOnCollide)
            Destroy(gameObject);
        
    }
}
