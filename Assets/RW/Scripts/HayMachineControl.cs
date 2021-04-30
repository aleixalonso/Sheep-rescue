using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachineControl : MonoBehaviour
{
    public float inputKeyValue;
    public float moveAmount = 1;
    public float thresholdShoot = 0.5f;
    float measureTime = 0;

    public GameObject hayShootObject;

    // Start is called before the first frame update
    void Start()
    {
        measureTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Space) && (Time.time - measureTime) > thresholdShoot)
        {
            Shoot();
            measureTime = Time.time;
        }

    }

    void Move()
    {
        inputKeyValue = Input.GetAxis("Horizontal");
        Vector3 newPos = transform.position + Vector3.right * moveAmount * inputKeyValue;
        if (newPos.x > -20 && newPos.x < 20)
        {
            transform.Translate(Vector3.right * moveAmount * inputKeyValue);
        }

    }

    void Shoot()
    {
        Instantiate(hayShootObject, transform.position, Quaternion.identity, transform);
    }
}
