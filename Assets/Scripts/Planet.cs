using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    private Rigidbody rigiB;

    [SerializeField]
    private float distance;

    private void Start()
    {
        rigiB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.y = 0.0f;
        
        if((new Vector3(0, 0, 0)-mouseWorldPos).magnitude > distance)
        {
            mouseWorldPos = mouseWorldPos.normalized * distance;
        }
        rigiB.velocity = new Vector3(0, 0, 0);

        rigiB.MovePosition(mouseWorldPos);
    }

}
