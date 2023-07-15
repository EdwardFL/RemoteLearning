using iQuest.GrandCircus.Utility;

namespace iQuest.GrandCircus.Animals
{
    internal class Elephant : AnimalBase
    {
        public Elephant(string name) : base(name)
        {

        }

        public override string SpeciesName
        {
            get => "elephant";
        }

        public override string MakeNoise()
        {
            return "Truuuuuuuuuuuuuuu";
        }
    }
}
