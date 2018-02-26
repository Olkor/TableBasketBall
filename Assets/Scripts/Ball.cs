using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
	public const string Tag = "Ball";
    [SerializeField]
    private float topY;
    [SerializeField]
    private float bottomY;

    private Vector2 startPosition;
    private Rigidbody2D rb;
    private Target target;

    private void Start ()
	{
		gameObject.tag = Tag;
	    rb = GetComponent<Rigidbody2D>();
	    startPosition = rb.position;
        target = FindObjectOfType<Target>();
	}

    private void Update()
    {
        if (transform.position.y > topY){
            target.EnableColliders(true);
        }
        else{
            if (transform.position.y < bottomY){
                target.EnableColliders(false);
            }
        }
    }

    private void Restart () {
		rb.MovePosition(startPosition);
	    rb.velocity = Vector2.zero;
	    rb.angularVelocity = 0f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Failed")
        {
            Restart();
        }
    }
}
