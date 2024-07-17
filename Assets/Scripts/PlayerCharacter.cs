using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using Cinemachine;


public class PlayerCharacter : MonoBehaviour
{
    //Player variables
    private PlayerCharacter playerCharacter;
    private Rigidbody2D Rigidbody2D;

    //Variables for movement
    private float moveSpeed;
    public InputAction MoveAction;

    //Coordinates to the checkpoints
    private Transform checkPoint;

    //Camera
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        playerCharacter = GetComponent<PlayerCharacter>();
        Debug.Log("Start!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player falls of the map
        if (collision.gameObject.tag == "Fallboundry")
        {
            StartCoroutine(Wait(1f));
            Debug.Log("Falt igjennom fallboundry");
        }
        //Player passes a checkpioint
        if (collision.gameObject.tag.Equals("Checkpoint"))
        {
            checkPoint = collision.gameObject.transform;
            Debug.Log("Checkpoint! " + checkPoint.transform.position);
        }

    }

    //If colliding with enemy, player will respawn at the latest checkpoint
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            StartCoroutine(Wait(0.1f));
        }
    }

    // Wait function, will wait for "seconds" before respawning character at the latest checkpoint
    private IEnumerator Wait(float seconds)
    {
       
        virtualCamera.Follow = null;  
        yield return new WaitForSeconds(seconds);
        playerCharacter.transform.position = new Vector3(checkPoint.position.x, checkPoint.position.y, 0);
        Rigidbody2D.velocity = Vector3.zero;
        //Calculation to "smooth out" the camera transition
        virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, new Vector3(playerCharacter.transform.position.x,
            playerCharacter.transform.position.y, -10), 0.1f);
        virtualCamera.Follow = playerCharacter.transform;
    }
}
