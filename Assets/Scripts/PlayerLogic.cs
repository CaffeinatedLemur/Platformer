////////////////////////
///Name: Tom Allen
///Date: 12/15/2020
///Desc. Handles player logic and interations
//////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public Vector3 Respawn;

    public Color checkActive = new Color(1, 0, 1, 1);
    public Color checkInactive = new Color(1, 1, 1, 1);

    private GameObject currentCheckpoint;

    bool hasKey;
    GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        Respawn = transform.position;
        hasKey = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = Respawn;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            CheckpointManager(collision);
        }

        if (collision.gameObject.CompareTag("Finish") && hasKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
        if (collision.gameObject.CompareTag("Key"))
        {
            key = collision.gameObject;
            hasKey = true;
            Destroy(collision.gameObject);
        }
        
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Door D = collision.GetComponent<Door>();
            if (D != null)
                SceneManager.LoadScene(D.NextLevel);
        }
    }
    */

    void CheckpointManager(Collider2D collision)
    {
        //set new location of new CP
        Respawn = collision.transform.position;
        if (currentCheckpoint != null)
        {
            currentCheckpoint.GetComponent<SpriteRenderer>().color = checkInactive; //reset old CP's color
        }
        currentCheckpoint = collision.gameObject; //set new active CP
        if (currentCheckpoint != null)
        {
            currentCheckpoint.GetComponent<SpriteRenderer>().color = checkActive; //set new CP's color
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
