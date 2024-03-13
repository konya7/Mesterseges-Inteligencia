using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiEletCsik1 : MonoBehaviour
{
    public Transform celpont;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(celpont.position + offset);
    }
}
