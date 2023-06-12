using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    //velocidade
    public float speed = 15.0f;
    public float turnSpeed = 10.0f;
    //controle dos eixos
    public float horizontalInput;
    public float verticalInput;
    //pegar a câmera
    public GameObject camera1;
    public GameObject camera2;
    private Camera cameraMain;
    private Camera cameraPilot;
    //Define o GamePlay
    private bool gameStart;
    private int points;
    private string objectCollision;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = camera1.GetComponent<Camera>();
        cameraPilot = camera2.GetComponent<Camera>();
        gameStart = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameStart)
        {
            //capturar o input do eixo Y
            horizontalInput = Input.GetAxis("Horizontal2");

            //capturar o input do eixo Z
            verticalInput = Input.GetAxis("Vertical2");

            //mover o carrinho para frente e para trás
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

            //Só gira se estiver em movimento
            if (verticalInput != 0)
            {
                //rotacionar o carrinho para fazer curva
                transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                cameraMain.enabled = !cameraMain.enabled;
                cameraPilot.enabled = !cameraPilot.enabled;
            }
        }
        
    }

    public void SetStartPlayer(bool start)
    {
        gameStart = start;
    }

    public int GetPointsPlayer()
    {
        return points;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;

        //Debug.Log(points);

        if (name == "Cube")
        {
            objectCollision = name;
            points++;
        }

    }

    public bool GetCollision()
    {
        if (objectCollision == "Cube")
        {
            return true;
        }

        return false;
    }
}
