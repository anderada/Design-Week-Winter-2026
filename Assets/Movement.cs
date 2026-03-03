using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject LeftFoot;
    public GameObject RightFoot;

    Vector3 LeftFootPos;
    Vector3 RightFootPos;

    // Update is called once per frame
    void Update()
    {
        MoveLeftFoot();
        MoveRightFoot();
        MoveCapsule();
    }

    void MoveLeftFoot()
    {
        Vector3 raw_input = new Vector3(Input.GetAxis("LF_Hor"),0, Input.GetAxis("LF_Ver"));
        Vector3 distanceToFoot = LeftFoot.transform.position + (raw_input * Time.deltaTime);
        distanceToFoot = transform.position - distanceToFoot;
        if(distanceToFoot.magnitude <= 1.5f){
            LeftFoot.transform.localPosition += raw_input * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LeftFootPos = LeftFoot.transform.position;
        }
    }
    void MoveRightFoot()
    {
        Vector3 raw_input = new Vector3(Input.GetAxis("RF_Hor"),0, Input.GetAxis("RF_Ver"));
        RightFoot.transform.localPosition += raw_input * Time.deltaTime;
        Vector3 distanceToFoot = RightFoot.transform.position + (raw_input * Time.deltaTime);
        distanceToFoot = transform.position - distanceToFoot;
        if (distanceToFoot.magnitude <= 1.5f)
        {
            RightFoot.transform.localPosition += raw_input * Time.deltaTime;
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
