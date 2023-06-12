using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //capturar o player
    public GameObject player;
    public int setCamera;
    private Vector3 offset;
    private Vector3 offset1 = new Vector3(0, 5, -6);
    private Vector3 offset2 = new Vector3(0, 1.7f, 1);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Muda o valor do offset de acordo com o valor de setCamera
        if(setCamera == 1)
        {
            offset = offset1;
        }
        if(setCamera == 2)
        {
            offset = offset2;
        }

        //Segue o player
        transform.position = player.transform.position + offset;
    }
}
