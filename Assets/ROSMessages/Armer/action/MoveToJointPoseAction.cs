using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.Armer
{
    public class MoveToJointPoseAction : Action<MoveToJointPoseActionGoal, MoveToJointPoseActionResult, MoveToJointPoseActionFeedback, MoveToJointPoseGoal, MoveToJointPoseResult, MoveToJointPoseFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToJointPoseAction";
        public override string RosMessageName => k_RosMessageName;


        public MoveToJointPoseAction() : base()
        {
            this.action_goal = new MoveToJointPoseActionGoal();
            this.action_result = new MoveToJointPoseActionResult();
            this.action_feedback = new MoveToJointPoseActionFeedback();
        }

        public static MoveToJointPoseAction Deserialize(MessageDeserializer deserializer) => new MoveToJointPoseAction(deserializer);

        MoveToJointPoseAction(MessageDeserializer deserializer)
        {
            this.action_goal = MoveToJointPoseActionGoal.Deserialize(deserializer);
            this.action_result = MoveToJointPoseActionResult.Deserialize(deserializer);
            this.action_feedback = MoveToJointPoseActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
