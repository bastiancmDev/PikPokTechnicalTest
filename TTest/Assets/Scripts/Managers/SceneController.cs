using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    private string _currenScene;
    public string CurrenScene { get { return _currenScene; } }
    public void LoadNewScene(string sceneName)
    {
        _currenScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
