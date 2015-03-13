namespace IronThroneKata.Logique
{
    using System.Collections.Generic;
    using System.Linq;

    public class GroupeVolumes
    {
        private readonly List<Volume> _volumes = new List<Volume>();
        private readonly int _prixUnitaireVolume;
        private readonly Dictionary<int, double> _coeffsReductions;

        public GroupeVolumes(int prixUnitaireVolume, Dictionary<int, double> coeffsReductions)
        {
            _prixUnitaireVolume = prixUnitaireVolume;
            _coeffsReductions = coeffsReductions;
        }

        public void AddExemplaire(Volume exemplaire)
        {
            if (!_volumes.Contains(exemplaire))
            {
                _volumes.Add(exemplaire);
            }
        }

        public IEnumerable<Volume> GetVolumes()
        {
            return _volumes;
        }

        public double GetPrix()
        {
            var quantiteVolumes = _volumes.Count;
            return quantiteVolumes * _prixUnitaireVolume * _coeffsReductions[quantiteVolumes];
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return ReferenceEquals(obj, this) || Equals((GroupeVolumes)obj);
        }

        private bool Equals(GroupeVolumes other)
        {
            return GetVolumes().SequenceEqual(other.GetVolumes());
        }

        public override string ToString()
        {
            var joinResult = string.Join(", ", GetVolumes().ToArray());

            return "{" + joinResult + "}";
        }
    }
}