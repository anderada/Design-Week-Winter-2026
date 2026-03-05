using UnityEngine;

public class bottleSpawner : MonoBehaviour
{
    public GameObject bottle;
    public void spawnBottle()
    {
        GameObject child = Instantiate(bottle);
        child.transform.position = transform.position;
        child.transform.rotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360));
    }
}
