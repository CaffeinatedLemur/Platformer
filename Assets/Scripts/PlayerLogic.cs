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
    public GameObject key;

    bool hasKey;

    public static AudioSource audioSource;

    public AudioClip keySound;
    public AudioClip cpSound;
    private float audioCooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Respawn = transform.position;
        hasKey = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = Respawn;
        }

        if (collision.gameObject.CompareTag("moving"))
        {
            gameObject.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("moving"))
        {
            gameObject.transform.parent = null;
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
            hasKey = true;
            collision.gameObject.transform.parent = gameObject.transform;
            audioSource.PlayOneShot(keySound);
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
        if (audioCooldown <= 0 && collision.gameObject.GetComponent<SpriteRenderer>().color == checkInactive)
        {
            audioSource.PlayOneShot(cpSound);
            audioCooldown = 0.2f;
        }
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
        audioCooldown -= Time.deltaTime;

        if (hasKey)
        {
            key.transform.localPosition = new Vector3(0, 1, 1);

        }
    }
}

