using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    PlayerControls Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (Player.isDead)
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShiftBackground());
        }
    }

    IEnumerator ShiftBackground() 
    {
        yield return new WaitForSeconds(1.25f);
        transform.Translate(Vector3.left * 150);
        yield return new WaitForSeconds(0.25f);
    }


}
