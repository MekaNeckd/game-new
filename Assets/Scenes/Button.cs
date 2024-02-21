using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public bool lightOff = false;
    public float timer;
    public GameObject target;

    public void Pressed ()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<ButtonInt>().nearbutton = false;
        lightOff = true;
            Debug.Log("Light Off");
            StartCoroutine("TimerOff");
 
    }
    IEnumerator TimerOff()
    {
        yield return new WaitForSeconds (timer);
        lightOff = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ButtonInt>().nearbutton = true;
        Debug.Log("Light On");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOff == true)
        {
            target.SetActive(false);
        }
        else
        {
            target.SetActive(true);
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene("GameMain");
    }
}
