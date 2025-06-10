using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreTableLoader
    {
        private GameScoreTableDeserializer tableDeserializer;

        public GameScoreTableLoader()
        {
            this.tableDeserializer = new GameScoreTableDeserializer();
        }

        public GameScoreTable LoadFrom(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The file on the given path does not exist!");
            }

            try
            {
                GameScoreTable gameScoreTable = this.tableDeserializer.Deserialize(path);

                return gameScoreTable;
            }
            catch (Exception ex)
            {
                throw new DeserializationErrorException(ex.Message);
            }
        }
    }
}
