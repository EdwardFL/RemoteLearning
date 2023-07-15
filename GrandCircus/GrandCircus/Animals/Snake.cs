using iQuest.GrandCircus.Utility;

namespace iQuest.GrandCircus.Animals
{
    internal class Snake : AnimalBase
    {
        public Snake(string name) : base(name)
        {

        }

        public override string SpeciesName
        {
            get => "snake";
        }

        public override string MakeNoise()
        {
            return "Sssssssssssssssssssssss!";
        }
    }
}
