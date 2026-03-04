using UnityEngine;

public class Foot : MonoBehaviour
{
    public GameObject splat;
    public Color splatColor;

    public void setSplatColor(Color col)
    {
        splatColor = col;
        GetComponent<MeshRenderer>().material.color = col;
    }

    public void Stomp()
    {
        GameObject newSplat = Instantiate(splat);
        newSplat.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        newSplat.GetComponent<MeshRenderer>().material.color = splatColor;
    }
}
