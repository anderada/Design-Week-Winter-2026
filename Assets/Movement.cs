using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject LeftFoot;
    public GameObject RightFoot;

    public GameObject mainCamera;

    Vector3 LeftFootPos;
    Vector3 RightFootPos;
    Vector3 playerRoot;

    public float stepRadius = 1.5f;

    public float footSpeed = 3.0f;

    // Update is called once prer frame
    void Update()
    {
        playerRoot = transform.position;
        playerRoot.y = 0;
        MoveLeftFoot();
        MoveRightFoot();
        MoveCapsule();
    }

    void MoveLeftFoot()
    {
        Vector3 inputHor = Input.GetAxis("LF_Hor") * mainCamera.transform.right;
        Vector3 inputVer = Input.GetAxis("LF_Ver") * mainCamera.transform.forward;
        Vector3 raw_input = inputHor + inputVer;
        raw_input.y = 0;
        raw_input *= footSpeed;
        Vector3 distanceToFoot = LeftFoot.transform.position + (raw_input * Time.deltaTime);
        distanceToFoot = playerRoot - distanceToFoot;
        if(math.abs(distanceToFoot.magnitude) <= stepRadius){
            LeftFoot.transform.localPosition += raw_input * Time.deltaTime;
            LeftFoot.transform.rotation = Quaternion.Euler(0,mainCamera.transform.localRotation.eulerAngles.y,0);
        }
        else
        {
            Vector3 desiredPosition = LeftFoot.transform.localPosition + (raw_input * Time.deltaTime);
            desiredPosition = desiredPosition - playerRoot;
            desiredPosition.Normalize();
            desiredPosition = desiredPosition * stepRadius;
            desiredPosition = desiredPosition + playerRoot;
            LeftFoot.transform.localPosition = desiredPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LeftFootPos = LeftFoot.transform.position;
        }
    }
    void MoveRightFoot()
    {
        Vector3 inputHor = Input.GetAxis("RF_Hor") * mainCamera.transform.right;
        Vector3 inputVer = Input.GetAxis("RF_Ver") * mainCamera.transform.forward;
        Vector3 raw_input = inputHor + inputVer;
        raw_input.y = 0;
        raw_input *= footSpeed;
        Vector3 distanceToFoot = RightFoot.transform.position + (raw_input * Time.deltaTime);
        distanceToFoot = playerRoot - distanceToFoot;
        if (math.abs(distanceToFoot.magnitude) <= stepRadius)
        {
            RightFoot.transform.localPosition += raw_input * Time.deltaTime;
            RightFoot.transform.rotation = Quaternion.Euler(0, mainCamera.transform.localRotation.eulerAngles.y, 0);
        }
        else
        {
            Vector3 desiredPosition = RightFoot.transform.localPosition + (raw_input * Time.deltaTime);
            desiredPosition = desiredPosition - playerRoot;
            desiredPosition.Normalize();
            desiredPosition = desiredPosition * stepRadius;
            desiredPosition = desiredPosition + playerRoot;
            RightFoot.transform.localPosition = desiredPosition;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            RightFootPos = RightFoot.transform.position;
        }
    }

    void MoveCapsule()
    {
        transform.position = new Vector3((LeftFootPos.x + RightFootPos.x) / 2f, transform.position.y, (LeftFootPos.z + RightFootPos.z) / 2f);
    }
}
