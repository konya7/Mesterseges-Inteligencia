using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elet_HP : MonoBehaviour
{
    public float maxElet;
    public float JelenlegiElet;
    Test test;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<Test>();
        JelenlegiElet = maxElet;
    }

    public void SebzestSzenved(float amount)
    {
        JelenlegiElet -= amount;
        if (JelenlegiElet <= 0.0f)
        {
            Meghal();
        }
    }
    private void Meghal()
    {

    }

    // Update is called once per frame
    void Update()
    {
        test.AktivaljaRagdoll();
    }
}
