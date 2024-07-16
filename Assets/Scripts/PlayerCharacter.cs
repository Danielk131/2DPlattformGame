using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using Cinemachine;


public class PlayerCharacter : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float moveSpeed;
    public InputAction MoveAction;
    private PlayerCharacter playerCharacter;
    private Transform checkPoint;

    public CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        playerCharacter = GetComponent<PlayerCharacter>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fallboundry")
        {
            virtualCamera.Follow = null;
            StartCoroutine(Wait(1f));
            Debug.Log("Falt igjennom fallboundry");
        }

        if (collision.gameObject.tag.Equals("Checkpoint"))
        {
            checkPoint = collision.gameObject.transform;
            Debug.Log("Checkpoint!");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            StartCoroutine(Wait(0.1f));
        }
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerCharacter.transform.position = new Vector3(checkPoint.position.x, checkPoint.position.y, 0);
        virtualCamera.transform.position = new Vector3(playerCharacter.transform.position.x, 
            playerCharacter.transform.position.y, playerCharacter.transform.position.z);

    }
}
