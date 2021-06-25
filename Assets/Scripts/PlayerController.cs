using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //adjustable properties
    public float speed;
    public float upSpeed;
    public float maxSpeed = 10;

    //components
    private Rigidbody2D marioBody;
    private SpriteRenderer marioSprite;
    private Animator marioAnimator;
    private AudioSource marioAudioSource;

    // internal Mario states
    private bool onGroundState = true;
    private bool faceRightState = true;
    // public Transform enemyLocation;
    // public Text scoreText;
    // public int score = 0;
    // private bool countScoreState = false;

    public bool alive;

    // Start is called before the first frame update
    void  Start()
    {
     	// Set to be 30 FPS
	    Application.targetFrameRate =  30;
	    marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>(); 
        marioAnimator = GetComponent<Animator>();
        marioAudioSource = GetComponent<AudioSource>();
        alive = true; 
    }

    void Update()
    {
        if (Input.GetKeyDown("a") && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;

            // check velocity
            if (Mathf.Abs(marioBody.velocity.x) >  0.01) {
	            marioAnimator.SetTrigger("onSkid");
            }

        }

        if (Input.GetKeyDown("d") && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;

            // check velocity
            if (Mathf.Abs(marioBody.velocity.x) >  0.01) {
	            marioAnimator.SetTrigger("onSkid");
            }

        }

        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
        // if (!onGroundState && countScoreState)
        // {

        //     if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f)
        //     {
        //         countScoreState = false;
        //         score++;
        //         Debug.Log(score);
        //     }
        // }   
    }

    void FixedUpdate()
    {
        // dynamic rigidbody
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            Vector2 movement = new Vector2(moveHorizontal, 0);
            if (marioBody.velocity.magnitude < maxSpeed)
            {
                    marioBody.AddForce(movement * speed);
            }
        }
        if (Mathf.Abs(marioBody.velocity.y) > 0)
        {
            onGroundState = false;
        }

        if (Input.GetKeyDown("a") == false && Input.GetKeyDown("d") == false && onGroundState)
        {
            // stop
            marioBody.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown("space") && onGroundState)
        {
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;

            marioAnimator.SetBool("onGround", onGroundState);

            // countScoreState = true; //check if Gomba is underneath
        }

    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGroundState = true; // back on ground
            marioAnimator.SetBool("onGround", onGroundState);
            // countScoreState = false; // reset score state
            // scoreText.text = "Score: " + score.ToString();

        }

        if (col.gameObject.CompareTag("Obstacles") && Mathf.Abs(marioBody.velocity.y) < 0.01f)
        {
            onGroundState = true; // back on ground
            marioAnimator.SetBool("onGround", onGroundState);

        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Gomba!");
            alive = false;
            Debug.Log("here");
            Time.timeScale = 0;
            Debug.Log("here2");
        }
    }

    void  PlayJumpSound()
    {
	marioAudioSource.PlayOneShot(marioAudioSource.clip);
    }   


}
