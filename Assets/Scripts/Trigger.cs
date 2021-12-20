using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Color m_oldColor = Color.white;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player"))
        {
            Renderer render = GetComponent<Renderer>();

            m_oldColor = render.material.color;
            render.material.color = Color.green;
            Debug.Log("collide");
        }      
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag.Equals("Player"))
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = m_oldColor;
            Debug.Log("Exit Collide");
        }
    }
}
