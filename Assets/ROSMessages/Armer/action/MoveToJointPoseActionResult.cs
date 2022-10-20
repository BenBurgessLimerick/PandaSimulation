using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToJointPoseActionResult : ActionResult<MoveToJointPoseResult>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToJointPoseActionResult";
        public override string RosMessageName => k_RosMessageName;


        public MoveToJointPoseActionResult() : base()
        {
            this.result = new MoveToJointPoseResult();
        }

        public MoveToJointPoseActionResult(HeaderMsg header, GoalStatusMsg status, MoveToJointPoseResult result) : base(header, status)
        {
            this.result = result;
        }
        public static MoveToJointPoseActionResult Deserialize(MessageDeserializer deserializer) => new MoveToJointPoseActionResult(deserializer);

        MoveToJointPoseActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = MoveToJointPoseResult.Deserialize(deserializer);
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
