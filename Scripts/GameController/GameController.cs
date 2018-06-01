using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]

    private GameObject[] constantGameObjects;

	void Start ()
    {

        for (int i = 0; i < constantGameObjects.Length; i++)
        {
            Object.DontDestroyOnLoad(constantGameObjects[i]);
        }
     

     }
	
	
}
