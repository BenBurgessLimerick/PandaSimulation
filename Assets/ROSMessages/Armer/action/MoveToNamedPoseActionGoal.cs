using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToNamedPoseActionGoal : ActionGoal<MoveToNamedPoseGoal>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToNamedPoseActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public MoveToNamedPoseActionGoal() : base()
        {
            this.goal = new MoveToNamedPoseGoal();
        }

        public MoveToNamedPoseActionGoal(HeaderMsg header, GoalIDMsg goal_id, MoveToNamedPoseGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static MoveToNamedPoseActionGoal Deserialize(MessageDeserializer deserializer) => new MoveToNamedPoseActionGoal(deserializer);

        MoveToNamedPoseActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = MoveToNamedPoseGoal.Deserialize(deserializer);
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
