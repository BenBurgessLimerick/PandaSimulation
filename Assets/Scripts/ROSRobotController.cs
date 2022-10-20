using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class ROSRobotController : MonoBehaviour
{
    public enum RobotMode {
        Visualiser = 0, 
        Simulator = 1
    }

    public RobotMode robotMode = RobotMode.Simulator;

    public ROSConnection ros;
    public float publishFreq = 50;
    float lastPubTime = 0;

    // Start is called before the first frame update
    public void Start() {
        ros = ROSConnection.GetOrCreateInstance();

        switch(robotMode) {
            case RobotMode.Simulator:
                SimulatorInit();
                break;
            case RobotMode.Visualiser:
                VisualiserInit();
                break;
        }
    }

    void Update() {
        if (robotMode == RobotMode.Simulator) {
            if (Time.realtimeSinceStartup > lastPubTime + 1/publishFreq) {
                lastPubTime = Time.realtimeSinceStartup;

                switch(robotMode) {
                    case RobotMode.Simulator:
                        DoSimulatorPublishing();
                        break;
                    case RobotMode.Visualiser:
                        DoVisualiserPublishing();
                        break;
                }
               
            }
        }
    }

    public virtual void DoSimulatorPublishing() {

    }

    public virtual void DoVisualiserPublishing() {

    }

    public virtual void SimulatorInit() {
    
    }

    public virtual void VisualiserInit() {
    
    }
}
