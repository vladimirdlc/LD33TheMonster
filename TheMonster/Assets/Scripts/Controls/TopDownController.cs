using UnityEngine;
using System.Collections;

public class TopDownController : MonoBehaviour {
    public float speed;

    void FixedUpdate()
    {
        mouseLook();

    }

    void mouseLook()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition,
                                                  Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * inputVertical * Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * inputHorizontal * Time.deltaTime);
    }
}
