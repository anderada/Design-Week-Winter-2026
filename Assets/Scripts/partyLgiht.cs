using UnityEngine;

public class partyLgiht : MonoBehaviour
{

    float h = 0;
    float s = 1;
    float v = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        h += 0.01f;
        h %= 1;
        GetComponent<Light>().color = Color.HSVToRGB(h, s, v);
    }
}
