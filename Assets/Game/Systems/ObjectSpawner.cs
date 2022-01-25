using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Column;
    public Vector3 StartPosition = new Vector3(0, 0, 3.5f);
    public int InitialPillars = 5;
    public GameObject ColumnsHolder;

    float ColumnMin = 4;
    float ColumnMax = 8.5f;
    float ColumnSpacing = 5;
    Vector3 NextPosition;

    void Start()
    {
        NextPosition = StartPosition;
        for (int i = 0; i < InitialPillars; i++)
        {
            GameObject NewColumn = Instantiate(Column, ColumnsHolder.transform);
            float randomHeight = Random.Range(ColumnMin, ColumnMax);
            NewColumn.transform.position = NextPosition;
            NewColumn.transform.Translate(new Vector3(0, randomHeight, 0));

            NextPosition += new Vector3(0, 0, ColumnSpacing);
        }
    }

    public IEnumerator MovePillarUp(GameObject pillarToMove) 
    {
        yield return new WaitForSeconds(1.25f);
        float randomHeight = Random.Range(ColumnMin, ColumnMax);
        pillarToMove.transform.position = NextPosition;
        pillarToMove.transform.Translate(new Vector3(0, randomHeight, 0));
        NextPosition += new Vector3(0, 0, ColumnSpacing);
        yield return new WaitForSeconds(0.25f);
    }
}
