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

        private readonly List<Volume> _listeExemplaires = new List<Volume>();
        private readonly List<GroupeVolumes> _groupesVolumes = new List<GroupeVolumes>();

        public double Calculer(Dictionary<Volume, int> panier)
        {
            ConstruireListeExemplaires(panier);
            RemplirGroupesVolumes();
            var groupesVolumes = MinimisePrixGroupesVolumes();

            return CalculerPrixPourGroupesVolumes(groupesVolumes);
        }

        private IEnumerable<GroupeVolumes> MinimisePrixGroupesVolumes()
        {
            return _groupesVolumes;
        }

        private void RemplirGroupesVolumes()
        {
            while (_listeExemplaires.Any())
            {
                var groupeVolumes = CreerGroupeVolumes();

                EnleverExemplairesTraitesParGroupeVolumes(groupeVolumes);

                _groupesVolumes.Add(groupeVolumes);
            }
        }

        private void ConstruireListeExemplaires(Dictionary<Volume, int> panier)
        {
            foreach (var volume in panier.Keys)
            {
                for (var i = 0; i < panier[volume]; i++)
                {
                    _listeExemplaires.Add(volume);
                }
            }
        }

        private static double CalculerPrixPourGroupesVolumes(IEnumerable<GroupeVolumes> groupesVolumes)
        {
            return groupesVolumes.Sum(groupeVolumes => groupeVolumes.GetPrix());
        }

        private void EnleverExemplairesTraitesParGroupeVolumes(GroupeVolumes groupeVolumes)
        {
            foreach (var volume in groupeVolumes.GetVolumes())
            {
                _listeExemplaires.Remove(volume);
            }
        }

        private GroupeVolumes CreerGroupeVolumes()
        {
            var groupeVolumes = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            foreach (var exemplaire in _listeExemplaires)
            {
                groupeVolumes.AddExemplaire(exemplaire);
            }

            return groupeVolumes;
        }
    }
}