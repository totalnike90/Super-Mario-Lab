using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableMushroom : MonoBehaviour
{
    private float speed = 10;
    private Vector2 currentPosition;
    private Vector2 currentDirection;

    private Rigidbody2D mushroomBody;
    // Start is called before the first frame update
    void Start()
    { 
        currentDirection = new Vector2(1,0);
        mushroomBody = GetComponent<Rigidbody2D>();
        mushroomBody.AddForce(Vector2.up  *  20, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nextPosition = mushroomBody.position + speed * currentDirection.normalized * Time.fixedDeltaTime;
        mushroomBody.MovePosition(nextPosition);
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("pipes"))
        {
            currentDirection = -1 * currentDirection;

        }

        if (col.gameObject.CompareTag("Player"))
        {
            speed = 0;

        }
    }

    void  OnBecameInvisible()
    {
        Destroy(gameObject);	
    }
}
