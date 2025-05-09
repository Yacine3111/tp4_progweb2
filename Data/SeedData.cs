using Bogus;
using Bogus.Extensions.Canada;
using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Data
{
    public static class SeedData
    {
        public static DateTime CURRENT_DATE = new DateTime(2025, 04, 01);
        public static Random random = new Random(8675309);
        public static void Initialize(ModelBuilder modelBuilder)
        {
            Randomizer.Seed = random;

            var enseignants = InitializeEnseignants(enseignants =>
            {
                modelBuilder.Entity<Enseignant>().HasData(enseignants);
            });

            var etudiants = InitializeEtudiants(etudiants =>
            {
                modelBuilder.Entity<Etudiant>().HasData(etudiants);
            });

            var cours = InitializeCours(enseignants, cours =>
            {
                modelBuilder.Entity<Cours>().HasData(cours);
            });

            InitializeInscriptions(etudiants, cours, inscriptions =>
            {
                modelBuilder.Entity<Inscription>().HasData(inscriptions);
            });
        }

        public static void Initialize(ApplicationDbContext context)
        {
            // Vérifier si la base de données contient déjà des données
            if (context.Etudiants.Any() || context.Enseignants.Any() || context.Cours.Any())
            {
                return;
            }

            Randomizer.Seed = new Random(8675309);

            var enseignants = InitializeEnseignants(enseignants =>
            {
                context.Enseignants.AddRange(enseignants);
                context.SaveChanges();
            });

            var etudiants = InitializeEtudiants(etudiants =>
            {
                context.Etudiants.AddRange(etudiants);
                context.SaveChanges();
            });

            var cours = InitializeCours(enseignants, cours =>
            {
                context.Cours.AddRange(cours);
                context.SaveChanges();
            });

            InitializeInscriptions(etudiants, cours, inscriptions =>
            {
                context.Inscriptions.AddRange(inscriptions);
                context.SaveChanges();
            });
        }

        private static List<Enseignant> InitializeEnseignants(Action<List<Enseignant>> enseignantsAction)
        {
            var enseignantFaker = new Faker<Enseignant>("fr_CA")
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(e => e.Prenom, f => f.Name.FirstName())
                .RuleFor(e => e.Nom, f => f.Name.LastName())
                .RuleFor(e => e.DateEmbauche, f => f.Date.Past(10, CURRENT_DATE.AddYears(-2)))
                .RuleFor(e => e.Specialite, f => f.PickRandom(new[] {
                    "Informatique",
                    "Mathématiques",
                    "Base de données",
                    "Réseaux",
                    "Systèmes d'exploitation",
                    "Génie logiciel",
                    "Intelligence artificielle",
                    "Sécurité informatique"
                }))
                .RuleFor(e => e.Bureau, f => $"{f.Random.String2(1, "ABCD")}-{f.Random.Number(100, 999)}")
                .RuleFor(e => e.Telephone, f => f.Phone.PhoneNumber("###-###-####"))
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.Prenom, e.Nom))
                .RuleFor(e => e.NumeroAssuranceSociale, f => f.Person.Sin())
                .RuleFor(e => e.InformationsBancaires, f => $"Compte: {f.Finance.Account()}, Banque: {f.Company.CompanyName()}");

            var enseignants = enseignantFaker.Generate(10);
            enseignantsAction.Invoke(enseignants);
            return enseignants;
        }

        private static List<Etudiant> InitializeEtudiants(Action<List<Etudiant>> etudiantsAction)
        {
            var etudiantFaker = new Faker<Etudiant>("fr_CA")
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(e => e.NumeroEtudiant, f => f.Random.Replace("#######"))
                .RuleFor(e => e.Prenom, f => f.Name.FirstName())
                .RuleFor(e => e.Nom, f => f.Name.LastName())
                .RuleFor(e => e.DateNaissance, f => f.Date.Between(CURRENT_DATE.AddYears(-20), CURRENT_DATE.AddYears(-18)))
                .RuleFor(e => e.Adresse, f => f.Address.StreetAddress())
                .RuleFor(e => e.Ville, f => f.Address.City())
                .RuleFor(e => e.CodePostal, f => f.Address.ZipCode("?#? #?#"))
                .RuleFor(e => e.Telephone, f => f.Phone.PhoneNumber("###-###-####"))
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.Prenom, e.Nom))
                .RuleFor(e => e.NumeroAssuranceSociale, f => f.Person.Sin())
                .RuleFor(e => e.InformationsMedicales, f => f.PickRandom(new[] {
                    "Aucune condition particulière",
                    "Allergie aux arachides",
                    "Asthme",
                    "Diabète de type 1",
                    "Allergies saisonnières",
                    "Épilepsie",
                    "Migraines chroniques",
                    "Allergie aux fruits de mer",
                    "Anémie",
                    "Dyslexie"
                 }));

            var etudiants = etudiantFaker.Generate(50);
            etudiantsAction.Invoke(etudiants);
            return etudiants;
        }

        private static List<Cours> InitializeCours(List<Enseignant> enseignants, Action<List<Cours>> coursAction)
        {
            var coursList = new List<(string Code, string Titre, string Description, int Credits)>
            {
                ("420-125", "Conception de sites web I", "Apprentissage des concepts fondamentaux du web", 5),
                ("420-136", "Langage de programmation", "Introduction au Java et à la programmation", 6),
                ("420-246", "Programmation orientée objet", "Principes et pratiques de la programmation orientée objet", 3),
                ("420-236", "Base de données", "Conception et gestion des bases de données relationnelles", 6),
                ("420-346", "Programmation Web I", "Technologies et méthodologies du développement web", 6),
                ("201-314", "Mathématiques appliquées à l'informatique", "Introduction aux concepts mathématiques pour l'informatique", 4),
                ("420-435", "Gestion de réseaux locaux", "Concepts fondamentaux des réseaux informatiques", 5),
                ("420-614", "Sécurité informatique", "Principes de base de la sécurité des systèmes informatiques", 4),
                ("420-354", "Systèmes d'exploitation", "Étude des concepts des systèmes d'exploitation", 4),
                ("350-513", "Communication en contexte professionnel", "Méthodologies de développement logiciel", 3)
            };

            // Création des cours
            var coursFaker = new Faker<Cours>("fr_CA")
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.DateDebut, f => new DateTime(CURRENT_DATE.Year, 9, 1))
                .RuleFor(c => c.DateFin, f => new DateTime(CURRENT_DATE.Year, 12, 15))
                .RuleFor(c => c.Local, f => $"{f.Random.String2(1, "ABCD")}-{f.Random.Number(100, 999)}")
                .RuleFor(c => c.CapaciteMax, f => f.Random.Number(20, 40));

            var cours = new List<Cours>();
            for (int i = 0; i < coursList.Count; i++)
            {
                var coursInfo = coursList[i];
                var coursGenere = coursFaker.Generate();
                coursGenere.Code = coursInfo.Code;
                coursGenere.Titre = coursInfo.Titre;
                coursGenere.Description = coursInfo.Description;
                coursGenere.Credits = coursInfo.Credits;
                coursGenere.EnseignantId = enseignants[i % enseignants.Count].Id;
                cours.Add(coursGenere);
            }

            coursAction.Invoke(cours);
            return cours;
        }

        private static void InitializeInscriptions(List<Etudiant> etudiants, List<Cours> cours, Action<List<Inscription>> inscriptionsAction)
        {
            var inscriptionFaker = new Faker<Inscription>("fr_CA")
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(i => i.DateInscription, f => f.Date.Between(new DateTime(CURRENT_DATE.Year, 8, 15), new DateTime(CURRENT_DATE.Year, 9, 15)))
                .RuleFor(i => i.Statut, f => f.PickRandom<StatutInscription>())
                .RuleFor(i => i.NotePourcentage, (f, i) =>
                    i.Statut == StatutInscription.Terminé ? (decimal?)f.Random.Decimal(60, 100) : null);

            var inscriptions = new List<Inscription>();

            // Chaque étudiant s'inscrit à 3-6 cours aléatoires
            foreach (var etudiant in etudiants)
            {
                var nombreCours = random.Next(3, 7);
                var coursChoisis = cours.OrderBy(x => random.Next()).Take(nombreCours).ToList();

                foreach (var coursSelectionne in coursChoisis)
                {
                    var inscription = inscriptionFaker.Generate();
                    inscription.EtudiantId = etudiant.Id;
                    inscription.CoursId = coursSelectionne.Id;

                    // Pour certains cours, définir le statut selon la date
                    if (inscription.Statut == StatutInscription.Terminé)
                    {
                        // S'assurer que les cours "terminés" ont une date de début plus ancienne
                        inscription.DateInscription = inscription.DateInscription.AddMonths(-4);
                    }

                    inscriptions.Add(inscription);
                }
            }

            inscriptionsAction.Invoke(inscriptions);
        }
    }
}