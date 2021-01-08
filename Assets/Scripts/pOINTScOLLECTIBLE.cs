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

    public AudioClip pickupSound;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Score += pointValue;
        PlayerLogic.audioSource.PlayOneShot(pickupSound);
        if (destroyOnCollide)
            Destroy(gameObject);
        
    }
}
