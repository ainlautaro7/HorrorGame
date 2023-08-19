using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVision : MonoBehaviour
{
    public Transform ojos;
    public Transform ojos1;
    public Transform ojos2;
    public float rangoVision = 10f;
    public Vector3 offset = new Vector3(0f, 0f, 0f);

    private ControladorNavMesh controladorNavMesh;

    private void Start()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
    }
    public bool jugadorEnRango(out RaycastHit hit, bool mirarHaciaJugador = false)
    {
        Vector3 vectorDireccion;
        Vector3 vectorDireccion1;
        Vector3 vectorDireccion2;
        if (mirarHaciaJugador)
        {
            vectorDireccion = (controladorNavMesh.perseguirObjetivo.position + offset) - ojos.position;
            vectorDireccion1 = (controladorNavMesh.perseguirObjetivo.position + offset) - ojos1.position;
            vectorDireccion2 = (controladorNavMesh.perseguirObjetivo.position + offset) - ojos2.position;
        }
        else
        {
            vectorDireccion1 = ojos1.forward;
            vectorDireccion2 = ojos2.forward;
            vectorDireccion = ojos.forward;
        }

        //rayo        posicion de donde saldra el rayo  hit   rango
        Debug.DrawRay(ojos.transform.position, vectorDireccion * rangoVision, Color.blue, 0.1f);
        Debug.DrawRay(ojos1.transform.position, vectorDireccion1 * rangoVision, Color.blue, 0.1f);
        Debug.DrawRay(ojos2.transform.position, vectorDireccion2* rangoVision, Color.blue, 0.1f);
        return (Physics.Raycast(ojos.position, vectorDireccion, out hit, rangoVision)
          && hit.collider.CompareTag("Player")|| Physics.Raycast(ojos1.position, vectorDireccion1, out hit, rangoVision)
          && hit.collider.CompareTag("Player")|| Physics.Raycast(ojos2.position, vectorDireccion2, out hit, rangoVision)
          && hit.collider.CompareTag("Player"));
            //detecta si alcanzo a cualquier collider con el tag player
        

    }
   






}
