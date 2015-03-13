namespace IronThroneKata.Test
{
    using System.Collections.Generic;
    using Logique;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class PanierTest
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

        [TestMethod]
        public void CheckPanierEquality()
        {
            var groupe1 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe1.AddExemplaire(Volume.V1);
            groupe1.AddExemplaire(Volume.V2);
            groupe1.AddExemplaire(Volume.V3);

            var groupe2 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe2.AddExemplaire(Volume.V1);
            groupe2.AddExemplaire(Volume.V2);
            groupe2.AddExemplaire(Volume.V3);

            var panier1 = new Panier();
            panier1.AddGroupeVolume(groupe1);
            panier1.AddGroupeVolume(groupe2);

            var groupe3 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe3.AddExemplaire(Volume.V1);
            groupe3.AddExemplaire(Volume.V2);
            groupe3.AddExemplaire(Volume.V3);

            var groupe4 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe4.AddExemplaire(Volume.V1);
            groupe4.AddExemplaire(Volume.V2);
            groupe4.AddExemplaire(Volume.V3);

            var panier2 = new Panier();
            panier2.AddGroupeVolume(groupe3);
            panier2.AddGroupeVolume(groupe4);

            Check.That(panier1).IsEqualTo(panier2);
        }

        [TestMethod]
        public void CheckPanierNotEquality()
        {
            var groupe1 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe1.AddExemplaire(Volume.V1);

            var groupe2 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe2.AddExemplaire(Volume.V2);

            var panier1 = new Panier();
            panier1.AddGroupeVolume(groupe1);
            panier1.AddGroupeVolume(groupe2);

            var groupe3 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            
            groupe3.AddExemplaire(Volume.V3);

            var groupe4 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe4.AddExemplaire(Volume.V1);

            var panier2 = new Panier();
            panier2.AddGroupeVolume(groupe3);
            panier2.AddGroupeVolume(groupe4);

            Check.That(panier1).Not.IsEqualTo(panier2);
        }
    }
}
