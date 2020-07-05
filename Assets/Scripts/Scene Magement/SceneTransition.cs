using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneTransition : MonoBehaviour
{

    public GameObject enterText;
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        enterText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
