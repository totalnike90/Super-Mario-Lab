using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakBrick : MonoBehaviour
{
    public GameObject debris;

    private bool broken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Edge Collider Triggered");
        if (col.gameObject.CompareTag("Player") &&  !broken)
        {
            Debug.Log("Tag=player & not broken");
            broken  =  true;
            // assume we have 5 debris per box
            for (int x =  0; x<5; x++)
            {
                Debug.Log("spawn debris");
                Instantiate(debris, transform.position, Quaternion.identity);
            }
            gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled  =  false;
            gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled  =  false;
            GetComponent<EdgeCollider2D>().enabled  =  false;
        }
    }
}
