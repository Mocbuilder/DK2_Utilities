namespace DK2Utils_Shared
{
    public class Filepaths
    {
        public static string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"/KillHouseGames/DoorKickers2");
        public static string roster = Path.Combine(appdata + $"/roster.xml");
        public static string defaultWorkshop = "C:/Program Files (x86)/Steam/steamapps/workshop/content/1239080";
    }

    

    public class Squad
    {
        string Unit { get; set; }
        string Name { get; set; }
        string ID { get; set; }
        int Battlehonors { get; set; }

        public Squad(string unit, string name, string id, int battlehonors)
        {
            Unit = unit;
            Name = name;
            ID = id;
            Battlehonors = battlehonors;
        }
    }

    public class Trooper
    {
        string Name { get; set; }
        string TrooperClass { get; set; }
        int MarksmanshipPercent { get; set; }
        int AssaultShootingPercent { get; set; }
        int FieldSkillsPercent { get; set; }
        int totalMissionsWon { get; set; }
        int Xp { get; set; }
        int Promoted { get; set; }
        int Mission3Star { get; set; }
        int BulletsFired { get; set; }
        int Bulletshit { get; set; }
        int Kills { get; set; }
        int DistanceWalkedMeters { get; set; }
        int CompletedHealthy { get; set; }
        int Healthy { get; set; }
        int StartingHealth { get; set; }
        public Trooper(string name, string trooperClass)
        {
            Name = name;
            TrooperClass = trooperClass;
        }
    }
}
