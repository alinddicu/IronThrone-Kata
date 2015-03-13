namespace IronThroneKata.Test
{
    using System.Collections.Generic;
    using Logique;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CalculetteTest
    {
        private Calculette _calculette;

        [TestInitialize]
        public void Initialize()
        {
            _calculette = new Calculette();
        }

        [TestMethod]
        public void Given10000WhenCalculerPrixThenReturn8()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 1},
                {Volume.V2, 0},
                {Volume.V3, 0},
                {Volume.V4, 0},
                {Volume.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(8);
        }

        [TestMethod]
        public void Given11000WhenCalculerPrixThenReturn15v20()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 1},
                {Volume.V2, 1},
                {Volume.V3, 0},
                {Volume.V4, 0},
                {Volume.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(15.20);
        }

        [TestMethod]
        public void Given11100WhenCalculerPrixThenReturn21v60()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 1},
                {Volume.V2, 1},
                {Volume.V3, 1},
                {Volume.V4, 0},
                {Volume.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(21.60);
        }

        [TestMethod]
        public void Given11110WhenCalculerPrixThenReturn25v60()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 1},
                {Volume.V2, 1},
                {Volume.V3, 1},
                {Volume.V4, 1},
                {Volume.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(25.60);
        }

        [TestMethod]
        public void Given11111WhenCalculerPrixThenReturn30()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 1},
                {Volume.V2, 1},
                {Volume.V3, 1},
                {Volume.V4, 1},
                {Volume.V5, 1}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(30.00);
        }

        [TestMethod]
        public void Given20000WhenCalculerPrixThenReturn16()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 2},
                {Volume.V2, 0},
                {Volume.V3, 0},
                {Volume.V4, 0},
                {Volume.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(16.00);
        }

        [TestMethod]
        public void Given20000WhenCalculerPrixThenReturn23v20()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 2},
                {Volume.V2, 1},
                {Volume.V3, 0},
                {Volume.V4, 0},
                {Volume.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(23.20);
        }

        [TestMethod]
        [Ignore]
        public void Given22211WhenCalculerPrixThenReturn51v20()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 2},
                {Volume.V2, 2},
                {Volume.V3, 2},
                {Volume.V4, 1},
                {Volume.V5, 1}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(51.20);
        }

        [TestMethod]
        [Ignore]
        public void Given44422WhenCalculerPrixThenReturn102v40()
        {
            var panier = new Dictionary<Volume, int>
            {
                {Volume.V1, 4},
                {Volume.V2, 4},
                {Volume.V3, 4},
                {Volume.V4, 2},
                {Volume.V5, 2}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(102.40);
        }
    }
}