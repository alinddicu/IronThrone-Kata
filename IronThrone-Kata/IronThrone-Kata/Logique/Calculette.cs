namespace IronThroneKata.Logique
{
    using System;
    using System.Collections.Generic;

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
            MaximiserPrixGroupesVolumes();

            return CalculerPrixPourGroupesVolumes();
        }

        private void MaximiserPrixGroupesVolumes()
        {
            //throw new NotImplementedException();
        }

        private void RemplirGroupesVolumes()
        {
            while (_listeExemplaires.Count != 0)
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

        private double CalculerPrixPourGroupesVolumes()
        {
            var prix = 0.0;
            foreach (var groupeVolumes in _groupesVolumes)
            {
                prix += groupeVolumes.GetPrix(PrixUnitaire, CoeffsReductions);
            }

            return prix;
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
            var groupeVolumes = new GroupeVolumes();
            foreach (var exemplaire in _listeExemplaires)
            {
                groupeVolumes.AddExemplaire(exemplaire);
            }

            return groupeVolumes;
        }
    }
}