//Rosas Castillo Gabriela
// GDGS2102
// 10/10/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    //nueva variable privada float repeatWidth
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        
    }

    //restablecer la posición si se mueve una cierta distancia
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        
    }
}
