using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MImozgasAI : MonoBehaviour
{
    public AIEszrevesz1 Lat;

    public Transform Jatekospozicio;
    NavMeshAgent agent;
    Animator animator;

    float idozito = 0.0f;
    public float maxido = 1.0f;
    public float maxtavolsag = 1.5f;

    public float Tamadas_szunet;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Lat = GetComponent<AIEszrevesz1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lat.LatjukAJatekost == true)
        {
            idozito -= Time.deltaTime;
            if (idozito < 0.0f)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("AlapUtes") == false)
                {
                    if (Vector3.Distance(Jatekospozicio.position, this.transform.position) < maxtavolsag) //1.5
                    {
                        //animator.SetBool("AlapUtes", true);
                        animator.SetTrigger("UtesTrigger");
                        animator.SetBool("Fut", false);
                    }
                    else
                    {
                        if (animator.GetBool("Fut") == false)
                        {
                            animator.SetBool("Fut", true);
                        }
                        agent.destination = Jatekospozicio.position;
                    }
                }
            }
            //idozito = maxido;
        }
        else
        {
            if (animator.GetBool("Fut") == true)
            {
                animator.SetBool("Fut", false);
            }
            idozito = maxido;
        }
    }
}
