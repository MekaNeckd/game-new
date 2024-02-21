using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInt : MonoBehaviour
{
    public bool lightOff = false;
    public float timer;
    public bool nearbutton;
    private GameObject but;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Debug.Log("nearbutton");
        if (collision.gameObject.CompareTag("Button"))
        {
            nearbutton = true;
            but = collision.gameObject;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearbutton = false;
    }
    IEnumerator TimerOff()
    {
        yield return new WaitForSeconds(timer);
        lightOff = false;
        Debug.Log("Light On");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& nearbutton == true)
        {
            //gameObject.CompareTag("light");
            but.gameObject.GetComponent<Button>().Pressed();
            Debug.Log("E");
            //StartCoroutine("TimerOff");
        }
    }
}
