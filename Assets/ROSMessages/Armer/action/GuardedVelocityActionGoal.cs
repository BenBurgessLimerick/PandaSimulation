using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class GuardedVelocityActionGoal : ActionGoal<GuardedVelocityGoal>
    {
        public const string k_RosMessageName = "armer_msgs/GuardedVelocityActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public GuardedVelocityActionGoal() : base()
        {
            this.goal = new GuardedVelocityGoal();
        }

        public GuardedVelocityActionGoal(HeaderMsg header, GoalIDMsg goal_id, GuardedVelocityGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static GuardedVelocityActionGoal Deserialize(MessageDeserializer deserializer) => new GuardedVelocityActionGoal(deserializer);

        GuardedVelocityActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = GuardedVelocityGoal.Deserialize(deserializer);
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
