using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToJointPoseActionGoal : ActionGoal<MoveToJointPoseGoal>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToJointPoseActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public MoveToJointPoseActionGoal() : base()
        {
            this.goal = new MoveToJointPoseGoal();
        }

        public MoveToJointPoseActionGoal(HeaderMsg header, GoalIDMsg goal_id, MoveToJointPoseGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static MoveToJointPoseActionGoal Deserialize(MessageDeserializer deserializer) => new MoveToJointPoseActionGoal(deserializer);

        MoveToJointPoseActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = MoveToJointPoseGoal.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.goal_id);
            serializer.Write(this.goal);
        }


#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
