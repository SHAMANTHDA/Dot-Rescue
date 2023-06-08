using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class round : MonoBehaviour
{

    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
