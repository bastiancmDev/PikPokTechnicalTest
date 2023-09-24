using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public  void MoveTo(Vector3 targetPos)
    {
       StartCoroutine(MovePlayer(targetPos));
    }

    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePlayer(Vector3 pos)
    {
        while (Vector3.Distance(transform.position, pos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, 100);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
