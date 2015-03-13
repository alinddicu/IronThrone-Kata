namespace IronThroneKata.Logique
{
    using System.Collections.Generic;
    using System.Linq;

    public class Calculette
    {
        private const int PrixUnitaire = 8;

        private static readonly Dictionary<int, double> CoeffsReductions = new Dictionary<int, double>
        {
            {1, 1},
            {2, 0.95},
            {3, 0.90},
            {4, 0.80},
            {5, 0.75},
        };

        private readonly List<Volume> _exemplairesAchetes = new List<Volume>();
        private readonly Panier _panier = new Panier();

        public double Calculer(Dictionary<Volume, int> volumesAchetes)
        {
            ConstruireListeExemplaires(volumesAchetes);
            RemplirGroupesVolumes();
            var panierMinimise = MinimisePrixGroupesVolumes();

            return panierMinimise.CalculerPrix();
        }

        private Panier MinimisePrixGroupesVolumes()
        {
            return _panier;
        }

        private void RemplirGroupesVolumes()
        {
            while (_exemplairesAchetes.Any())
            {
                var groupeVolumes = CreerGroupeVolumes();

                EnleverExemplairesTraitesParGroupeVolumes(groupeVolumes);

                _panier.AddGroupeVolume(groupeVolumes);
            }
        }

        private void ConstruireListeExemplaires(Dictionary<Volume, int> panier)
        {
            foreach (var volume in panier.Keys)
            {
                for (var i = 0; i < panier[volume]; i++)
                {
                    _exemplairesAchetes.Add(volume);
                }
            }
        }

        private void EnleverExemplairesTraitesParGroupeVolumes(GroupeVolumes groupeVolumes)
        {
            foreach (var volume in groupeVolumes.GetVolumes())
            {
                _exemplairesAchetes.Remove(volume);
            }
        }

        private GroupeVolumes CreerGroupeVolumes()
        {
            var groupeVolumes = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            foreach (var exemplaire in _exemplairesAchetes)
            {
                groupeVolumes.AddExemplaire(exemplaire);
            }

            return groupeVolumes;
        }
    }
}