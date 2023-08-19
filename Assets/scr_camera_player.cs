using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_camera_player : MonoBehaviour
{
    public float swayAmount = 0.05f; // Cantidad de oscilación lateral
    public float swaySpeed = 1.5f;   // Velocidad de oscilación lateral

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Simular oscilación lateral
        float swayX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        float swayZ = Mathf.Cos(Time.time * swaySpeed) * swayAmount;
        Vector3 swayOffset = new Vector3(swayX, 0f, swayZ);

        // Aplicar el offset de oscilación a la posición de la cámara
        transform.localPosition = initialPosition + swayOffset;
    }
}