using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToNamedPoseActionResult : ActionResult<MoveToNamedPoseResult>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToNamedPoseActionResult";
        public override string RosMessageName => k_RosMessageName;


        public MoveToNamedPoseActionResult() : base()
        {
            this.result = new MoveToNamedPoseResult();
        }

        public MoveToNamedPoseActionResult(HeaderMsg header, GoalStatusMsg status, MoveToNamedPoseResult result) : base(header, status)
        {
            this.result = result;
        }
        public static MoveToNamedPoseActionResult Deserialize(MessageDeserializer deserializer) => new MoveToNamedPoseActionResult(deserializer);

        MoveToNamedPoseActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = MoveToNamedPoseResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.result);
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
