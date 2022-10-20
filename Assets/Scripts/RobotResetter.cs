using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RobotResetter : MonoBehaviour
{
    public static RobotResetter Instance;
    public UnityEvent resetEvent = new UnityEvent();

    // Start is called before the first frame update
    void Awake()
    {
        if (RobotResetter.Instance == null) {
			RobotResetter.Instance = this;
		} 
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R)) {
            resetEvent.Invoke();
        }
    }

}
