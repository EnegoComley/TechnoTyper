using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour {
    public ManagerController managerScript;
    public GameObject manager;
	// Use this for initialization
	void Awake () {
        if (managerScript == null)
        {
            managerScript = this;
            manager = gameObject;
            DontDestroyOnLoad(manager);
        }
        //That makes sure there is only one Manager and makes sure the manager always exists.
	}

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
