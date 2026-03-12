using Unity.VisualScripting;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour
{
    public GameObject Light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Light.GetComponent<Light>().intensity = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        Light.GetComponent<Light>().intensity = 0;
    }
}
