using UnityEngine;

public class waterLevel : MonoBehaviour
{
    public void RaiseWater()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);  
    }
}
