using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaObjetos : MonoBehaviour
{
    float speed = 5.0f;
    private void Start()
    {
        speed = GameManager.instance.GetFallSpeed();
        Destroy(this.gameObject,7f);
    }
    void Update()
    {
        speed = GameManager.instance.GetFallSpeed();
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
       
        
    }
}
