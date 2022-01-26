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
    float ColumnHeightDeviation = 1.5f;
    Vector3 NextPosition;
    float LastColumnHeight;

    void Start()
    {
        NextPosition = StartPosition;
        float randomHeight;
        for (int i = 0; i < InitialPillars; i++)
        {
            GameObject NewColumn = Instantiate(Column, ColumnsHolder.transform);
            if (i == 0)
            {
                randomHeight = Random.Range(ColumnMin, ColumnMax);
            }
            else
            {
                randomHeight = 
                    GenerateConstrainedRandomPosition(LastColumnHeight);
            }
            LastColumnHeight = randomHeight;
            NewColumn.transform.position = NextPosition;
            NewColumn.transform.Translate(new Vector3(0, randomHeight, 0));

            NextPosition += new Vector3(0, 0, ColumnSpacing);
        }
    }

    public IEnumerator MovePillarUp(GameObject pillarToMove) 
    {
        yield return new WaitForSeconds(1.25f);
        float randomHeight = 
            GenerateConstrainedRandomPosition(LastColumnHeight);
        pillarToMove.transform.position = NextPosition;
        pillarToMove.transform.Translate(new Vector3(0, randomHeight, 0));
        NextPosition += new Vector3(0, 0, ColumnSpacing);
        yield return new WaitForSeconds(0.25f);
    }

    float GenerateConstrainedRandomPosition(float lastHeight) 
    {
        float randomHeight = Random.Range(lastHeight-ColumnHeightDeviation/2,
            lastHeight + ColumnHeightDeviation/2);
        return randomHeight;
    }
}
