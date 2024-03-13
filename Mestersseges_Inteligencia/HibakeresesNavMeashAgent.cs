using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HibakeresesNavMeashAgent : MonoBehaviour
{
    public bool sebesség;
    public bool kivant_sebesseg;
    public bool palya;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void OnDrawGizmos()
    {
        if (sebesség)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }
        if (kivant_sebesseg)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }
        if (palya && agent.path != null)
        {
            Gizmos.color = Color.black;
            var agentpalya = agent.path;
            Vector3 előzetes_sarok = transform.position;
            foreach (var sarok in agentpalya.corners)
            {
                Gizmos.DrawLine(előzetes_sarok, sarok);
                Gizmos.DrawSphere(sarok, 0.3f);
                előzetes_sarok = sarok;
            }
        }
    }
}
