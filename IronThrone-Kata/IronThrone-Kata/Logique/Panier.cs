namespace IronThroneKata.Logique
{
    using System.Collections.Generic;
    using System.Linq;

    public class Panier
    {
        private readonly List<GroupeVolumes> _groupeVolumeses = new List<GroupeVolumes>();

        public void AddGroupeVolume(GroupeVolumes groupeVolumes)
        {
            _groupeVolumeses.Add(groupeVolumes);
        }

        public double CalculerPrix()
        {
            return _groupeVolumeses.Sum(groupeVolumes => groupeVolumes.GetPrix());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return ReferenceEquals(obj, this) || Equals((Panier)obj);
        }

        private IEnumerable<GroupeVolumes> GetGroupesVolumes()
        {
            return _groupeVolumeses;
        }

        private bool Equals(Panier other)
        {
            return GetGroupesVolumes().SequenceEqual(other.GetGroupesVolumes());
        }
    }
}
