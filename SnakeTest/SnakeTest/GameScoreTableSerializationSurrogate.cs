using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreTableSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            GameScoreTable gameScoreTable = (GameScoreTable)obj;
            info.AddValue("gameScores", gameScoreTable.GameScores);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            GameScoreTable gameScoreTable = (GameScoreTable)obj;

            gameScoreTable.GameScores = (List<GameScore>)info.GetValue("gameScores", typeof(List<GameScore>));

            return gameScoreTable;
        }
    }
}
