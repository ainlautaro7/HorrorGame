using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoBusqueda : MonoBehaviour
{
    public float velocidadGiro = 120f;
    public float duracionBusqueda = 3f;
   
    private MaquinaEstados maquinaEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private float tiempoBuscando;
    // Start is called before the first frame update
    void Awake()
    {
        maquinaEstados = GetComponent<MaquinaEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }
    void OnEnable()
    {
        tiempoBuscando = 0;
        controladorNavMesh.detenerse();
       
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //ve al jugador?
       
        if (controladorVision.jugadorEnRango(out hit))
        {

            controladorNavMesh.perseguirObjetivo = hit.transform;
            print(hit.transform.position);
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoPersecucion);
            return;
        }
        transform.Rotate(0f, velocidadGiro*Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoPatrulla);
            return;
        }
            
    }
}
