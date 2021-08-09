using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riversie
{
    public class TestClick : MonoBehaviour
    {

       //This is another way that i commented currently
        //void Update()
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        //Debug.Log("clicked");
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit,100))
        //        {
        //            Debug.Log("hit");
        //            if (hit.transform.CompareTag("Green"))
        //            {
        //                Debug.Log("Logged");
        //            }
        //        }
        //    }
        //}

        void OnMouseDown()
        {
            Destroy(gameObject);
        }
    }
}

