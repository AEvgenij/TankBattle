using UnityEngine;

public class TankBehaviourScript : MonoBehaviour
{
    AudioSource audTank;
    bool isPlayiing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audTank = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(0, 0, v / 12);
        transform.Rotate(new Vector3(0, h / 10, 0));
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        //y = Mathf.Clamp(y, 0, 90);
        float sensitivity = 8;
        //transform.Rotate(0, x * sensitivity, 0);

        if ((h != 0 || v != 0) && !isPlayiing)
        {
            audTank.Play();
            isPlayiing = true;
        }
        if (h == 0 && v == 0 && isPlayiing)
        {
            audTank.Stop();
            isPlayiing = false;
        }
    }
}
