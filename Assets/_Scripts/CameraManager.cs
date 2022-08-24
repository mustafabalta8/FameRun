using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 finalStageOffset;

    [SerializeField] private float lerpValue;
    [SerializeField] private float camVelocity_x, camSpeed;

    public static CameraManager instance;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Singelton();

    }
    private void LateUpdate()
    {
        MoveCamera();
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue * Time.deltaTime)  ;
        /*Vector3 cameraNewPos = target.position + offset;
        transform.position = new Vector3(Mathf.SmoothDamp(cameraNewPos.x, target.transform.position.x, ref camVelocity_x,camSpeed), 
            cameraNewPos.y, cameraNewPos.z);*/
    }
    public void UpdateCameraSettingsToTheFinalStage()
    {
        offset = finalStageOffset;
        lerpValue = 2;
        /*
        target.position = new Vector3(0, target.position.y, target.position.z);
        transform.Rotate(Vector3.up * 180);
        transform.Rotate(Vector3.right * 50);*/


    }
}
