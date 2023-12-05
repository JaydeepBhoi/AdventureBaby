using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepUpdown : MonoBehaviour
{
    public GameObject step1,step2,step3;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(22, 13);
        Physics2D.IgnoreLayerCollision(22, 11);
        if (step1.transform.localPosition.y > -10f)
        {
            step1.transform.Translate(Vector3.down * (Time.deltaTime* speed));
        }
        else
        {
            step1.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 8f, gameObject.transform.localPosition.z);
        }

        if (step2.transform.localPosition.y > -10f)
        {
            step2.transform.Translate(Vector3.down * (Time.deltaTime* speed));
        }
        else
        {
            step2.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 8f, gameObject.transform.localPosition.z);
        }

        if (step3.transform.localPosition.y > -10f)
        {
            step3.transform.Translate(Vector3.down * (Time.deltaTime* speed));
        }
        else
        {
            step3.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 8f, gameObject.transform.localPosition.z);
        }
    }
}
