using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform targetPlayer;
    public float rotateSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        transform.RotateAround(targetPlayer.transform.position, Vector3.up, mx * rotateSpeed);
    }
}
