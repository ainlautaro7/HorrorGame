using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EstadoPatrulla : MonoBehaviour
{

   
    public Transform[] patrolPoints;

    private ControladorVision controladorVision;
    private ControladorNavMesh controladorNavMesh;
    private MaquinaEstados maquinaEstados;
    private float changeTargetDistance = 2f;
    private int currentTarget;
    

    void Start()
    {

        currentTarget = GetNextTarget();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        maquinaEstados = GetComponent<MaquinaEstados>();
    }


    private void Update()
    {
        RaycastHit hit;
        //ve al jugador?
        if (controladorVision.jugadorEnRango(out hit))
        {
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoPersecucion);
            return;
        }
        
        if (MoveToTarget()) {
          currentTarget = GetNextTarget(); 
        }
       

    }
    // Update is called once per frame
    void FixedUpdate()
    {


    }
    private bool MoveToTarget()
    {

        Vector3 distanceVector = patrolPoints[currentTarget].position - transform.position;
        if (distanceVector.magnitude <= changeTargetDistance)
        {
            print("entro a true");
            return true;
        }
        else
        {

            // agent.SetDestination(new Vector3(patrolPoints[currentTarget].position.x, patrolPoints[currentTarget].position.y, patrolPoints[currentTarget].position.z));
            controladorNavMesh.actualizarPuntoDestino(patrolPoints[currentTarget].transform.position);
            print("entro a false, osea nunca llego a su objetivo");
            print(patrolPoints[currentTarget].position + "posicion enemigo" + transform.position + "punto" + currentTarget);
            return false;
        }

    }

    private int GetNextTarget()
    {
       
        var newCurrentTarget = Random.Range(0, patrolPoints.Length);
       
        return newCurrentTarget;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            print("entro al colider");
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoBusqueda);
        }
    }
}
