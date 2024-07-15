using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GlobMovement : MonoBehaviour
{
    private Animator globAnim;
    [SerializeField] private Transform player; //player's transform
    public float moveSpeed; //glob's speed
    private bool isGrounded; //glob is on ground check
    public int playerTouches; //player touched glob count
    private UnityEngine.Object globRef;
    private Rigidbody2D rb;
    private SpriteRenderer spriteR;
    private enum MovementState { idle, hopping, falling, attacked } //20April attacked added
    private float fallSpeed = 0.5f; // Speed at which the glob falls
    [SerializeField] private AudioSource deathSoundEffect; //20April
    [SerializeField] private AudioSource collisionSoundEffect; //20April
    private bool isHit; //20April

    public ItemCollectionController itemCollection;  //20April
    public TextMeshProUGUI pLifeTM; 
    Vector3 startPosition;
    
    void Start()
    {
        globRef = Resources.Load("SugarGlob");
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        globAnim = GetComponent<Animator>();
        isHit = false; //20April
        startPosition = transform.position;
        
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            //StartCoroutine(RespawnAfterDelay(15f)); 
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            StartCoroutine(RespawnAfterDelay(12f)); 
        }
        
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        //Respawn the glob
        GameObject globClone = (GameObject)Instantiate(globRef, startPosition, Quaternion.identity);
        globClone.transform.position = new Vector3(UnityEngine.Random.Range(startPosition.x - 5f, startPosition.x + 5f), startPosition.y, startPosition.z);
        //Get movement script and Rb of the clone
        GlobMovement cloneMovement = globClone.GetComponent<GlobMovement>();
        Rigidbody2D rbClone = globClone.GetComponent<Rigidbody2D>();
        if (rbClone != null && cloneMovement != null)
        {
            cloneMovement.player = player; //Set player reference for the cloned glob
            rbClone.velocity = Vector2.down * fallSpeed;
        }
    }
    void FixedUpdate()
    {
        if (isGrounded && player != null)
        {
            //Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        }
        UpdateAnimatorState();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void UpdateAnimatorState()
    {
        MovementState state;
        if (rb.velocity.x > 0f)   //right
        {
            state = MovementState.hopping;
            spriteR.flipX = false;
        }
        else if (rb.velocity.x < 0f)    //left
        {
            state = MovementState.hopping;
            spriteR.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y < -0.25f)   
        {
            state = MovementState.falling;
        }

        if (isHit) //20April
        {
            state = MovementState.attacked;
            Debug.Log("Glob is Hit"); //20April
            Die(); //20April
        }
        globAnim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionSoundEffect.Play();
            MoveAway(collision.gameObject.transform);
        }
    }

    private void MoveAway(Transform playerTransform)
    {
        Vector3 direction = (transform.position - playerTransform.position).normalized;
        float moveDistance = 1f;  //0.5f
        rb.AddForce(-direction * moveDistance, ForceMode2D.Force); 
        Rigidbody2D playerRigidbody = playerTransform.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.AddForce(-direction * moveDistance, ForceMode2D.Force); 
        }

    }

    private void OnTriggerEnter2D(Collider2D pCollider) 
    {
        if (pCollider.gameObject.CompareTag("Player")) 
        {
            Vector2 playerPosition = pCollider.transform.position;
            Vector2 enemyPosition = transform.position;
            if (playerPosition.y > enemyPosition.y)  
            {
                isHit = true;

                //bounce the player up
                Rigidbody2D playerRb = pCollider.GetComponent<Rigidbody2D>();
                float bounceHeight = 5f;
                if (playerRb != null)
                {
                    float bounceVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * bounceHeight);
                    //Set the player's y-velocity to the bounce velocity
                    playerRb.velocity = new Vector2(playerRb.velocity.x, bounceVelocity);
                }
            }
        }
    }

    private void Die()
    {

        globAnim.SetTrigger("death");
        Debug.Log("This glob is now killed");
        Invoke("Respawn", .25f);
        
    }

    private void Respawn()
    {
        gameObject.SetActive(false);
        Invoke("RespawnNew", 5f);
        
    }
    private void RespawnNew() 
    {
        GameObject globClone = (GameObject)Instantiate(globRef, startPosition, Quaternion.identity);
        globClone.transform.position = new Vector3(UnityEngine.Random.Range(startPosition.x - 5f, startPosition.x + 5f), startPosition.y, startPosition.z);
        GlobMovement cloneMovement = globClone.GetComponent<GlobMovement>();
        Rigidbody2D rbClone = globClone.GetComponent<Rigidbody2D>();
        if (rbClone != null && cloneMovement != null)
        {
            cloneMovement.player = player; //Set player reference for the cloned glob
            rbClone.velocity = Vector2.down * fallSpeed;
        }
        gameObject.SetActive(true); 
        Destroy(gameObject);
    }

}