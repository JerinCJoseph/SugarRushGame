using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    public GameMangement gameMangementScript;   
    public TextMeshProUGUI gameMessageTM; 
    public int globTouches;
    public ItemCollectionController itemCollection;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            globTouches++;
            Debug.Log("glob touches: " + globTouches);
            if (globTouches == 3)  //old >=3
            {
                Die();
            }
            else if (globTouches > 0 && globTouches < 3)
            {
                itemCollection.OnHitWithGlob();     //20April              
            }
            else
            {
                globTouches = 0;
            }
        }
    }

    public void Die()
    {
        deathSoundEffect.Play();
        gameMessageTM.text = "You Lose";
        anim.SetTrigger("death");
    }

    private void GameOverScreen() 
    {
        Debug.Log("The player is destroyed");
        gameMangementScript.OnGameOver();  //21April
    }
}