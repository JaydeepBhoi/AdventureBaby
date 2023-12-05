using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{

    public GameObject PlayerObj,backBoundry;
    public float xMin;
    public float xMax = 2000;
    public float yMin;
    public float yMax;
    public float Move;
    public float x,xy;
    public Vector2 p;
    public bool pBool=false;
    public int count;
    public static Camera_Move instance = null;
    Camera cam;
    // Start is called before the first frame update

    //  public static Camera_Move;
    //public float offset;
    //public float offsetSmoothings;
    //private Vector3 playerPosition;
    void Start()
    {
        instance = this;
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        cam = GetComponent<Camera>();

        p = cam.ViewportToWorldPoint(new Vector2(0, 0));
        backBoundry.transform.position = p;

       // Debug.Log("#################Camera Position################" + backBoundry.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
      
        p = cam.ViewportToWorldPoint(new Vector2(0, 0));
        backBoundry.transform.position = p;
    }

    private void LateUpdate()
    {
        //playerPosition = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);

        //if (Player.transform.lossyScale.x > 0f)
        //{
        //    playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        //}
        //else
        //{
        //    playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        //}

        // transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothings * Time.deltaTime);
        //Move = Input.GetAxis("Horizontal");
        //if (Move < 0.0f)
        //{

        //}
        //else if (Move > 0.0f)
        //{
        //     x = Mathf.Clamp(Player.transform.position.x+2, transform.position.x, xMax);


        //}

        x = Mathf.Clamp(PlayerObj.transform.position.x + 3.5f, transform.position.x, xMax);

        float y = Mathf.Clamp(PlayerObj.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);


        //p = cam.ViewportToWorldPoint(new Vector2(0, 0));


        //if (p.x > PlayerObj.transform.position.x)
        //{

        //    //Vector3 scale = transform.localScale;
        //    //scale.x = -1f;
        //    ///transform.localScale = scale;

        //    Debug.Log("Jd get Camera " + p.x);

        //}
    }


}
