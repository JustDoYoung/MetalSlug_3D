using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject heavyMachinGun;
    public GameObject defaultGun;
    float speed = 10f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = heavyMachinGun.GetComponent<Rigidbody>();
        rb = defaultGun.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
