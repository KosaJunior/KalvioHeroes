using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastLight2D : MonoBehaviour {

    public double distToLight;
    public Vector2 xyLight;
    GameObject[] obj = new GameObject[2];
    Vector2 objXY;
    float fullLit = 1.5f, 
          fullBlack = 3.5f;
    float r;


    // Use this for initialization
    void Start () {
        this.xyLight = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        obj[0] = GameObject.Find("Argo");
        obj[1] = GameObject.Find("Argo/głowa");
    }

    // Update is called once per frame
    void Update()
    {
        //Get XY position from Argo
        objXY = new Vector2(obj[0].GetComponent<Transform>().position.x, obj[0].GetComponent<Transform>().position.y);
        distToLight = Vector2.Distance(this.xyLight, objXY);
        r = (float)(distToLight - fullBlack) / (fullLit - fullBlack);

        //Apply color change for objects
        for (int i = 0; i < 2; i++)
        {
            obj[i].GetComponent<SpriteRenderer>().color = new Color(r, r, r, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag.Contains("Sh"))
        {
            GetComponent<CastLight2D>().enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag.Contains("Sh"))
        {
            GetComponent<CastLight2D>().enabled = false;
        }
    }

}
