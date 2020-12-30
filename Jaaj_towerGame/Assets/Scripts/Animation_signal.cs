using System.Collections;
using UnityEngine;

public class Animation_signal : MonoBehaviour
{

    public GameObject parent;
    
    Vector3 minSize = new Vector3(1f, 1f, 1f);
    Vector3 maxSize = new Vector3(35f, 35f, 35f);
    float changeInSize = 0.5f;
    float offset = 5f;


    Renderer thisrend;
    float transitionRate = 5f;
    Color strong = Color.green;
    Color average = Color.yellow;
    Color weak = Color.red;

    private void Start()
    {
        float a =  transform.localScale.x;
        minSize *= a;
        maxSize *= a;
        offset *= a;


        thisrend = GetComponent<Renderer>();
        strong.a = 0.5f;
        average.a = 0.5f;
        weak.a = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < maxSize.x / 3)
        {
            thisrend.material.SetColor("_Color", Color.Lerp(thisrend.material.color, strong, Time.deltaTime * transitionRate));
        } else if (transform.localScale.x < 2* maxSize.x / 3)
        {
            thisrend.material.SetColor("_Color", Color.Lerp(thisrend.material.color, average, Time.deltaTime * transitionRate));               
        } else 
        {
            thisrend.material.SetColor("_Color", Color.Lerp(thisrend.material.color, weak, Time.deltaTime * transitionRate));
        }


        transform.localScale = Vector3.Lerp(transform.localScale, maxSize, changeInSize * Time.deltaTime);
        if (transform.localScale.x > (maxSize.x - offset))
        {
            transform.localScale = minSize;
        }

    }
   

}

