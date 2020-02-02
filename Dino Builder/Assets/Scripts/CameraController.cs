using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        // WASDQE Panning
    public float minPanSpeed = 0.1f;    // Starting panning speed
    public float maxPanSpeed = 1000f;   // Max panning speed
    public float panTimeConstant = 20f; // Time to reach max panning speed
    public float maxZoom;
    public float minZoom;

        // Mouse right-down rotation
    public float rotateSpeed = 10; // mouse down rotation speed about x and y axes
    public float zoomSpeed = 2;    // zoom speed

    float panT = 0;
    float panSpeed = 10;
    Vector3 panTranslation;
    bool wKeyDown = false;
    bool aKeyDown = false;
    bool sKeyDown = false;
    bool dKeyDown = false;
    bool qKeyDown = false;
    bool eKeyDown = false;

  Vector3 lastMousePosition;
  new Camera camera;

  void Start()
  {
      camera = GetComponent<Camera>();
  }

  void Update()
  {
        
      //
      // WASDQE Panning

      // read key inputs
      wKeyDown = Input.GetKey(KeyCode.W);
      aKeyDown = Input.GetKey(KeyCode.A);
      sKeyDown = Input.GetKey(KeyCode.S);
      dKeyDown = Input.GetKey(KeyCode.D);
      qKeyDown = Input.GetKey(KeyCode.Q);
      eKeyDown = Input.GetKey(KeyCode.E);

      // determine panTranslation
      panTranslation = Vector3.zero;
      if (dKeyDown && !aKeyDown)
          panTranslation += Vector3.right * Time.deltaTime * panSpeed;
      else if (aKeyDown && !dKeyDown)
          panTranslation += Vector3.left * Time.deltaTime * panSpeed;

      if (wKeyDown && !sKeyDown)
          panTranslation += Vector3.forward * Time.deltaTime * panSpeed;
      else if (sKeyDown && !wKeyDown)
          panTranslation += Vector3.back * Time.deltaTime * panSpeed;

      if (qKeyDown && !eKeyDown)
          panTranslation += Vector3.down * Time.deltaTime * panSpeed;
      else if (eKeyDown && !qKeyDown)
          panTranslation += Vector3.up * Time.deltaTime * panSpeed;
      transform.Translate(panTranslation, Space.Self);

      // Update panSpeed
      if (wKeyDown || aKeyDown || sKeyDown ||
          dKeyDown || qKeyDown || eKeyDown)
      {
          panT += Time.deltaTime / panTimeConstant;
          panSpeed = Mathf.Lerp(minPanSpeed, maxPanSpeed, panT * panT);
      }
      else
      {
          panT = 0;
          panSpeed = minPanSpeed;
      }

      //
      // Mouse Rotation
      if (Input.GetMouseButton(1))
      {
          // if the game window is separate from the editor window and the editor
          // window is active then you go to right-click on the game window the
          // rotation jumps if  we don't ignore the mouseDelta for that frame.
          Vector3 mouseDelta;
          if (lastMousePosition.x >= 0 &&
              lastMousePosition.y >= 0 &&
              lastMousePosition.x <= Screen.width &&
              lastMousePosition.y <= Screen.height)
              mouseDelta = Input.mousePosition - lastMousePosition;
          else
              mouseDelta = Vector3.zero;

          var rotation = Vector3.up * Time.deltaTime * rotateSpeed * mouseDelta.x;
          rotation += Vector3.left * Time.deltaTime * rotateSpeed * mouseDelta.y;
          transform.Rotate(rotation, Space.Self);

          // Make sure z rotation stays locked
          rotation = transform.rotation.eulerAngles;
          rotation.z = 0;
          transform.rotation = Quaternion.Euler(rotation);
      }

      lastMousePosition = Input.mousePosition;

      //
      // Mouse Zoom
       // camera.fieldOfView -= Input.mouseScrollDelta.y * zoomSpeed;
  }
}
//public class CameraController : MonoBehaviour
//{
//    public float panSpeed = 30f;
//    public float panBorderThickness = 10f;
//    private Vector2 ZoomRange = new Vector2(-10, 10);
//    public float currentZoom = 0;
//    public float zoomSpeed = 0;
//    public float zoomRotation = 1;
//    private bool stuck = false;
//    private Vector3 initPos;
//    private Vector3 initRot;
//    private void Start()
//    {
//        initPos = transform.position;
//        initRot = transform.eulerAngles;
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//            stuck = !stuck;
//        if (stuck)
//            return;
//        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
//        {
//            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
//        }
//        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
//        {
//            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
//        }
//        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
//        {
//            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
//        }
//        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
//        {
//            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
//        }

//        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * zoomSpeed;
//        currentZoom = Mathf.Clamp(currentZoom, ZoomRange.x, ZoomRange.y);
//        float y = transform.position.y - (initPos.y + currentZoom) * 0.1f;
//        float x = transform.eulerAngles.x - (initRot.x + currentZoom * zoomRotation) * 0.1f;
//        transform.Translate(new Vector3(0, y,0));
//        transform.Rotate(x, 0, 0);
//    }
//}
