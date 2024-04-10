using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject instance;
    public int health = 3;
    public float deathtime = 0f;
    public float DieT =2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deathtime >= DieT)
        {
            health -= 1;
            GameObject.FindWithTag("Player").GetComponent<RespawnScript>().Die();
        }
        
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
              
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
