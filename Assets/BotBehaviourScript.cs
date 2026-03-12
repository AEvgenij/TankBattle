using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BotBehaviourScript : MonoBehaviour
{
    float moveSpeed = 0.03f;
    float turnSpeed = 0.3f;
    float towerTurnSpeed = 0.4f;
    public Transform Tower;
    public Transform Arm;
    public GameObject Core;
    bool canShoot = true;
    int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BotShoot()
    {
        canShoot = false;
        //Vector3 armForward = Arm.transform.position + Arm.TransformDirection(Vector3.forward * 4f);
        var newCore = Instantiate(Core, Arm.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        newCore.transform.rotation = Arm.transform.rotation;
        newCore.transform.position = Arm.transform.position;
        newCore.transform.Translate(new Vector3(0, 0, 15f));

        yield return new WaitForSeconds(3f);
        canShoot = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if  (other.CompareTag("Player"))
        {
            float distance = Vector3.Distance(other.transform.position, this.transform.position);
            Vector3 relativePos = (other.transform.position - this.transform.position);
            Quaternion newRot = Quaternion.LookRotation(relativePos);
            if (distance < 50)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRot, Time.deltaTime * turnSpeed);
                this.transform.position = Vector3.Lerp(this.transform.position, other.transform.position, Time.deltaTime * moveSpeed);
            }
            Tower.rotation = Quaternion.Slerp(Tower.rotation, newRot, Time.deltaTime * towerTurnSpeed);
            //Arm.rotation = Quaternion.Slerp(Arm.rotation, newRot, Time.deltaTime * towerTurnSpeed);
            RaycastHit hit;
            if (Physics.Raycast(Arm.transform.position, Arm.transform.TransformDirection(Vector3.forward), out hit))
            {
                //Debug.Log(hit.transform.position);
                if (hit.transform.CompareTag("Player") && canShoot)
                {
                    //Debug.Log("SHOOT");
                    //StartCoroutine(BotShoot());
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Core"))
        {
            Debug.Log("Core Collision");
            if (--life < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
