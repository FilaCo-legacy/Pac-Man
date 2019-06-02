using System;
using System.IO;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class MapFromFileLoader:IMapLoader
    {
        public string FilePath { get; set; }
        
        public MapFromFileLoader(string filePath)
        {
            FilePath = filePath;
        }
        
        public Map Load()
        {
            var foodCount = 0;
            var energizerCount = 0;
            
            using (var strReader = new StreamReader(FilePath))
            {
                var inpArr = strReader.ReadToEnd().Split("\n");

                var rowsCount = inpArr.Length-1;
                var colsCount = inpArr[0].Split(' ').Length;

                var matrixObjCodes = new MapObjCode[rowsCount, colsCount];

                for (var row = 0; row < rowsCount; ++row)
                {
                    var curRowArr = inpArr[row].Split(' ');

                    for (var col = 0; col < colsCount; ++col)
                    {
                        matrixObjCodes[row, col] = (MapObjCode)int.Parse(curRowArr[col]);
                        
                        if (matrixObjCodes[row, col] == MapObjCode.Food)
                            ++foodCount;
                        if (matrixObjCodes[row, col] == MapObjCode.Energizer)
                            ++energizerCount;
                    }
                }
                
                return new Map(matrixObjCodes, foodCount, energizerCount);
            }
        }
    }
}