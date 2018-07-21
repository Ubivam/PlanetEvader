using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    private Rigidbody rigiB;

    [SerializeField]
    private float distance;

    [SerializeField]
    private int life = 5;
    private int currLife;

    [SerializeField]
    private float scaleIncrement = 1.0f;

    private void Start()
    {
        rigiB = gameObject.GetComponent<Rigidbody>();
        currLife = life;
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
        }
        onHit();
    }

    private void onHit()
    {
        if (currLife > 0)
        {
            --currLife;
            shrinkSize();
        } else
        {
            
            // end game
            Destroy(gameObject);
        }
    }

    private void shrinkSize()
    {
        rigiB.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
    }

}
