namespace IronThrone_Kata
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class UnitTest1
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
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 1},
                {Volumes.V2, 0},
                {Volumes.V3, 0},
                {Volumes.V4, 0},
                {Volumes.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(8);
        }

        [TestMethod]
        public void Given11000WhenCalculerPrixThenReturn15v20()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 1},
                {Volumes.V2, 1},
                {Volumes.V3, 0},
                {Volumes.V4, 0},
                {Volumes.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(15.20);
        }

        [TestMethod]
        public void Given11100WhenCalculerPrixThenReturn21v60()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 1},
                {Volumes.V2, 1},
                {Volumes.V3, 1},
                {Volumes.V4, 0},
                {Volumes.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(21.60);
        }

        [TestMethod]
        public void Given11110WhenCalculerPrixThenReturn25v60()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 1},
                {Volumes.V2, 1},
                {Volumes.V3, 1},
                {Volumes.V4, 1},
                {Volumes.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(25.60);
        }

        [TestMethod]
        public void Given11111WhenCalculerPrixThenReturn30()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 1},
                {Volumes.V2, 1},
                {Volumes.V3, 1},
                {Volumes.V4, 1},
                {Volumes.V5, 1}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(30.00);
        }

        [TestMethod]
        public void Given20000WhenCalculerPrixThenReturn16()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 2},
                {Volumes.V2, 0},
                {Volumes.V3, 0},
                {Volumes.V4, 0},
                {Volumes.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(16.00);
        }

        [TestMethod]
        public void Given20000WhenCalculerPrixThenReturn23v20()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 2},
                {Volumes.V2, 1},
                {Volumes.V3, 0},
                {Volumes.V4, 0},
                {Volumes.V5, 0}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(23.20);
        }

        [TestMethod]
        [Ignore]
        public void Given22211WhenCalculerPrixThenReturn51v20()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 2},
                {Volumes.V2, 2},
                {Volumes.V3, 2},
                {Volumes.V4, 1},
                {Volumes.V5, 1}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(51.20);
        }

        public enum Volumes
        {
            V1,
            V2,
            V3,
            V4,
            V5
        }

        public class Calculette
        {
            private const int PrixUnitaire = 8;

            private readonly List<Volumes> _listeExemplaires = new List<Volumes>();

            private readonly List<List<Volumes>> _groupesVolumes = new List<List<Volumes>>();

            private static readonly Dictionary<int, double> CoeffReduction = new Dictionary<int, double>
            {
                {1, 1},
                {2, 0.95},
                {3, 0.90},
                {4, 0.80},
                {5, 0.75},
            };

            private void DeduireListeExemplaires(Dictionary<Volumes, int> panier)
            {
                foreach (var volume in panier.Keys)
                {
                    for (var i = 0; i < panier[volume]; i++)
                    {
                        _listeExemplaires.Add(volume);
                    }
                }
            }

            public double Calculer(Dictionary<Volumes, int> panier)
            {
                DeduireListeExemplaires(panier);
                while (_listeExemplaires.Count != 0)
                {
                    var groupeVolumes = new List<Volumes>();
                    foreach (var exemplaire in _listeExemplaires)
                    {
                        if (!groupeVolumes.Contains(exemplaire))
                        {
                            groupeVolumes.Add(exemplaire);
                        }
                    }

                    foreach (var volume in groupeVolumes)
                    {
                        _listeExemplaires.Remove(volume);
                    }

                    _groupesVolumes.Add(groupeVolumes);
                }

                var prix = 0.0;
                foreach (var groupeVolumes in _groupesVolumes)
                {
                    var nombreVolumes = groupeVolumes.Count;
                    prix += nombreVolumes * PrixUnitaire * CoeffReduction[nombreVolumes];
                }

                return prix;
            }
        }
    }
}