﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerControls>().isDead = true;
        GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>().EndMenu.SetActive(true);
        
    }
}
