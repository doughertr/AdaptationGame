using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	void Update ()
    {
        if (Input.anyKeyDown)
            GameManager.Instance.StartGame();
	}
}
