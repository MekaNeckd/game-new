using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anim;
    public bool dying = false;
    // Start is called before the first frame update
    void Start()
    {
             rb2d = GetComponent<Rigidbody2D>();
             anim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("light"))
         {
            GameManager.instance.GetComponent<GameManager>().deathtime += .01f;
           
         }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("light"))
        {
            GameManager.instance.GetComponent<GameManager>().deathtime = 0;

        }

    }
    public void Die() 
    {
        dying = true;
        GameManager.instance.GetComponent<GameManager>().deathtime = 0;
        rb2d.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death.R");
    } 
 
    private void RestartLevel()
    {
        if (GameManager.instance.GetComponent<GameManager>().health > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Destroy(GameManager.instance);
            SceneManager.LoadScene("GameMain(Final)(NEW)");
        }
        
    }

    public void InDanger()
    {
        GameManager.instance.GetComponent<GameManager>().deathtime += .03f;
    }

    public void Healing()
    {
        if (GameManager.instance.GetComponent<GameManager>().deathtime > 0)
        {
            GameManager.instance.GetComponent<GameManager>().deathtime -= .01f;
        }
    }

}











