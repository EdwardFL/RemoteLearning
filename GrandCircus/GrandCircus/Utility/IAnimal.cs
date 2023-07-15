namespace iQuest.GrandCircus.Utility
{
    interface IAnimal
    {

        abstract string Name { get; }
        abstract string SpeciesName { get; }

        string MakeNoise();

    }
}



