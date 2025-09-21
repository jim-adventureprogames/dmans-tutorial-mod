using DungeonMans;
using Microsoft.Xna.Framework;

namespace modmans_mods
{
    public class DungeonTypeA : dmDungeonLevel_StructuredEmpty
    {
        public override void GenerateWorld(int WorldGenSeed, dmGame _theGame, string strAreaName, int _floorNum,
            string strAreaData, int iBaseThreat)
        {
            DoBaseGenerateWorldFunctionsForDungeon(WorldGenSeed, _theGame, strAreaName, _floorNum, strAreaData,
                iBaseThreat);
            floorNum = 1;
            GenerateClearDungeonBaseMap(dunData.terrainTileTypes[(int)TerrainType.TT_WALL]);

            for (int x = 20; x < 25; x++)
                for (int y = 20; y < 25; y++)
                    ChangeTileToArchetype(x, y, TerrainType.TT_FLOOR, false);

            startLocation = new LocValue(22, 22);

          
            //place a portal home at the start
            var homePortal = (dmGateway)theGame.SpawnActorFromArchetype("orange_portal");
            homePortal.bSendToOverworld = true;
            homePortal.Location = startLocation;
            homePortal.levelName = "Overworld";
            homePortal.direction = GatewayDirection.up;
            homePortal.strHandmadeDestinationName = "The Overworld";

            AddObjectToTile(homePortal, homePortal.Location.X, homePortal.Location.Y);

            var bounds = new Rectangle(23, 21, 1, 5);
            var triggerVolume = theGame.CreateTriggerVolume(bounds, "testolio_trigger");
            triggerVolume.bActive = true;

            FinalizeDownStairwellCount();
            GenerateRenderTiles();
            CreateOokRenderDataForTiles();
        }
    }
}