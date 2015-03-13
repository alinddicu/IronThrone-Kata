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

        [TestMethod]
        [Ignore]
        public void Given44422WhenCalculerPrixThenReturn102v40()
        {
            var panier = new Dictionary<Volumes, int>
            {
                {Volumes.V1, 4},
                {Volumes.V2, 4},
                {Volumes.V3, 4},
                {Volumes.V4, 2},
                {Volumes.V5, 2}
            };

            Check.That(_calculette.Calculer(panier)).IsEqualTo(102.40);
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

            private static readonly Dictionary<int, double> CoeffReduction = new Dictionary<int, double>
            {
                {1, 1},
                {2, 0.95},
                {3, 0.90},
                {4, 0.80},
                {5, 0.75},
            };

            private readonly List<Volumes> _listeExemplaires = new List<Volumes>();
            private readonly List<List<Volumes>> _groupesVolumes = new List<List<Volumes>>();

            public double Calculer(Dictionary<Volumes, int> panier)
            {
                ConstruireListeExemplaires(panier);
                RemplirGroupesVolumes();

                return CalculerPrixPourGroupesVolumes();
            }

            private void RemplirGroupesVolumes()
            {
                while (_listeExemplaires.Count != 0)
                {
                    var groupeVolumes = GrouperExemplaireEnVolumes();

                    EnleverExemplairesTraitesParGroupeVolumes(groupeVolumes);

                    _groupesVolumes.Add(groupeVolumes);
                }
            }

            private void ConstruireListeExemplaires(Dictionary<Volumes, int> panier)
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
                    var nombreVolumes = groupeVolumes.Count;
                    prix += nombreVolumes * PrixUnitaire * CoeffReduction[nombreVolumes];
                }
                return prix;
            }

            private void EnleverExemplairesTraitesParGroupeVolumes(List<Volumes> groupeVolumes)
            {
                foreach (var volume in groupeVolumes)
                {
                    _listeExemplaires.Remove(volume);
                }
            }

            private List<Volumes> GrouperExemplaireEnVolumes()
            {
                var groupeVolumes = new List<Volumes>();
                foreach (var exemplaire in _listeExemplaires)
                {
                    if (!groupeVolumes.Contains(exemplaire))
                    {
                        groupeVolumes.Add(exemplaire);
                    }
                }
                return groupeVolumes;
            }
        }
    }
}