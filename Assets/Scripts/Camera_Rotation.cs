using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{

    public float mouse_sensitvity = 100.0f;
    public Vector2 raw_input;
    float shakeTime = 0.0f;
    float shakeAmmount = 1.0f;

    // Update is called once per frame
    void Update()
    {
        raw_input.x += Input.GetAxis("Mouse X");
        raw_input.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-raw_input.y, raw_input.x, 0);

        if(shakeTime > 0.0f)
        {
            shakeTime -= Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x, 1.2f + (Mathf.Sin(shakeTime * 50.0f) * shakeAmmount), transform.localPosition.z); 
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 1.2f, transform.localPosition.z);
        }
    }

    public void ScreenShake(float duration, float intensity)
    {
        shakeTime = duration;
        shakeAmmount = intensity;
    }
}
