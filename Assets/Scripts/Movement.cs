using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public GameObject LeftFoot;
    public GameObject RightFoot;

    public GameObject mainCamera;

    Vector3 LeftFootPos;
    Vector3 RightFootPos;
    Vector3 playerRoot;

    Vector3 LeftTarget;
    Vector3 RightTarget;
    Vector3 CapsuleTarget;

    public float stepRadius = 1.5f;

    public float footSpeed = 3.0f;
    public float lerpSpeed = 0.04f;
    public float footRaiseHeight = 1f;

    public bool leftFootRaised = false;
    public bool rightFootRaised = false;

    bool leftFootActive = true;

    private void Start()
    {
        LeftTarget = LeftFoot.transform.position;
        RightTarget = RightFoot.transform.position;
        CapsuleTarget = transform.position;
        LeftFootPos = LeftFoot.transform.position;
        RightFootPos = RightFoot.transform.position;

        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once prer frame
    void Update()
    {
        playerRoot = transform.position;
        playerRoot.y = 0;
        CursorControls();
        if ( leftFootActive ) 
            MoveLeftFoot();
        else
            MoveRightFoot();
        MoveCapsule();
        Slide();
    }

    void CursorControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void Slide()
    {
        LeftFoot.transform.position = Vector3.Lerp(LeftFoot.transform.position, LeftTarget, lerpSpeed);
        RightFoot.transform.position = Vector3.Lerp(RightFoot.transform.position, RightTarget, lerpSpeed);
        transform.position = Vector3.Lerp(transform.position, CapsuleTarget, lerpSpeed);
    }

    void MoveLeftFoot()
    {

        Vector3 inputHor = Input.GetAxis("LF_Hor") * mainCamera.transform.right;
        Vector3 inputVer = Input.GetAxis("LF_Ver") * mainCamera.transform.forward;
        Vector3 raw_input = inputHor + inputVer;
        raw_input.y = 0;
        raw_input *= footSpeed;

        if (math.abs(raw_input.magnitude) > 0.2)
        {
            leftFootRaised = true;
        }

        Vector3 distanceToFoot = LeftTarget + (raw_input * Time.deltaTime);
        distanceToFoot = playerRoot - distanceToFoot;
        if(math.abs(distanceToFoot.magnitude) <= stepRadius){
            LeftTarget += raw_input * Time.deltaTime;
            LeftFoot.transform.rotation = Quaternion.Euler(0,mainCamera.transform.localRotation.eulerAngles.y,0);
        }
        else
        {
            Vector3 desiredPosition = LeftTarget + (raw_input * Time.deltaTime);
            desiredPosition = desiredPosition - playerRoot;
            desiredPosition.Normalize();
            desiredPosition = desiredPosition * stepRadius;
            desiredPosition = desiredPosition + playerRoot;
            LeftTarget = desiredPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LeftFootPos = LeftFoot.transform.position;
            leftFootRaised = false;
            leftFootActive = false;
            LeftFoot.GetComponent<Foot>().Stomp();
        }

        if (leftFootRaised)
        {
            LeftTarget = new Vector3(LeftTarget.x, footRaiseHeight, LeftTarget.z);
        }
        else
        {
            LeftTarget = new Vector3(LeftTarget.x, 0.0f, LeftTarget.z);
        }
    }
    void MoveRightFoot()
    {

        Vector3 inputHor = Input.GetAxis("LF_Hor") * mainCamera.transform.right;
        Vector3 inputVer = Input.GetAxis("LF_Ver") * mainCamera.transform.forward;
        Vector3 raw_input = inputHor + inputVer;
        raw_input.y = 0;
        raw_input *= footSpeed;

        if (math.abs(raw_input.magnitude) > 0.2)
        {
            rightFootRaised = true;
        }

        Vector3 distanceToFoot = RightTarget + (raw_input * Time.deltaTime);
        distanceToFoot = playerRoot - distanceToFoot;
        if (math.abs(distanceToFoot.magnitude) <= stepRadius)
        {
            RightTarget += raw_input * Time.deltaTime;
            RightFoot.transform.rotation = Quaternion.Euler(0, mainCamera.transform.localRotation.eulerAngles.y, 0);
        }
        else
        {
            Vector3 desiredPosition = RightTarget + (raw_input * Time.deltaTime);
            desiredPosition = desiredPosition - playerRoot;
            desiredPosition.Normalize();
            desiredPosition = desiredPosition * stepRadius;
            desiredPosition = desiredPosition + playerRoot;
            RightTarget = desiredPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RightFootPos = RightFoot.transform.position;
            rightFootRaised = false;
            leftFootActive = true;
            RightFoot.GetComponent<Foot>().Stomp();
        }

        if (rightFootRaised)
        {
            RightTarget = new Vector3(RightTarget.x, footRaiseHeight, RightTarget.z);
        }
        else
        {
            RightTarget = new Vector3(RightTarget.x, 0.0f, RightTarget.z);
        }
    }

    void MoveCapsule()
    {
        CapsuleTarget = new Vector3((LeftFootPos.x + RightFootPos.x) / 2f, transform.position.y, (LeftFootPos.z + RightFootPos.z) / 2f);
    }
}
