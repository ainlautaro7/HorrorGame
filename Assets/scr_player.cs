using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    //variable para el rigidbody
    Rigidbody rb;
    //variable para el animator
    Animator anim;
    //variables para moverse con teclado
    Vector2 inputMov;
    public float velMov = 10;
    public float velMovCorrer = 40;

    //variables para rotacion con mouse
    Vector2 inputRotacion;
    public float sensibilidadMouse = 800;
    Transform cam;
    float rotX;

    //variables para agacharse
    Vector3 escalaNormal;
    Vector3 escalaAgachado;
    bool agachado;

    //variable para la gravedad
    private float gravity = -50;

    //variable para salto
    private float fuerzaSalto = 1200;
    private bool isGrounded = false;
    private ArrayList canJumpTags = new ArrayList() { "Floor", "Box" };

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics.gravity = new Vector3(0, gravity, 0);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

        cam = transform.GetChild(0);
        rotX = cam.eulerAngles.x;

        escalaNormal = transform.localScale;
        escalaAgachado = escalaNormal;
        escalaAgachado.y = escalaNormal.y * .75f;
    }

    // Update is called once per frame
    void Update()
    {
        //leer inputs
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRotacion.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        inputRotacion.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        //agachado
        agachado = Input.GetKey(KeyCode.C);
        //animaciojn
        anim.SetFloat("movX",inputMov.x);
        anim.SetFloat("movY",inputMov.y);
        if (isGrounded && Input.GetButtonDown("Jump")) // Verifica si est� en el suelo y se presion� el bot�n de salto
        {
            rb.AddForce(Vector3.up * fuerzaSalto); // Aplica una fuerza vertical para el salto
            isGrounded = false; // Evita saltar nuevamente hasta que est� en el suelo de nuevo
        }

    }

    private void FixedUpdate()
    {
        float vel = (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Fire2")) ? velMovCorrer : velMov;

        rb.velocity = transform.forward * vel * inputMov.y //movernos adelante y atras
            + transform.right * vel * inputMov.x //movernos a los costados
            + new Vector3(0, rb.velocity.y, 0);
        //0, 0, 1 en z para que se mueva adelante

        transform.rotation *= Quaternion.Euler(0, inputRotacion.x, 0);

        rotX -= inputRotacion.y;
        rotX = Mathf.Clamp(rotX, -50, 50);
        cam.localRotation = Quaternion.Euler(rotX, 0, 0);
        //agacharse

        transform.localScale = Vector3.Lerp(
            transform.localScale,
           agachado ? escalaAgachado : escalaNormal,
           .1f);


    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Box"))
            isGrounded = true; // Marca que el jugador est� en el suelo cuando colisiona con un objeto con el tag "Floor"
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Box"))
            isGrounded = false; // Marca que el jugador ya no est� en el suelo cuando deja de colisionar con un objeto con el tag "Floor"
    }
}