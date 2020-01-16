/*========Hanniee Tran==========*
 * =========DIG4715C============*
 * =======10 Second Game========*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;


        //make the escape key as quit game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


}
