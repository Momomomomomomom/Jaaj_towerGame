using UnityEngine;
using System.Collections;
public class FlyCamera : MonoBehaviour
{
    
    /*Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.
    Converted to C# 27-02-13 - no credit wanted.
    Reformatted and cleaned by Ryan Breaker 23-6-18
    Original comment:
    Simple flycam I made, since I couldn't find any others made public.
    Made simple to use (drag and drop, done) for regular keyboard layout.
    Controls:
    WASD  : Directional movement
    Shift : Increase speed
    Space : Moves camera directly up per its local Y-axis*/
    

    public float mainSpeed = 5f;   // Regular speed
    public float shiftAdd = 12f;   // Amount to accelerate when shift is pressed
    //public float maxShift = 50f;  // Maximum speed when holding shift
    public float camSens = 0.05f;   // Mouse sensitivity
  

    private Vector3 lastMouse = new Vector3(0, 0, 0);  // kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;


    Vector3 limitBottom = new Vector3(-3f, 0, -3f);
    Vector3 limitTop = new Vector3(3f, 3f, 3f);



    void Update()
    {        
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        // Mouse camera angle done.  

        // Keyboard commands
        Vector3 p = GetBaseInput();
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p *= totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {*/
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p *= mainSpeed;
        //}

        p *= Time.deltaTime;

        transform.Translate(p);
    }

    // Returns the basic values, if it's 0 than it's not active.
    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();

        // Forwards
        if (Input.GetKey(KeyCode.W))
            p_Velocity += Vector3.forward; // new Vector3(0,0,1)

        // Backwards
        if (Input.GetKey(KeyCode.S))
            p_Velocity += Vector3.back;

        // Left
        if (Input.GetKey(KeyCode.A))
            p_Velocity += Vector3.left;

        // Right
        if (Input.GetKey(KeyCode.D))
            p_Velocity += Vector3.right;

        // Up
        if (Input.GetKey(KeyCode.Space))
            p_Velocity += Vector3.up;

        // Down
        if (Input.GetKey(KeyCode.LeftControl))
            p_Velocity += Vector3.down;

        return p_Velocity;
    }
}

/*public class FlyCamera : MonoBehaviour
{

    float movementForce = 500;
    public Rigidbody camera;
    private Vector3 lastMouse = new Vector3(0, 0, 0);

    float camSens = 0.5f;   // Mouse sensitivity


    private void FixedUpdate()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        // Mouse camera angle done.  
        
        //Forwards
        if (Input.GetKey(KeyCode.W))
            
            camera.AddForce(movementForce * Time.deltaTime, 0, 0);

        // Backwards
        if (Input.GetKey(KeyCode.S))            
            camera.AddForce(-movementForce * Time.deltaTime, 0, 0);

        // Left
        if (Input.GetKey(KeyCode.A))
            camera.AddForce(0, 0, movementForce * Time.deltaTime);

        // Right
        if (Input.GetKey(KeyCode.D))            
            camera.AddForce(0, 0, -movementForce * Time.deltaTime);

        // Up
        if (Input.GetKey(KeyCode.Space))
            camera.AddForce(0, movementForce * Time.deltaTime, 0);

        // Down
        if (Input.GetKey(KeyCode.LeftControl))
            camera.AddForce(0, -movementForce * Time.deltaTime, 0);
    }
}

*/









