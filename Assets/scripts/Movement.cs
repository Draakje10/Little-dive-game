using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{

    [FormerlySerializedAs("Player")] public GameObject player;
    private Camera _camera;
    Vector2 _mousePos;

    public float speed = 2;
    
    float _relX, _relY;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector2 objPos = GetObjPos();
        MovePlayer(objPos, GetRelMousePos());
        FollowCamera(objPos);
    }

    private Vector2 GetObjPos()
    {
        Vector2 objPos = player.transform.position;
        return objPos;
    }

    private Vector2 GetRelMousePos()
    {
        
        if (true)
        {
            _mousePos = InputType();
            _mousePos = _camera.ScreenToWorldPoint(_mousePos);
        }
        
        

        return _mousePos;
    }

    private void MovePlayer(Vector2 objPos, Vector2 mousePos)
    {
        player.transform.position = Vector2.Lerp(objPos, mousePos, 1 * Time.deltaTime);
        
        
        player.transform.up = mousePos - objPos;
    }

    private void FollowCamera(Vector2 objPos)
    {
        Vector3 newCameraPos = new Vector3(objPos.x, objPos.y, -10);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, newCameraPos,  1 * Time.deltaTime);
    }

    private Vector2 InputType()
    {
        Vector2 pos;
        if (Input.touchCount > 0)
             pos = Input.GetTouch(0).position;
        else
        {
             pos = Input.mousePosition;
        }

        return pos;
    }

    
    
    
    
}
