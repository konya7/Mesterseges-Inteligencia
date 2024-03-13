using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AIEszrevesz1))]

public class AISZemEditor : Editor
{
    private void OnSceneGUI()
    {
        AIEszrevesz1 kovet = (AIEszrevesz1)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(kovet.transform.position, Vector3.up, Vector3.forward, 360, kovet.sugar);
        Vector3 LatSarok01 = Irany_Szog(kovet.transform.eulerAngles.y, -kovet.sarok / 2);
        Vector3 LatSarok02 = Irany_Szog(kovet.transform.eulerAngles.y, kovet.sarok / 2);
        Handles.color = Color.yellow;
        Handles.DrawLine(kovet.transform.position, kovet.transform.position + LatSarok01 * kovet.sugar);
        Handles.DrawLine(kovet.transform.position, kovet.transform.position + LatSarok02 * kovet.sugar);

        if (kovet.LatjukAJatekost)
        {
            Handles.color = Color.green;
            Handles.DrawLine(kovet.transform.position, kovet.JatekosBiro.transform.position);
        }
    }
    private Vector3 Irany_Szog(float eulerY, float sarok_fok)
    {
        sarok_fok += eulerY;
        return new Vector3(Mathf.Sin(sarok_fok * Mathf.Deg2Rad), 0, Mathf.Cos(sarok_fok * Mathf.Deg2Rad));
    }
}
