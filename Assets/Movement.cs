using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject LeftFoot;
    public GameObject RightFoot;

    public GameObject mainCamera;

    Vector3 LeftFootPos;
    Vector3 RightFootPos;

    public float stepRadius = 1.75f;

    // Update is called once prer frame
    void Update()
    {
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
        Vector3 distanceToFoot = LeftFoot.transform.position + (raw_input * Time.deltaTime);
        distanceToFoot = transform.position - distanceToFoot;
        if(math.abs(distanceToFoot.magnitude) <= stepRadius){
            LeftFoot.transform.localPosition += raw_input * Time.deltaTime;
            LeftFoot.transform.rotation = Quaternion.Euler(0,mainCamera.transform.localRotation.eulerAngles.y,0);
        }
        /*else
        {
            distanceToFoot.Normalize();
            distanceToFoot *= stepRadius;
            Vector3 circlePosition = transform.position + distanceToFoot;
            circlePosition.y = 0;
            LeftFoot.transform.position = circlePosition;
        }*/
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
        Vector3 distanceToFoot = RightFoot.transform.position + (raw_input * Time.deltaTime);
        distanceToFoot = transform.position - distanceToFoot;
        if (math.abs(distanceToFoot.magnitude) <= stepRadius)
        {
            RightFoot.transform.localPosition += raw_input * Time.deltaTime;
            RightFoot.transform.rotation = Quaternion.Euler(0, mainCamera.transform.localRotation.eulerAngles.y, 0);
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
