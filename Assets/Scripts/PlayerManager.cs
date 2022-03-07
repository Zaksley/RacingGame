using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PlayerManager : MonoBehaviour
{
    private GameManage manager; 

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Road"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            Destroy(gameObject);
            manager.ReloadSceneDelay(manager.RespawnTimer); 
        }
    }
}
