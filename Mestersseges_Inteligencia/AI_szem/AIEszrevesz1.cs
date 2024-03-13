using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEszrevesz1 : MonoBehaviour
{
    public bool LatjukAJatekost = false;
    public float sugar;
    [Range(0, 360)] //korlátozzuk a sugárnak adható szamot 0-360 ig
    public float sarok;
    public GameObject JatekosBiro;
    public LayerMask CelMask;
    public LayerMask AkadalyMask;
    private void Start()
    {
        JatekosBiro = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            TeruletNezetEllenorzes();
        }
    }
    private void TeruletNezetEllenorzes()
    {
        Collider[] TavolsagEllenorzes = Physics.OverlapSphere(transform.position, sugar, CelMask);
        if (TavolsagEllenorzes.Length != 0)
        {
            Transform cel = TavolsagEllenorzes[0].transform;
            Vector3 IranyACelponthoz = (cel.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, IranyACelponthoz) < sarok / 2)
            {
                float TavolsagACelponthoz = Vector3.Distance(transform.position, cel.position);
                if (!Physics.Raycast(transform.position, IranyACelponthoz, TavolsagACelponthoz, AkadalyMask))
                {
                    LatjukAJatekost = true;
                }
                else
                {
                    LatjukAJatekost = false;
                }
            }
            else
            {
                LatjukAJatekost = false;
            }
        }
        else if (LatjukAJatekost)
        {
            LatjukAJatekost = false;
        }
    }
}
