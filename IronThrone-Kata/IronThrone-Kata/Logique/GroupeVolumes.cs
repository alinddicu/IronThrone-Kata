namespace IronThroneKata.Logique
{
    using System.Collections.Generic;

    public class GroupeVolumes
    {
        private readonly List<Volume> _volumes = new List<Volume>();

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

        public double GetPrix(int prixUnitaireVolume, Dictionary<int, double> coeffsReductions)
        {
            var quantiteVolumes = _volumes.Count;
            return quantiteVolumes * prixUnitaireVolume * coeffsReductions[quantiteVolumes];
        }
    }
}