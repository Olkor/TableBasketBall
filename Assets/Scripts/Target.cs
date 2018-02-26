using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Target : MonoBehaviour {

    public event System.Action onScore;

    [SerializeField]
    private Collider2D target;

	private void OnTriggerEnter2D(Collider2D otherCollider)
    {
		if (otherCollider.tag == Ball.Tag){
            if (onScore != null){
                onScore();
            }
        }
    }

    public void EnableColliders(bool enable){
		if (target.enabled != enable) {
        	target.enabled = enable;
		}
    }
}
