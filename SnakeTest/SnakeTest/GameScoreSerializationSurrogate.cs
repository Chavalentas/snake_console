using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            GameScore gameScore = (GameScore)obj;
            info.AddValue("pointScore", gameScore.PointCount);
            info.AddValue("timestamp", gameScore.Timestamp);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            GameScore gameScore = (GameScore)obj;
            gameScore.PointCount = info.GetInt32("pointScore");
            gameScore.Timestamp = info.GetDateTime("timestamp");

            return gameScore;
        }
    }
}
