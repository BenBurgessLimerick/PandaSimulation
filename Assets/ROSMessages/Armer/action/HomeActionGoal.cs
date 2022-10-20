using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class HomeActionGoal : ActionGoal<HomeGoal>
    {
        public const string k_RosMessageName = "armer_msgs/HomeActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public HomeActionGoal() : base()
        {
            this.goal = new HomeGoal();
        }

        public HomeActionGoal(HeaderMsg header, GoalIDMsg goal_id, HomeGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static HomeActionGoal Deserialize(MessageDeserializer deserializer) => new HomeActionGoal(deserializer);

        HomeActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = HomeGoal.Deserialize(deserializer);
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
