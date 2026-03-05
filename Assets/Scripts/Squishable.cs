using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class Squishable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem squishParticles;
    public GameObject puddle;
    public GameObject thingToSquish;
    public GameObject brokenHalf;
    public Color color;
    public GameObject[] spawn;
    bool squished = false;
    public bool gnome = false;
    public bool lego = false;
    Camera_Rotation cam;
    public float cameraShakeTime = 0.1f;
    public float cameraShakeAmmount = 0.1f;

    private void Start()
    {
        color = new Color(color.r + Random.Range(-0.2f, 0.2f), color.g + Random.Range(-0.2f, 0.2f), color.b + Random.Range(-0.2f, 0.2f));
        var particleMaterial = squishParticles.main;
        particleMaterial.startColor = color;
        cam = FindAnyObjectByType<Camera_Rotation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (squished) return;

        Foot foot = other.gameObject.GetComponent<Foot>();
        if (foot != null)
        {
            Destroy(thingToSquish);
            cam.ScreenShake(cameraShakeTime, cameraShakeAmmount);
            if (puddle != null)
            {
                squishParticles.Play();
                puddle.GetComponent<puddleGrow>().StartTimer();
                puddle.GetComponent<puddleGrow>().setColor(color);
                foot.setSplatColor(color);
            }
            if (brokenHalf != null)
            {
                GameObject child = Instantiate(brokenHalf);
                Vector3 newpos = new Vector3(transform.position.x, 0.0f, transform.position.z);
                child.transform.position = transform.position;
            }
            if (spawn != null && spawn.Length > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int dice = Random.Range(0,spawn.Length - 1);
                    Debug.Log(dice);
                    GameObject child = Instantiate(spawn[dice]);
                    child.transform.position = transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                }
            }
            if (gnome)
            {
                GetComponentInParent<followPlayer>().stop = true;
                transform.parent.gameObject.transform.rotation = Quaternion.identity;
            }
            squished = true;
        }
    }
}

