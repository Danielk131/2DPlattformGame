using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraExeptions : MonoBehaviour
{

    private Transform player;
    public CinemachineVirtualCamera virtualCamera;
    private Camera camera;
    private float followThresholdY = -10f;

    private EdgeCollider2D mapBounds;
    private Vector3 camPos;

    private float xMin, xMax;
    private float yMin, yMax;
    private float camX, camY, camZ;
    private float halfCamHeight;
    private float halfCamWidth;
    private float camRatio;

    private bool followPlayer = true;

    //public CinemachineTransposer transposer;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
        mapBounds = GameObject.FindWithTag("InvisibleWall").GetComponent<EdgeCollider2D>();
        xMin = mapBounds.bounds.min.x;
        xMax = GameObject.FindWithTag("InvisibleWallEnd").GetComponent<EdgeCollider2D>().bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        virtualCamera = GameObject.FindWithTag("CinemaMachineCamera").GetComponent<CinemachineVirtualCamera>();
        camera = GetComponent<Camera>();
        halfCamHeight = camera.orthographicSize;
        halfCamWidth = halfCamHeight * camera.aspect;
      
        camZ = -10;


        camPos = new Vector3(halfCamHeight * 2 + xMin, 0, camZ);
        Debug.Log("yMax = " + yMax);
        Debug.Log("yMin = " + yMin);
        Debug.Log("xMax = " + xMax);
        Debug.Log("xMin = " + xMin);
        
        
        virtualCamera.transform.position = camPos;



    }

    private void LateUpdate()
    {


        if (player.transform.position.x > halfCamWidth + xMin)
        {
            if (player.transform.position.x < xMax - halfCamWidth)
            {
                Debug.Log("Updating pos");
                updateXPos();
                followPlayer = true;
            }
            else
            {
                Debug.Log("Gått for langt til høyre på x");
                camPos.x = xMax - halfCamWidth;
            }
            
        }
       
        else
        {
            if (followPlayer)
            {
                Debug.Log("For langt til venstre på x");
                followPlayer = false;
                camPos.x = xMin + halfCamWidth;
                virtualCamera.transform.position = camPos;
            }
        }
        if (player.transform.position.y < yMax - halfCamHeight && player.transform.position.y > yMin + halfCamHeight)
        {

            updateYPos();
        }
        else if (player.transform.position.y < yMin + halfCamHeight)
        {
            //Debug.Log("For lang ned i y retning: yMin + cmanOrth = " + (yMin + halfCamHeight));

            camPos.y = yMin + halfCamHeight;
        }
        else if (player.transform.position.y > yMax - halfCamHeight)
        {
            Debug.Log("For langt opp i y retning");
            camPos.y = yMax - halfCamHeight;
        }
        virtualCamera.transform.position = camPos;
    }

    private void updateXPos()
    {
        camPos.x = player.transform.position.x;
    }

    private void updateYPos()
    {
        camPos.y = player.transform.position.y;
    }
}


   




