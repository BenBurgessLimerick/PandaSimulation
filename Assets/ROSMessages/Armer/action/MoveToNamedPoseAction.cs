using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.Armer
{
    public class MoveToNamedPoseAction : Action<MoveToNamedPoseActionGoal, MoveToNamedPoseActionResult, MoveToNamedPoseActionFeedback, MoveToNamedPoseGoal, MoveToNamedPoseResult, MoveToNamedPoseFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToNamedPoseAction";
        public override string RosMessageName => k_RosMessageName;


        public MoveToNamedPoseAction() : base()
        {
            this.action_goal = new MoveToNamedPoseActionGoal();
            this.action_result = new MoveToNamedPoseActionResult();
            this.action_feedback = new MoveToNamedPoseActionFeedback();
        }

        public static MoveToNamedPoseAction Deserialize(MessageDeserializer deserializer) => new MoveToNamedPoseAction(deserializer);

        MoveToNamedPoseAction(MessageDeserializer deserializer)
        {
            this.action_goal = MoveToNamedPoseActionGoal.Deserialize(deserializer);
            this.action_result = MoveToNamedPoseActionResult.Deserialize(deserializer);
            this.action_feedback = MoveToNamedPoseActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
