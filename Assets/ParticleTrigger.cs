using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    //public Rigidbody2D rb2d;
    //public Animator anim;
    // Start is called before the first frame update
    public RespawnScript rs;
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out var insideData);

        if (numInside > 0 && rs.dying == false)
        {
            //Debug.Log("Inside");
            rs.InDanger();
        }
    }
}
