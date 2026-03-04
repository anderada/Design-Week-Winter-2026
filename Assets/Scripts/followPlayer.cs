using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject player;
    public bool stop = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stop) return;
        Vector3 distanceToPlayer = transform.position - player.transform.position;
        if (distanceToPlayer.magnitude > 2.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }
        transform.LookAt(player.transform.position);
    }
}
