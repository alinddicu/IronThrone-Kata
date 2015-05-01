namespace IronThroneKata.Test
{
    using System.Collections.Generic;
    using Logique;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class GroupeVolumesTest
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
        public void CheckGroupeVolumesEquality()
        {
            var groupe1 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe1.AddExemplaire(Volume.V1);
            groupe1.AddExemplaire(Volume.V2);
            groupe1.AddExemplaire(Volume.V3);

            var groupe2 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe2.AddExemplaire(Volume.V1);
            groupe2.AddExemplaire(Volume.V2);
            groupe2.AddExemplaire(Volume.V3);

            Check.That(Equals(groupe1, groupe2)).IsTrue();
        }

        [TestMethod]
        public void CheckGroupeVolumesNotEquality()
        {
            var groupe1 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe1.AddExemplaire(Volume.V1);
            groupe1.AddExemplaire(Volume.V3);

            var groupe2 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe2.AddExemplaire(Volume.V1);
            groupe2.AddExemplaire(Volume.V2);
            groupe2.AddExemplaire(Volume.V3);

            Check.That(Equals(groupe1, groupe2)).IsFalse();
        }

        [TestMethod]
        public void GivenGroupeVolumesWithV1V2WhenToStringThenReturnCorrectValue()
        {
            var groupe1 = new GroupeVolumes(PrixUnitaire, CoeffsReductions);
            groupe1.AddExemplaire(Volume.V1);
            groupe1.AddExemplaire(Volume.V2);
            groupe1.AddExemplaire(Volume.V3);

            Check.That(groupe1.ToString()).Equals("{V1, V2, V3}");
        }
    }
}