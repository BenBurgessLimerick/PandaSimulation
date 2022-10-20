using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToPoseActionGoal : ActionGoal<MoveToPoseGoal>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToPoseActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public MoveToPoseActionGoal() : base()
        {
            this.goal = new MoveToPoseGoal();
        }

        public MoveToPoseActionGoal(HeaderMsg header, GoalIDMsg goal_id, MoveToPoseGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static MoveToPoseActionGoal Deserialize(MessageDeserializer deserializer) => new MoveToPoseActionGoal(deserializer);

        MoveToPoseActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = MoveToPoseGoal.Deserialize(deserializer);
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
