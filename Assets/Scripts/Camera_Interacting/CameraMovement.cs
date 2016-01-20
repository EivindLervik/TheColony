using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public GameObject kameraObject;
    public float moveSpeed;
    public float minZoomHeight;
    public float maxZoomHeight;

    private Camera kamera;
    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        kamera = kameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * moveSpeed * 0.01f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * moveSpeed * 0.01f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * moveSpeed * 0.01f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector3.back * moveSpeed * 0.01f);
        }

        //Zoom
        if (Input.mouseScrollDelta.y != 0.0f)
        {
            Vector3 prevHeight = kameraObject.transform.position;
            kameraObject.transform.Translate(Vector3.forward * Input.mouseScrollDelta.y);
            if (kameraObject.transform.position.y < minZoomHeight)
            {
                kameraObject.transform.position = prevHeight;
            }
            else if (kameraObject.transform.position.y > maxZoomHeight)
            {
                kameraObject.transform.position = prevHeight;
            }
        }
    }

}
