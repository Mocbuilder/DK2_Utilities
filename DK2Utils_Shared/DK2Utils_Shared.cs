namespace DK2Utils_Shared
{
    public class Filepaths
    {
        public static string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"/KillHouseGames/DoorKickers2");
        public static string roster = Path.Combine(appdata + $"/roster.xml");

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
}
