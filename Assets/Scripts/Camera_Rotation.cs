using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{

    public float mouse_sensitvity = 100.0f;
    public Vector2 raw_input;


    // Update is called once per frame
    void Update()
    {
        raw_input.x += Input.GetAxis("Mouse X");
        raw_input.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-raw_input.y, raw_input.x, 0);
    }
}
