using iQuest.GrandCircus.Utility;

namespace iQuest.GrandCircus.Animals
{
    internal class Bear : AnimalBase
    {

        public Bear(string name) : base(name)
        {

        }

        public override string SpeciesName
        {
            get => "bear";
        }

        public override string MakeNoise()
        {
            return "Grrrrrrrrrrrrrowl!";
        }

    }
}
