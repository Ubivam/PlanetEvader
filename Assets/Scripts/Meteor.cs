using UnityEngine;

public class Meteor : MonoBehaviour {
    Rigidbody rigiB;
    [SerializeField]
    private float startVelocity = 10.0f;
    [SerializeField]
    private float bigAcceleration = 0.5f;
    [SerializeField]
    private float smallAcceleration = 0.5f;

    private Planet planet;

    private Vector3 lastFramePosition;


    
    private void Start()
    {
        planet = GameObject.FindObjectOfType<Planet>();
        rigiB = gameObject.GetComponent<Rigidbody>();
        lastFramePosition = rigiB.position;
        //rigiB.AddForce((positionOfPlanet.position - rigiB.transform.position).normalized * acceleration);
        rigiB.velocity = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized*startVelocity;
    }

    private void FixedUpdate()
    {
        float acceleration;
        if((rigiB.position-planet.transform.position).magnitude > (lastFramePosition - planet.transform.position).magnitude)
        {
            Debug.Log("Big Acceleration");
            acceleration = bigAcceleration;
        }
        else
        {
            Debug.Log("Small Acceleration");
            acceleration = smallAcceleration;
        }
        rigiB.AddForce((planet.transform.position - rigiB.transform.position).normalized *acceleration );
        lastFramePosition = rigiB.position;
    }
}
