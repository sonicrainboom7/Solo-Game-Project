using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsPage : MonoBehaviour {
    public Button Back;
    // Use this for initialization
    void Start () {
        Button back = Back.GetComponent<Button>();
        back.onClick.AddListener(GoBack);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void GoBack()
    {
        SceneManager.LoadScene("Title");
    }
}
