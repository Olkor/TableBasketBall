using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Vector2 startPosition;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
	    startPosition = rb.position;
	}
	
	// Update is called once per frame
	void Restart () {
		rb.MovePosition(startPosition);
	    rb.velocity = Vector2.zero;
	    rb.angularVelocity = 0f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Failed")
        {
            Restart();
        }
    }
}
