using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public string next_scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(next_scene);
        //Application.LoadLevel(next_scene);
    }
}
