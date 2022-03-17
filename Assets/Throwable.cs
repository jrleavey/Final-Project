using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float _speed = 100;
    public Rigidbody rgb;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        Movement();
        StartCoroutine(DespawnTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Movement()
    {
        rgb.AddForce(rgb.transform.forward * _speed);
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
