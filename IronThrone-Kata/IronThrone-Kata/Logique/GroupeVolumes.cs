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

        public bool Contains(Volume exemplaire)
        {
            return _volumes.Contains(exemplaire);
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

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return this.Equals((GroupeVolumes)obj);
        }

        private bool Equals(GroupeVolumes other)
        {
            return Enumerable.SequenceEqual(this.GetVolumes(), other.GetVolumes());
        }

        public override string ToString()
        {
            var joinResult = string.Join(", ", this.GetVolumes().ToArray());

            return "{" + joinResult + "}";
        }
    }
}