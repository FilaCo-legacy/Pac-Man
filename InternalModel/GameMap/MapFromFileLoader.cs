using System;
using System.IO;
using GameServer.GameMap;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    
    
    public class MapFromFileLoader:IMapLoader
    {
        private const string defaultMapPath = @"DefaultMap.pcmap";
        
        public string FilePath { get; set; }
        
        public MapFromFileLoader(string filePath = defaultMapPath)
        {
            FilePath = filePath;
        }
        
        public MapObjCode[,] Load()
        {
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
                    }
                }

                return matrixObjCodes;
            }
        }
    }
}