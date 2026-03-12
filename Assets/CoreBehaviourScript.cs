using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBehaviourScript : MonoBehaviour
{

    public GameObject Explosion;
    public GameObject Capsule;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    float speed = 0.8f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0f;
        this.GetComponent<CapsuleCollider>().enabled = false;
        //Debug.Log("Collision");
        Instantiate(Explosion, this.transform.position, this.transform.rotation);
        var aus = gameObject.GetComponent<AudioSource>();
        aus.PlayOneShot(aus.clip);
        Capsule.GetComponent<Renderer>().enabled = false;
        //Destroy(gameObject);

        if (collision.gameObject.CompareTag("dummy"))
        {
            Debug.Log("Collision dummy");
            //collision.gameObject.transform.Translate(Vector3.up);
        }
    }

}
