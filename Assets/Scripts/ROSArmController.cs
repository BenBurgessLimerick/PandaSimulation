using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class ROSArmController : ROSRobotController {


    [Header("Robot")]
    public ArmController armController;


    [Header("Settings")]
    
    public string jointVelArrayCmdTopic = "/joint_group_velocity_controller/command";
    public string jointStateTopic = "joint_states";

    public bool useDirectJointVel = false;
    public string jointVelCmdTopic = "/arm/joint/velocity";

    [Header("Debug")]
    public RosMessageTypes.Sensor.JointStateMsg jointStateMsg;

    // Start is called before the first frame update
    void Start()
    {
        
        if (armController == null) {
            armController = this.GetComponent<ArmController>();
        }

        base.Start();

    }

    public override void VisualiserInit() {
        armController.controlMode = ArmController.ControlMode.Position;
        ros.Subscribe<RosMessageTypes.Sensor.JointStateMsg>(jointStateTopic, ReceivedJointState);
    }

    public override void SimulatorInit() {
        armController.controlMode = ArmController.ControlMode.Velocity;
        int nJoints = armController.GetNJoints();
        jointStateMsg.position = new double[nJoints];
        jointStateMsg.name = new string[nJoints];
        jointStateMsg.effort = new double[nJoints];
        jointStateMsg.velocity = new double[nJoints];

        for(int i = 0; i < nJoints; ++i) {
            jointStateMsg.name[i] = armController.joints[i].name;
        }
        ros.RegisterPublisher<RosMessageTypes.Sensor.JointStateMsg>(jointStateTopic);
        if (useDirectJointVel) {
            ros.Subscribe<RosMessageTypes.Armer.JointVelocityMsg>(jointVelCmdTopic, ReceivedJointVelCmd);
        } else {
            ros.Subscribe<RosMessageTypes.Std.Float64MultiArrayMsg>(jointVelArrayCmdTopic, ReceivedJointVelArrayCmd);
        }
    }


    public override void DoSimulatorPublishing() {
        for (int i = 0; i < jointStateMsg.position.Length; ++i) {
            if (!armController.joints[i].prismatic) {
                jointStateMsg.position[i] = armController.jointAngles[i] / 180.0 * Mathf.PI;
                jointStateMsg.velocity[i] = armController.jointVels[i] / 180.0 * Mathf.PI;
            } else {
                jointStateMsg.position[i] = armController.jointAngles[i];
                jointStateMsg.velocity[i] = armController.jointVels[i];
            }
        }
        // jointStateMsg.position[7] = frankieController.GetGripWidth() / 2;
        
        
        ros.Publish(jointStateTopic, jointStateMsg);
        
    }

    void ReceivedJointState(RosMessageTypes.Sensor.JointStateMsg jointStateMsg) {
        for (int i = 0; i < armController.GetNJoints(); ++i) {
            armController.SetJointAngle(
                i, 
                (float) jointStateMsg.position[i]
            );
            
            armController.SetJointVel(
                i, 
                (float) jointStateMsg.velocity[i]
            );
        }
        
    }

    void ReceivedJointVelCmd(RosMessageTypes.Armer.JointVelocityMsg jointVelMsg) {
        for (int i = 0; i < armController.GetNJoints(); ++i) {
            armController.SetJointVel(
                i, 
                (float) jointVelMsg.joints[i]
            );
        }
    }

    void ReceivedJointVelArrayCmd(RosMessageTypes.Std.Float64MultiArrayMsg jointVelMsg) {
        for (int i = 0; i < armController.GetNJoints(); ++i) {
            armController.SetJointVel(
                i, 
                (float) jointVelMsg.data[i]
            );
        }
    }
}
