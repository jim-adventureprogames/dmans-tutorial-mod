using DungeonMans;

namespace modmans_mods
{
	public partial class ScriptFunctions
	{
		public static bool DoCoolDmansStuff()
		{
			dmUtilities.AddStringToLog("Rollin' 1d666: " + dmUtilities.RollDice("1d666"));
			
			var theGame = dmUtilities.theGame;
			
			var hero = theGame.dungeonMans;
			var heroLoc = theGame.dungeonMans.Location;
			float delay = 0.0f;
			
            for(int t=0; t < 10; t++)
            {
                var prize = theGame.SpawnItemFromArchetype("modmans_weapon_1h_axe_t6");
                var wt = dmUtilities.GetSuitableNearbyTileForLootToss(heroLoc, "1d11-6");
                theGame.PrepareDelayedTreasureEvent( prize, heroLoc, wt.Location, delay);
                delay += 0.1f;
            }
			
			return true;
		}
		
		public static bool somanybites(dmActor invoker, LocValue startLoc, LocValue endLoc)
		{
			dmUtilities.AddStringToLog( invoker.Name + " is doing so many bites!");
			
			return true;
		}
		
		public static bool only_move_left(dmMonster targetMonster)
		{
			var level = dmUtilities.theGame.theCurrentLevel;
			WorldTile destTile = level.GetTile( targetMonster.Location + new LocValue(-1,0));
			targetMonster.goalLocation = destTile.Location;

			//be calm.
			targetMonster.goalObject = null;
			targetMonster.desiredLocation.Invalidate();
			targetMonster.bWantToFire = false;
			targetMonster.rangedAttackTarget = null;
			targetMonster.PushbackCooldowns(2);
			
			targetMonster.PlotPathTowardGoalLocation(dmUtilities.theGame);
			return true;
		}
		
		public static bool yell_about_being_hit(dmCreature attacker, dmCreature defender, dmAttackRecord payload)
		{
			var theGame = dmUtilities.theGame;
			
			theGame.AddStringToLog("^3" + defender.Name + "^7 yells ^1ow^7 you fucker that was some " + payload.damageToDefender[0].ToString() + " damage!");
			
			return true;
			
		}
	}
}