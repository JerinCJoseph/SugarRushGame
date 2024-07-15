using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCollectionController : MonoBehaviour
{
    [SerializeField]private int goalPoints; 
    private int currentScore = 0;
    public PlayerMovements playerMovements; 

    private float originalSpeed; 
    private float speedIncrease = 1.5f; 
    private float speedIncreaseTimePeriod = 10f; 

    public TextMeshProUGUI cscoreTM; //20April
    public TextMeshProUGUI goalTM; //23April
    public TextMeshProUGUI pLifeTM; //24April
    public TextMeshProUGUI gameMessageTM; //21April
    [SerializeField] private AudioSource collectSoundEffect; //20April
    [SerializeField] private AudioSource specialSoundEffect; //20April
    [SerializeField] private AudioSource winSoundEffect; //20April
    public GameMangement gameMangementScript; //21April
    public PlayerLife playerLifeScript; 

    // Start is called before the first frame update
    private void Start()
    {
        if (playerMovements != null)
        {
            originalSpeed = playerMovements.playerSpeed;
            Debug.Log("current speed of player " + originalSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Donut"))
        {
            collectSoundEffect.Play();
            currentScore += 10;
        }
        if (collision.gameObject.CompareTag("Special1")) //speed powerup
        {
            specialSoundEffect.Play();
            //Increase player's speed temporarily
            if (playerMovements != null)
            {
                playerMovements.playerSpeed *= speedIncrease;
                StartCoroutine(ResetSpeedAfterDelay());
                Debug.Log("current speed of player after increased speed" + playerMovements.playerSpeed);
            }
        }

        if (collision.gameObject.CompareTag("HeartCupcake")) //reduce damage powerup
        {
            specialSoundEffect.Play();
            //Reduce the hit count by one only if hits > 0 and < 3
            if (playerLifeScript.globTouches > 0 && playerLifeScript.globTouches < 3)         //globMovementScript.playerTouches > 0 && globMovementScript.playerTouches < 3)
            {
                playerLifeScript.globTouches -= 1;
                Debug.Log("After heart " + playerLifeScript.globTouches);
            }
             

        }
        if (currentScore >= goalPoints) 
        {
            winSoundEffect.Play();
            Debug.Log("You win! Score is " + currentScore);
            cscoreTM.text = "Score: " + currentScore;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                Invoke("LoadNextLevel", .75f);
            }
            else  //show end game screen
            {
                gameMessageTM.text = "You win! Your Score is " + currentScore; //21 April
                gameMangementScript.OnGameOver(); //21April
            }
        }
        cscoreTM.text = "Score: " + currentScore;
        goalTM.text = "Goal: " + goalPoints;
        pLifeTM.text = "Hits: " + playerLifeScript.globTouches; 
    }

    //reset player speed after 10seconds
    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(speedIncreaseTimePeriod);

        //Reset player speed to original value
        if (playerMovements != null)
        {
            playerMovements.playerSpeed = originalSpeed;
            Debug.Log("current speed of player after 10 seconds " + playerMovements.playerSpeed);
        }
    }

    public void OnHitWithGlob()  
    {
        currentScore -= 5;
        Debug.Log("after hit " + currentScore);
        if (currentScore < 0) 
        {
            currentScore = 0;
        }

        pLifeTM.text = "Hits: " + playerLifeScript.globTouches; 
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}

