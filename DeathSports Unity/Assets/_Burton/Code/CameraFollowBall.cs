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
    public void LookAt(Transform transformToLookAt, float hitSpeed)
    {
        zoomSpeed = hitSpeed / 30000;
        print(zoomSpeed);
        ballHasBeenHit = true;
        cinemachineVirtualCamera.LookAt = transformToLookAt;
        DelayRevertToInitialPosition();
    }

    public void RevertToInitialPosition()
    {
        ballHasBeenHit = false;
        cinemachineVirtualCamera.m_Lens.FieldOfView = _initialZoomAmount;
        cinemachineVirtualCamera.LookAt = pitcher;
    }

    public void DelayRevertToInitialPosition()
    {
        StartCoroutine(DelayRevertToInitialPositionCo());
    }

    private IEnumerator DelayRevertToInitialPositionCo()
    {
        yield return new WaitForSeconds(1.5f);
        RevertToInitialPosition();
    }
}
