using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public GameObject Player;
    public Camera camera;

    [SerializeField] private float Speed = 1;
    
    float relX, relY;

    void Update()
    {
        MovePlayer(getObjPos(), getRelMousePos());
    }

    private Vector2 getObjPos()
    {
        Vector2 ObjPos = Player.transform.position;
        return ObjPos;
    }

    private Vector2 getRelMousePos()
    {
        Vector2 MousePos = Input.mousePosition;
        MousePos = camera.ScreenToWorldPoint(MousePos);

        return MousePos;
    }

    void MovePlayer(Vector2 ObjPos, Vector2 MousePos)
    {
        Player.transform.position = Vector2.Lerp(ObjPos, MousePos, 1 * Time.deltaTime);
        Player.transform.up = MousePos - ObjPos;
    } 
}
