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
        moveLeftFoot();
        moveRightFoot();
    }

    void moveLeftFoot()
    {
        Vector3 raw_input = new Vector3(Input.GetAxis("LF_Hor"),0, Input.GetAxis("LF_Ver"));
        LeftFoot.transform.localPosition += raw_input * Time.deltaTime;

        if (Input.GetAxis("LF_Stomp") > 0.2)
        {
            LeftFootPos = LeftFoot.transform.position;
        }
    }
    void moveRightFoot()
    {
        Vector3 raw_input = new Vector3(Input.GetAxis("RF_Hor"),0, Input.GetAxis("RF_Ver"));
        RightFoot.transform.localPosition += raw_input * Time.deltaTime;
    }
}
