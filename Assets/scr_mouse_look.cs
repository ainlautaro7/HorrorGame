using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MouseLook : MonoBehaviour
{
    public Transform target;
    public float speed = .5f;
    public CharacterController characterController { get; private set; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.RotateAround(target.position, Vector3.up, mouseX);
        if (mouseY > -40 && mouseY < 60)
        {
            transform.RotateAround(target.position, transform.right, -mouseY);
        }
    }
}