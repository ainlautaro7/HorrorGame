using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstados : MonoBehaviour
{
    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoBusqueda;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicial;
    public GameObject skel;
    private Animator anim;

    private MonoBehaviour estadoActual;

    void Start()
    {
        anim = skel.transform.gameObject.GetComponent<Animator>();
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        anim.SetFloat("movX",1f);
        if (estadoActual != null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;


    }
}
