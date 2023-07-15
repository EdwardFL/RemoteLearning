using iQuest.GrandCircus.Animals;
using iQuest.GrandCircus.Presentation;
using iQuest.GrandCircus.Utility;
using System.Collections.Generic;

namespace iQuest.GrandCircus.CircusModel
{
    internal class Circus
    {

        readonly List<IAnimal> animalList = new List<IAnimal>();
        private readonly Arena arena = new Arena();


        public Circus(Arena arena)
        {
            animalList.Add(new Bear("Alfred"));
            animalList.Add(new Bear("Baver"));
            animalList.Add(new Elephant("Manny"));
            animalList.Add(new Lion("Wisdom"));
            animalList.Add(new Monkey("Lexy"));
            animalList.Add(new Snake("Asmodeus"));
        }

        public void Perform()
        {
            foreach (var animal in animalList)
            {
                arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
                arena.DisplayAnimalPerformance(animal.MakeNoise());
            }
        }
    }
}