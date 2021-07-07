using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public  Renderer[] layers;
	public float[] speedMultiplier;
	private float previousXPositionMario;
	private float previousXPositionCamera;
	public Transform mario;
	public Transform mainCamera;
	private float[] offset;

    void Start()
    {
        Debug.Log("parallax scroller started");
        offset = new  float[layers.Length];
		for(int i = 0; i<  layers.Length; i++){
			offset[i] = 0.0f;	
		}
		previousXPositionMario = mario.transform.position.x;
		previousXPositionCamera = mainCamera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // check if camera has moved
        // Debug.Log(mario.transform.position.x);
        // Debug.Log(previousXPositionCamera);
        Debug.Log(mainCamera.transform.position.x);
        if (Mathf.Abs(previousXPositionCamera  -  mainCamera.transform.position.x) >  0.001f)
        {
            Debug.Log("camera has moved");
            for(int i =  0; i<  layers.Length; i++)
            {
                if (offset[i] > 1.0f  ||  offset[i] <  -1.0f)
                {
                    Debug.Log("camera has moved 2");
                    offset[i] =  0.0f; //reset offset   
                }
                float newOffset =  mario.transform.position.x  -  previousXPositionMario;
                offset[i] =  offset[i] +  newOffset  *  speedMultiplier[i];
                layers[i].material.mainTextureOffset  =  new  Vector2(offset[i], 0);
            }
        }
        //update previous pos
        previousXPositionMario  =  mario.transform.position.x;
        previousXPositionCamera  =  mainCamera.transform.position.x;
    }
    
}
