using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor
{
    internal class Trooper : DK2Utils_Shared.Trooper
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
        public Trooper(string name, string trooperClass) : base(name, trooperClass)
        {
            Name = name;
            TrooperClass = trooperClass;
        }
    }
}
