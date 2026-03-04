using UnityEngine;

public class puddleGrow : MonoBehaviour
{
    public float growTime = 2.0f;
    float growTimer = 0.0f;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    public void StartTimer()
    {
        Debug.Log("test");
        growTimer = growTime;
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void setColor(Color col)
    {
        GetComponent<MeshRenderer>().material.color = col;
    }

    private void Update()
    {
        growTimer -= Time.deltaTime;
        if(growTimer > 0.0f)
        {
            float newScale = 1f + (1f * Time.deltaTime);
            transform.localScale = new Vector3(newScale * transform.localScale.x, transform.localScale.y, newScale * transform.localScale.z);
        }
    }
}
