using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManage : MonoBehaviour
{
    public float RespawnTimer = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene"); 
        }
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadSceneDelay(float seconds)
    {
        Invoke("ReloadScene", seconds); 
    }
}
