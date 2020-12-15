////////////////////////
///Name: Tom Allen
///Date: 12/15/2020
///Desc. Handles player logic and interations
//////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public Vector3 Respawn;

    // Start is called before the first frame update
    void Start()
    {
        Respawn = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = Respawn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
