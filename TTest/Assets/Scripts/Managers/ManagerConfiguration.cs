using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerConfiguration 
{
    // Start is called before the first frame update

    #region Singleton
    private static ManagerConfiguration _instance;

    private ManagerConfiguration()
    {
        Init();
    }

    public void Init()
    {
      
    }

    public static ManagerConfiguration Instance
    {
        get
        {
            if (_instance == null) _instance = new ManagerConfiguration();
            return _instance;
        }
    }

    public void DebugInstance()
    {
        Debug.Log(Instance.ToString());
    }

    #endregion

}
