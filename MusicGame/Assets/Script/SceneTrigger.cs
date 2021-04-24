using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Button button = other.gameObject.GetComponent<Button>();

        if (button != null) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && other.tag == "Up")
            {
                Debug.Log("Enter Up.");
                //Destroy(other);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && other.tag == "Down")
            {
                Debug.Log("Enter Down.");
                //Destroy(other);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && other.tag == "Left")
            {
                Debug.Log("Enter Left.");
                //Destroy(other);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && other.tag == "Right")
            {
                Debug.Log("Enter Right.");
                //Destroy(other);
            }
        }

    }
}
