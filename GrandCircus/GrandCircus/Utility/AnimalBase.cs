namespace iQuest.GrandCircus.Utility
{
    abstract class AnimalBase : IAnimal
    {

        public string Name { get; private set; }

        public abstract string SpeciesName { get; }

        public AnimalBase(string name)
        {
            this.Name = name;
        }

        public abstract string MakeNoise();
    }
}
