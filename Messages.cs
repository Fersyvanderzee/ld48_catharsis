using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Messages : MonoBehaviour {
    
    public Text startGameText;
    
    private string[] messages = {
        "If you can read this. The procedure worked.",
        "Congratulations.",
        "You are a man made intelligence uploaded in the patients brain.",
        "The patient suffers from depression.",
        "Your task is to locate and eliminate destructive thoughts.",
        "These thoughts are causing harm to the patient.",
        "Destroy them."
    };



    void Start() {
        StartCoroutine(WaitToPrint(5f));
    }

    void Update() {
        if(Input.GetKeyDown("q")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerator WaitToPrint(float waitTime) { 
        for(int i = 0; i < messages.Length; i++)
        {
            startGameText.text = messages[i];
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}

