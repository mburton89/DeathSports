using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollowBall : MonoBehaviour
{
    public static CameraFollowBall Instance;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public Transform pitcher;
    public float zoomSpeed;

    private float _initialZoomAmount;
    [HideInInspector] public bool ballHasBeenHit = false;

    void Awake()
    {
        Instance = this;
        //_initialRotation = transform.eulerAngles;
        _initialZoomAmount = cinemachineVirtualCamera.m_Lens.FieldOfView;
    }

    void Update()
    {
        if (ballHasBeenHit)
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView -= zoomSpeed;
        }
    }

    //Handle Ball Getting Hit
    public void LookAt(Transform transformToLookAt)
    {
        ballHasBeenHit = true;
        cinemachineVirtualCamera.LookAt = transformToLookAt;
    }

    public void RevertToInitialPosition()
    {
        ballHasBeenHit = false;
        cinemachineVirtualCamera.m_Lens.FieldOfView = _initialZoomAmount;
        cinemachineVirtualCamera.LookAt = pitcher;
    }
}