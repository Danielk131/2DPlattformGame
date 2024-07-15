using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExeptions : MonoBehaviour
{

    private Transform player;
    public CinemachineVirtualCamera virtualCamera;
    private float followThresholdY = -10f;
    private float invisibleWallXValue;
    private GameObject invisibleWall;
    private float invisibleWallPos;
    private Camera camera;
    //public CinemachineTransposer transposer;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();

        camera = Camera.main;
        invisibleWall = GameObject.FindWithTag("InvisibleWall");
        invisibleWallPos = invisibleWall.transform.position.x;
        Debug.Log(invisibleWallPos);
        Debug.Log(camera.transform.position.x);
        virtualCamera.Follow = null;
        camera.transform.position = new Vector2(0.5f, 0);


    }

    private void Update()
    {
      if(player.transform.position.x > 5.4)
        {
            virtualCamera.Follow = player;
        }
        else
        {
            virtualCamera.Follow = null;
            camera.transform.position = new Vector2(0.5f, 0);
        }
    }
}

   




