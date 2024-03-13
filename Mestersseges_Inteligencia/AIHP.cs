using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AIHP : MonoBehaviour
{
    public float maxelet;
    public float jelenlegielet;
    public string ellenfel;
    Animator Animator;
    public GameObject HPImage;
    public MImozgasAI mozgas;
    public NavMeshAgent nav;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        jelenlegielet = maxelet;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ellenfel))
        {
            jelenlegielet = jelenlegielet - 10;
            HPImage.transform.localScale = new Vector3(jelenlegielet / maxelet, HPImage.transform.localScale.y, HPImage.transform.localScale.z); 
        }
        if (jelenlegielet <= 0)
        {
            Animator.SetBool("Meghal", true);
            mozgas.enabled = false;
            nav.enabled = false;
            Destroy(UI);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
