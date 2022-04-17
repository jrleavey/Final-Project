using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throwable : MonoBehaviour
{
    public float _speed = 100;
    public Rigidbody rgb;
    public GameObject monster;
    public Transform collisionPosition;
    public AudioClip collisionSound;
    // Start is called before the first frame update
    private void Awake()
    {
        monster = GameObject.Find("Monster");
    }
    void Start()
    {
        //Movement();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Hit the Ground");
            monster.GetComponent<AISeeing>().distractionCollisionPoint = collisionPosition;
            monster.GetComponent<AISeeing>().isDistractionCollided = true;
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}
