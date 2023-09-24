using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Coroutine _moveCurrentCoroutineReference;
    private bool canMove = false;
    public  void MoveTo(Vector3 targetPos)
    {
        if (_moveCurrentCoroutineReference != null)
        {
            StopCoroutine(_moveCurrentCoroutineReference);
        }
        _moveCurrentCoroutineReference = StartCoroutine(MovePlayer(targetPos));
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
            float step = 0.1f;
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
            yield return new WaitForSeconds(0.01f);
        }       
            
    }
}
