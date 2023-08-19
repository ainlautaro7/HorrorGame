using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    [HideInInspector]
    public Transform perseguirObjetivo;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void actualizarPuntoDestino(Vector3 puntoDestino)
    {
        agent.destination = puntoDestino;
        agent.isStopped = false;
    }

    public void detenerse()
    {

        agent.isStopped  = true;
        
    }

    public bool puntoAlcanzado()
    {
        print("remaing");
        print(agent.remainingDistance);
        print("stop");
        print(agent.stoppingDistance);
        return (agent.remainingDistance <= agent.stoppingDistance &&
              !agent.pathPending);
    }

    public void seguirJugador()
    {
        print(perseguirObjetivo.position+"seguir jugador");
        actualizarPuntoDestino(perseguirObjetivo.position);
    }

}
