using UnityEngine;

public class FocusOnCity : MonoBehaviour
{

    public GameObject targetObj;
    public float speed = 10;
    bool startLooking = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            startLooking = true;
        }

        if (startLooking)
        {
            Cursor.lockState = CursorLockMode.Locked;
            var targetRotation = Quaternion.LookRotation(targetObj.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            if (targetRotation == transform.rotation)
            {
                startLooking = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}
