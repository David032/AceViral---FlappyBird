using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GameController controller = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
        controller.IncreaseScore();
        StartCoroutine(controller.gameObject.GetComponent<ObjectSpawner>()
            .MovePillarUp(gameObject));
    }
}
