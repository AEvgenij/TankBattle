using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class ArmBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public GameObject Core;

    private float old_angle;

    private float xRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var thisPos = this.transform.position;
            // z++
            //thisPos.z += 15f;
            var newCore = Instantiate(Core, thisPos, Quaternion.Euler(new Vector3(0, 0, 0)));

            newCore.transform.rotation = this.transform.rotation;
            newCore.transform.position = this.transform.position;
            newCore.transform.Translate(new Vector3(0, 0, 15f));

            var aus = gameObject.GetComponent<AudioSource>();
            aus.PlayOneShot(aus.clip);
        }
        float v = Input.GetAxis("Mouse Y");
        float speed = 0.5f;
        this.transform.Rotate(-v * speed, 0, 0);

        xRotation -= v * speed;
        xRotation = Mathf.Clamp(xRotation, -10, 3);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //float min = 80f;
        //float max = 120f;
        //float new_angle = Mathf.Clamp(this.transform.localEulerAngles.x, min, max);
        //this.transform.localEulerAngles = new Vector3(new_angle, 0, 0);

    }

    private void OnGUI()
    {
        // GUIStyle style = new GUIStyle();
        // style.fontSize = 24;
        // GUI.Label(new Rect(10, 0, 0, 0), "lOCAL EULER ANGLES: " + transform.localEulerAngles, style);
        // GUI.Label(new Rect(10, 25, 0, 0), "EULER ANGLES: " + transform.eulerAngles, style);
        // GUI.Label(new Rect(10, 50, 0, 0), "Rotation: " + xRotation, style);
    }

}
