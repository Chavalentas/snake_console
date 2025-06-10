using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreTableDeserializer
    {
        public GameScoreTable Deserialize(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The file at the given path could not be found!");
            }

            GameScoreTable gameScoreTable;

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                SurrogateSelector surrogateSelector = new SurrogateSelector();
                surrogateSelector.AddSurrogate(typeof(GameScore), new StreamingContext(StreamingContextStates.All), new GameScoreSerializationSurrogate());
                surrogateSelector.AddSurrogate(typeof(GameScoreTable), new StreamingContext(StreamingContextStates.All), new GameScoreTableSerializationSurrogate());

                IFormatter formatter = new BinaryFormatter();
                formatter.SurrogateSelector = surrogateSelector;

                fileStream.Seek(0, SeekOrigin.Begin);
                gameScoreTable = (GameScoreTable)formatter.Deserialize(fileStream);

                fileStream.Flush();
                fileStream.Close();
            }

            return gameScoreTable;
        }
    }
}
