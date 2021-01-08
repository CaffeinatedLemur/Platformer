using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.isGrounded = true;
        PlatformController.myAnim.SetBool("isGrounded", true);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.isGrounded = true;
        PlatformController.myAnim.SetBool("isGrounded", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.isGrounded = false;
        PlatformController.myAnim.SetBool("isGrounded", false);
    }
}
