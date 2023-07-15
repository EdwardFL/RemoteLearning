using iQuest.GrandCircus.Utility;

namespace iQuest.GrandCircus.Animals
{
    internal class Lion : AnimalBase
    {
        public Lion(string name) : base(name)
        {

        }

        public override string SpeciesName
        {
            get => "lion";
        }

        public override string MakeNoise()
        {
            return "Roaaaaaar!";
        }
    }
}
