using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    PlayerControls Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.isDead)
        {
            transform.Translate(Vector3.forward / 10);
        }
    }
}
