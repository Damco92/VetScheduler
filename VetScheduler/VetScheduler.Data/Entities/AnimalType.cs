using VetScheduler.VetScheduler.Shared;

namespace VetScheduler.Data.Entities
{
    public class AnimalType : ValueObject
    {
        public string Species { get; set; }
        public string Breed { get; set; }
        public AnimalType() { }

        public AnimalType(string species, string breed) 
        {
            Species = species;
            Breed = breed;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Species;
            yield return Breed;
        }
    }
}
