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
    public class GameScoreTableSerializer
    {
        public void Serialize(string path, GameScoreTable gameScoreTable)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The file at the given path could not be found!");
            }

            if (gameScoreTable == null)
            {
                throw new ArgumentNullException("The value of the game score table cannot be null!");
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                SurrogateSelector surrogateSelector = new SurrogateSelector();
                surrogateSelector.AddSurrogate(typeof(GameScore), new StreamingContext(StreamingContextStates.All), new GameScoreSerializationSurrogate());
                surrogateSelector.AddSurrogate(typeof(GameScoreTable), new StreamingContext(StreamingContextStates.All), new GameScoreTableSerializationSurrogate());

                IFormatter formatter = new BinaryFormatter();
                formatter.SurrogateSelector = surrogateSelector;

                formatter.Serialize(fileStream, gameScoreTable);
                fileStream.Flush();
                fileStream.Close();
            }
        }
    }
}
