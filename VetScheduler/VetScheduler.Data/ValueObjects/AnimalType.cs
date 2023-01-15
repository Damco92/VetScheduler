using VetScheduler.VetScheduler.Shared;

namespace VetScheduler.Data.ValueObjects
{
    public class AnimalType : ValueObject
    {
        public string Species { get; }
        public string Breed { get; }

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
