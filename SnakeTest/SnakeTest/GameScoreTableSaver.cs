using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreTableSaver
    {
        private GameScoreTableSerializer tableSerializer;

        public GameScoreTableSaver()
        {
            this.tableSerializer = new GameScoreTableSerializer();
        }

        public void Save(string path, GameScoreTable gameScoreTable)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The file on the given path does not exist!");
            }

            try
            {
               this.tableSerializer.Serialize(path, gameScoreTable);
            }
            catch (Exception ex)
            {
                throw new SerializationErrorException(ex.Message);
            }
        }
    }
}
