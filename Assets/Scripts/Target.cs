using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Target : MonoBehaviour {


    public event System.Action onScore;

    [SerializeField]
    private Collider2D left;
    [SerializeField]
    private Collider2D right;
    [SerializeField]
    private Collider2D target;

	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Ball"){
            if (onScore != null){
                onScore();
            }
        }
    }

    public void EnableColliders(bool enable){
        //left.enabled = enable;
        //right.enabled = enable;
        target.enabled = enable;
    }
}
