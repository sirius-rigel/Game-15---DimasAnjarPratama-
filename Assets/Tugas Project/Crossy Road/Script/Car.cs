using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    
    int extend;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (this.transform.position.x < - (extend + 1) || this.transform.position.x> extend + 1)
            Destroy(this.gameObject);
    }

    public void SetUp(int extend)
    {
        this.extend = extend;
    }
}
