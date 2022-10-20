using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {
    [System.Serializable]
    public struct ArmJoint {
        public string name;
        public Transform joint;
        public bool prismatic;
    }

    public enum ControlMode {
        Position, Velocity
    }
    public ArmJoint[] joints;
    public ControlMode controlMode = ControlMode.Velocity;

    [Header("Debug")]
    public float[] jointAngles;
    public float[] jointVels;

    public float[] initJointAngles;

    public bool reset;

    // Start is called before the first frame update
    void Start()
    {
        // ScrapeJointsFromChildren();

        jointAngles = new float[joints.Length];
        initJointAngles = new float[joints.Length];
        jointVels = new float[joints.Length];
        for (int i = 0; i < joints.Length; i++) {
            // float newValue = joints[i].joint.localEulerAngles.x;

            // This way should prevent euler ambiguity
            float newValue;
            Vector3 axis  = Vector3.zero;
            joints[i].joint.localRotation.ToAngleAxis(out newValue, out axis);
            newValue *= axis.x;

            if (!joints[i].prismatic) {
                if (newValue > 180f) {
                    newValue -= 360f;
                } else if(newValue < -180f) {
                    newValue += 360f;
                }
            }
            jointAngles[i] =  newValue;
            initJointAngles[i] = jointAngles[i];
        }
        RobotResetter.Instance.resetEvent.AddListener(ResetArm);
    }

    public int GetNJoints() {
        return joints.Length;
    }
    void Update() {
        if (reset) {
            reset = false;
            ResetArm();
        }
    }

    public void ScrapeJointsFromChildren() {
        List<ArmJoint> joints = new List<ArmJoint>();
        AddChildJoints(this.transform, joints);
        this.joints = joints.ToArray();

    }

    void AddChildJoints(Transform t, List<ArmJoint> joints) {
        // Debug.Log(t.gameObject.name);
        // string[] splitName = t.gameObject.name.Split("_");
        // if (splitName.Length >= 2) {
        //     if (splitName[splitName.Length - 2] == "joint") {
        //         Debug.Log(t.gameObject.name);
        //         ArmJoint joint = new ArmJoint();
        //         joint.joint = t;
        //         joints.Add(joint);
        //     }   
        // }

        string[] splitName = t.gameObject.name.Split("_");
        if (splitName.Length >= 2) {
            if (splitName[splitName.Length - 1].Contains("joint")) {
                Debug.Log(t.gameObject.name);
                ArmJoint joint = new ArmJoint();
                joint.joint = t;
                joint.name = t.gameObject.name;
                joints.Add(joint);
            }
            
        }
        

        foreach (Transform child in t) {
            AddChildJoints(child, joints);
        }
    }

    public void ResetArm() {
        for (int i =0; i < joints.Length; i++) {
            jointAngles[i] = initJointAngles[i];
            jointVels[i] = 0;
        }
    }

    public void SetJointAngles(float[] newJointAngles) {
        jointAngles = newJointAngles;
    }

    public void SetJointAngle(int jointIndex, float jointAngle, bool radians=true) {
    
        if (radians && !joints[jointIndex].prismatic) {
            jointAngle = jointAngle * Mathf.Rad2Deg;
        }
        jointAngles[jointIndex] = jointAngle;
    }


    public void SetJointVels(float[] newJointVels) {
        jointVels = newJointVels;
    }

    public void SetJointVel(int jointIndex, float jointVel, bool radians=true) {
        
        if (radians && !joints[jointIndex].prismatic) {
            jointVel = jointVel *  Mathf.Rad2Deg;
        }
        jointVels[jointIndex] = jointVel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controlMode == ControlMode.Velocity) {
            for (int i =0 ; i < joints.Length; i++) {
                jointAngles[i] += jointVels[i] * Time.fixedDeltaTime;
            }
        }
        FlushJointAngles(); 
    }

    void FlushJointAngles() {
        for(int i =0 ; i < joints.Length; i++) {
            if (joints[i].prismatic) {
                Debug.LogError("Not implemented prismatic joint");
            } else {
                joints[i].joint.localEulerAngles = jointAngles[i] * Vector3.right; 
            }
            
        }
    }
}
