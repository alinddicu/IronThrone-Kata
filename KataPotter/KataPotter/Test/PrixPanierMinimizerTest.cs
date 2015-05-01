namespace IronThroneKata.Test
{
    using System.Collections.Generic;
    using Logique;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class PrixPanierMinimizerTest
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

        private PrixPanierMinimizer _minimizer;

        [TestInitialize]
        public void Initialize()
        {
            _minimizer = new PrixPanierMinimizer();
        }

        [TestMethod]
        [Ignore]
        public void Given11111And11100WhenMinimizeThenReturn11110And11110()
        {
            var groupe1 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe1.AddExemplaire(Volume.V1);
            groupe1.AddExemplaire(Volume.V2);
            groupe1.AddExemplaire(Volume.V3);
            groupe1.AddExemplaire(Volume.V4);
            groupe1.AddExemplaire(Volume.V5);

            var groupe2 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe2.AddExemplaire(Volume.V1);
            groupe2.AddExemplaire(Volume.V2);
            groupe2.AddExemplaire(Volume.V3);

            var panierEntree = new Panier();
            panierEntree.AddGroupeVolume(groupe1);
            panierEntree.AddGroupeVolume(groupe2);

            var groupe3 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe3.AddExemplaire(Volume.V1);
            groupe3.AddExemplaire(Volume.V2);
            groupe3.AddExemplaire(Volume.V3);
            groupe3.AddExemplaire(Volume.V4);

            var groupe4 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe4.AddExemplaire(Volume.V1);
            groupe4.AddExemplaire(Volume.V2);
            groupe4.AddExemplaire(Volume.V3);
            groupe4.AddExemplaire(Volume.V4);

            var panierSortie = new Panier();
            panierSortie.AddGroupeVolume(groupe3);
            panierSortie.AddGroupeVolume(groupe4);

            Check.That(_minimizer.Minimizer(panierEntree)).IsEqualTo(panierSortie);
        }
    }
}