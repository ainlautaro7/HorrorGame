using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecusion1 : MonoBehaviour
{
    private MaquinaEstados maquinaEstados;
    private ControladorVision controladorVision;
    private ControladorNavMesh controladorNavMesh;
 
    void Start()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        maquinaEstados = GetComponent<MaquinaEstados>();
    }

    
    void Update()
    {
        RaycastHit hit;
        if (!controladorVision.jugadorEnRango(out hit, true))
        {
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoBusqueda);
            return;

        }
        else
        {
             controladorNavMesh.perseguirObjetivo = hit.transform;
            print(hit.transform.position);
            controladorNavMesh.seguirJugador();
        }

    }
}
