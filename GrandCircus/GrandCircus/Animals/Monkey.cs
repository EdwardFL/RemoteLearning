using iQuest.GrandCircus.Utility;

namespace iQuest.GrandCircus.Animals
{
    internal class Monkey : AnimalBase
    {
        public Monkey(string name) : base(name)
        {

        }

        public override string SpeciesName
        {
            get => "monkey";
        }

        public override string MakeNoise()
        {
            return "Wraaa wraaa wraaa!";
        }
    }
}
