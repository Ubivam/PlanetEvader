using UnityEngine;

public class Pulse : MonoBehaviour {

    private SpriteRenderer sr;
    [SerializeField]
    private float mul = 5.0f;

	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.4f + ((Mathf.Sin(Time.time * 1.75f) + 1) / 2) * 0.6f);
    }
}
