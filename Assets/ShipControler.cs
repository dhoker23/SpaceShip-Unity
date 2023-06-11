using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControler : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float angleSpeed = 0.5f;
    [SerializeField] private ParticleSystem[] ps;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponentsInChildren<ParticleSystem>();
        foreach (var particle in ps)
        {
            particle.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        if(x != 0)
        {
            foreach(var particle in ps)
            {
                particle.gameObject.SetActive(true);
            }
        }
        else if (y < 0)
        {   
            var particle = ps[0];
            particle.gameObject.SetActive(true);
        }
        else if (y > 0)
        {
            var particle = ps[1];
            particle.gameObject.SetActive(true);
        }
        else
        {
            foreach (var particle in ps)
            {
                particle.gameObject.SetActive(false);
            }
        }
        rb.AddRelativeForce(0f,0f, speed * x);
        rb.AddRelativeTorque(0f,angleSpeed*y, 0f);

    }
}
