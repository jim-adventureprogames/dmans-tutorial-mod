using DungeonMans;

namespace modmans_mods
{
	public partial class ScriptFunctions
	{
		public static bool TestAmazing()
		{
			dmUtilities.AddStringToLog("^lAMAZING!^7");
			
			return true;
		}

		public static string GetTitleForModmansRank(int rank)
		{
			return rank switch
			{
				1 => "Mod Maybemans",
				2 => "Mod Dude",
				3 => "Elite Modlord",
				_ => "Jabroni"
			};
		}
	}
}
