using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bat : MonoBehaviour
{
    public const float Speed = 0.15f;

    public enum Side
    {
        Left = -30,
        Right = 30
    }

    [SerializeField] private Side side;


    private Rigidbody2D rb;
    private Tweener tweener;
    private float originalAngle;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        originalAngle = transform.localEulerAngles.z;
        if (originalAngle > 90f)
        {
            originalAngle -= 360f;
        }
    }

    void Update()
    {
        switch (side)
        {
            case (Side.Left): {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Kick();
                }
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {
                    Release();
                }
                    break;
            }
            case (Side.Right): {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Kick();
                }
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
                    Release();
                }
                break;
            }
        }
    }
	
    public void Kick()
    {
        if (tweener != null && tweener.IsPlaying()) {
            tweener.Complete();
        }
        tweener = rb.DORotate(originalAngle * -1, Speed);
    }

    public void Release()
    {
        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Complete();
        }
        tweener = rb.DORotate(originalAngle, Speed);
    }
}
