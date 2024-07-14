using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private CinemachineVirtualCamera virtualCamera;
    private float followThresholdY = -10f;

    public CinemachineTransposer transposer;

    private void Start()
    {
        player = GetComponent<PlayerCharacter>().transform;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if(virtualCamera != null )
        {
            transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        }
    }

    void Update()
    {
        if (player != null && transposer != null ) {
            if(player.position.y < followThresholdY)
            {
                Debug.Log("STOP Å FØLG SPILLER");
                virtualCamera.Follow = null;
            }
            else
            {
                virtualCamera.Follow = player;
            }
        }

    }


}
