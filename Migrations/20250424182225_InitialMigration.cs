using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP4.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bureau = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroAssuranceSociale = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    InformationsBancaires = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroEtudiant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroAssuranceSociale = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    InformationsMedicales = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CapaciteMax = table.Column<int>(type: "int", nullable: false),
                    EnseignantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cours_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: true),
                    EnseignantId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    CoursId = table.Column<int>(type: "int", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotePourcentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Cours_CoursId",
                        column: x => x.CoursId,
                        principalTable: "Cours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enseignants",
                columns: new[] { "Id", "Bureau", "DateEmbauche", "Email", "InformationsBancaires", "Nom", "NumeroAssuranceSociale", "Prenom", "Specialite", "Telephone" },
                values: new object[,]
                {
                    { 1, "C-560", new DateTime(2014, 3, 10, 8, 30, 40, 293, DateTimeKind.Unspecified).AddTicks(2444), "Euna.Herman@yahoo.ca", "Compte: 79076466, Banque: Pagac, Schulist and Wuckert", "Herman", "885 156 398", "Euna", "Intelligence artificielle", "890-741-6933" },
                    { 2, "D-167", new DateTime(2018, 2, 5, 19, 29, 22, 53, DateTimeKind.Unspecified).AddTicks(5477), "Eldora.Wisozk@gmail.com", "Compte: 41638949, Banque: Cormier LLC", "Wisozk", "705 908 978", "Eldora", "Intelligence artificielle", "319-444-9996" },
                    { 3, "C-514", new DateTime(2022, 5, 29, 3, 15, 33, 382, DateTimeKind.Unspecified).AddTicks(681), "Paige_Steuber81@gmail.com", "Compte: 58528734, Banque: Cummerata LLC", "Steuber", "981 780 349", "Paige", "Réseaux", "443-611-5545" },
                    { 4, "C-781", new DateTime(2020, 7, 2, 18, 9, 52, 647, DateTimeKind.Unspecified).AddTicks(6708), "Jaeden_Hane87@yahoo.ca", "Compte: 37493296, Banque: Greenholt, Corkery and Schulist", "Hane", "282 010 594", "Jaeden", "Intelligence artificielle", "031-789-3257" },
                    { 5, "B-565", new DateTime(2022, 5, 13, 23, 25, 23, 25, DateTimeKind.Unspecified).AddTicks(9498), "Selina71@hotmail.com", "Compte: 84869160, Banque: Nikolaus, Denesik and Auer", "Hackett", "508 886 512", "Selina", "Informatique", "121-279-1121" },
                    { 6, "A-710", new DateTime(2015, 8, 13, 8, 29, 10, 945, DateTimeKind.Unspecified).AddTicks(9518), "Retha.OKeefe79@hotmail.com", "Compte: 66767846, Banque: Fisher, Mitchell and Beier", "O'Keefe", "926 029 109", "Retha", "Intelligence artificielle", "202-420-0694" },
                    { 7, "A-240", new DateTime(2016, 8, 6, 16, 26, 1, 584, DateTimeKind.Unspecified).AddTicks(7044), "Ada61@gmail.com", "Compte: 88564857, Banque: Daugherty Inc", "Walter", "020 350 864", "Ada", "Sécurité informatique", "147-968-7050" },
                    { 8, "A-177", new DateTime(2022, 11, 3, 23, 9, 32, 107, DateTimeKind.Unspecified).AddTicks(1885), "Joy92@hotmail.com", "Compte: 85821727, Banque: Langosh - Brakus", "Gislason", "970 850 806", "Joy", "Intelligence artificielle", "771-900-5251" },
                    { 9, "C-711", new DateTime(2013, 7, 31, 21, 37, 27, 696, DateTimeKind.Unspecified).AddTicks(5954), "Brady26@hotmail.com", "Compte: 40796578, Banque: Bins - Gutmann", "Gottlieb", "287 533 319", "Brady", "Informatique", "147-503-5643" },
                    { 10, "A-939", new DateTime(2021, 5, 7, 5, 38, 28, 193, DateTimeKind.Unspecified).AddTicks(4576), "Kamren_Wilderman66@yahoo.ca", "Compte: 25015716, Banque: Bruen, Mraz and Koss", "Wilderman", "662 015 320", "Kamren", "Systèmes d'exploitation", "021-546-4897" }
                });

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "Id", "Adresse", "CodePostal", "DateNaissance", "Email", "InformationsMedicales", "Nom", "NumeroAssuranceSociale", "NumeroEtudiant", "Prenom", "Telephone", "Ville" },
                values: new object[,]
                {
                    { 1, "022 Yvonne Stravenue", "W4E 8C4", new DateTime(2007, 3, 3, 17, 33, 57, 370, DateTimeKind.Unspecified).AddTicks(2836), "Quentin.Strosin56@yahoo.ca", "Allergies saisonnières", "Strosin", "174 933 689", "5339720", "Quentin", "105-909-9302", "South Peytontown" },
                    { 2, "95448 Leatha Plaza", "S9A 0A1", new DateTime(2006, 1, 30, 5, 6, 18, 400, DateTimeKind.Unspecified).AddTicks(1019), "Kory.Casper@gmail.com", "Allergies saisonnières", "Casper", "275 199 305", "1826751", "Kory", "323-182-0876", "New Olga" },
                    { 3, "57883 Murphy Mount", "X5O 5X1", new DateTime(2005, 10, 15, 18, 15, 43, 556, DateTimeKind.Unspecified).AddTicks(5703), "Torey_Hane@yahoo.ca", "Dyslexie", "Hane", "339 934 390", "0379962", "Torey", "571-764-2303", "East Delberttown" },
                    { 4, "77112 Lang Crest", "V8D 3R5", new DateTime(2005, 10, 24, 7, 9, 0, 220, DateTimeKind.Unspecified).AddTicks(4037), "Cleta_Schimmel53@gmail.com", "Allergies saisonnières", "Schimmel", "332 623 883", "4249643", "Cleta", "801-260-5866", "Lednerburgh" },
                    { 5, "91343 Jerde Groves", "P6Y 5Z5", new DateTime(2005, 11, 12, 22, 1, 9, 856, DateTimeKind.Unspecified).AddTicks(7357), "Darlene.Grady61@hotmail.com", "Anémie", "Grady", "927 223 891", "9198379", "Darlene", "202-776-0036", "Corinemouth" },
                    { 6, "174 Rutherford Square", "W9K 1V3", new DateTime(2006, 6, 13, 8, 34, 18, 898, DateTimeKind.Unspecified).AddTicks(9789), "Jarrett_Schmeler21@gmail.com", "Épilepsie", "Schmeler", "671 809 846", "1508299", "Jarrett", "790-840-8971", "New Jamaalshire" },
                    { 7, "256 Ernest Fork", "M7E 1J7", new DateTime(2005, 10, 14, 7, 13, 39, 155, DateTimeKind.Unspecified).AddTicks(1210), "Velma_Feest11@hotmail.com", "Allergies saisonnières", "Feest", "406 155 796", "5004018", "Velma", "033-469-4656", "Heaneymouth" },
                    { 8, "21499 Walker Green", "B3C 4F9", new DateTime(2006, 8, 1, 8, 31, 35, 876, DateTimeKind.Unspecified).AddTicks(6082), "Jayden53@yahoo.ca", "Asthme", "Rodriguez", "782 571 764", "6266833", "Jayden", "000-870-1094", "Wittingshire" },
                    { 9, "3843 Pamela Mountain", "L0N 6F6", new DateTime(2005, 6, 29, 0, 11, 7, 131, DateTimeKind.Unspecified).AddTicks(2440), "Emily77@gmail.com", "Anémie", "Mosciski", "164 931 883", "1299034", "Emily", "135-970-0846", "New Giovanimouth" },
                    { 10, "64260 Anibal Street", "D3I 4X5", new DateTime(2006, 12, 28, 1, 20, 21, 748, DateTimeKind.Unspecified).AddTicks(8639), "Elta_Orn9@yahoo.ca", "Allergies saisonnières", "Orn", "260 534 847", "6141770", "Elta", "732-647-3740", "Bruenhaven" },
                    { 11, "35351 Bednar Way", "N5F 8E1", new DateTime(2005, 4, 20, 19, 6, 12, 734, DateTimeKind.Unspecified).AddTicks(9110), "Tavares74@yahoo.ca", "Épilepsie", "Marquardt", "295 560 692", "5436210", "Tavares", "804-360-8774", "Kelsifort" },
                    { 12, "89874 Boyle Mall", "E2A 1A9", new DateTime(2005, 10, 6, 14, 48, 1, 456, DateTimeKind.Unspecified).AddTicks(1049), "Ladarius_Dickinson5@hotmail.com", "Allergie aux fruits de mer", "Dickinson", "995 903 945", "5478563", "Ladarius", "074-121-9433", "Gleasonshire" },
                    { 13, "48642 Wolf Village", "M2Q 3I6", new DateTime(2007, 3, 18, 4, 18, 38, 411, DateTimeKind.Unspecified).AddTicks(4290), "Victoria28@yahoo.ca", "Anémie", "Stark", "408 646 461", "0792914", "Victoria", "287-888-7049", "Hegmannhaven" },
                    { 14, "042 Sharon Streets", "L7S 5F1", new DateTime(2005, 6, 10, 3, 5, 53, 51, DateTimeKind.Unspecified).AddTicks(9627), "Destin_Schamberger@gmail.com", "Allergies saisonnières", "Schamberger", "247 830 284", "4563314", "Destin", "246-847-9099", "Port Emilio" },
                    { 15, "9770 Keebler Street", "D1B 0F8", new DateTime(2007, 1, 10, 4, 16, 9, 157, DateTimeKind.Unspecified).AddTicks(3200), "Antoinette25@yahoo.ca", "Épilepsie", "Bode", "211 739 826", "4573591", "Antoinette", "352-882-9766", "Gulgowskifurt" },
                    { 16, "72381 Predovic Expressway", "R3O 0Z3", new DateTime(2007, 2, 20, 7, 20, 29, 640, DateTimeKind.Unspecified).AddTicks(2011), "Haleigh_Bechtelar6@gmail.com", "Allergies saisonnières", "Bechtelar", "560 197 543", "0241913", "Haleigh", "189-038-3391", "Arlenestad" },
                    { 17, "78846 Rene Street", "H2S 6P1", new DateTime(2005, 6, 20, 23, 18, 27, 438, DateTimeKind.Unspecified).AddTicks(3024), "Whitney.Windler75@gmail.com", "Diabète de type 1", "Windler", "122 451 941", "7348954", "Whitney", "810-231-0423", "Nellefort" },
                    { 18, "96035 Anderson Forges", "H8M 3H1", new DateTime(2006, 1, 15, 4, 41, 18, 62, DateTimeKind.Unspecified).AddTicks(4334), "Sophia_Von75@yahoo.ca", "Migraines chroniques", "Von", "114 353 360", "9685134", "Sophia", "432-797-5452", "North Floyd" },
                    { 19, "40627 Little Locks", "Q1S 0T0", new DateTime(2006, 8, 19, 21, 35, 41, 674, DateTimeKind.Unspecified).AddTicks(3179), "Nickolas_Bernier@hotmail.com", "Dyslexie", "Bernier", "384 726 576", "7623184", "Nickolas", "491-614-3531", "Trantowmouth" },
                    { 20, "665 Nikolaus Roads", "I7S 7L1", new DateTime(2007, 1, 8, 15, 53, 23, 520, DateTimeKind.Unspecified).AddTicks(8119), "Marianne.Kerluke81@yahoo.ca", "Dyslexie", "Kerluke", "574 257 317", "1340878", "Marianne", "457-109-0944", "New Katrina" },
                    { 21, "4679 Frami Radial", "O7V 0L6", new DateTime(2006, 6, 28, 23, 10, 15, 139, DateTimeKind.Unspecified).AddTicks(1820), "Murphy22@yahoo.ca", "Allergies saisonnières", "Halvorson", "593 231 889", "2711745", "Murphy", "115-951-3264", "South Maureen" },
                    { 22, "0350 Murray Vista", "R8Z 7W6", new DateTime(2006, 1, 18, 5, 50, 5, 359, DateTimeKind.Unspecified).AddTicks(2601), "Shayne.Altenwerth@yahoo.ca", "Asthme", "Altenwerth", "100 710 144", "9796864", "Shayne", "584-915-7843", "Lake Melynastad" },
                    { 23, "706 Rempel Grove", "B4K 1I2", new DateTime(2005, 10, 20, 14, 52, 25, 144, DateTimeKind.Unspecified).AddTicks(9584), "Freeman.Ryan98@gmail.com", "Épilepsie", "Ryan", "489 753 954", "6354088", "Freeman", "565-133-3829", "Justynfurt" },
                    { 24, "2570 Andres Junction", "S6I 9V0", new DateTime(2006, 3, 6, 20, 59, 9, 7, DateTimeKind.Unspecified).AddTicks(9561), "Bertha_Schulist@gmail.com", "Anémie", "Schulist", "864 032 024", "0773044", "Bertha", "319-317-2092", "Lake Adriennehaven" },
                    { 25, "13980 Pagac Square", "X0J 8V7", new DateTime(2005, 5, 6, 5, 36, 43, 849, DateTimeKind.Unspecified).AddTicks(1835), "Clarissa73@yahoo.ca", "Allergie aux fruits de mer", "Bosco", "999 173 933", "6260424", "Clarissa", "070-859-0420", "Ferrychester" },
                    { 26, "998 Ebert Fort", "E2W 9J1", new DateTime(2005, 5, 25, 9, 7, 10, 446, DateTimeKind.Unspecified).AddTicks(410), "Leonard4@yahoo.ca", "Dyslexie", "West", "685 417 552", "2765824", "Leonard", "253-598-8270", "Boehmhaven" },
                    { 27, "825 Purdy Stravenue", "O6T 7N4", new DateTime(2007, 2, 4, 0, 40, 57, 184, DateTimeKind.Unspecified).AddTicks(9030), "Marty.Metz29@hotmail.com", "Diabète de type 1", "Metz", "852 134 360", "6707334", "Marty", "546-850-5115", "Port Verlahaven" },
                    { 28, "135 Laurie Well", "L4W 8P4", new DateTime(2006, 10, 13, 15, 57, 44, 962, DateTimeKind.Unspecified).AddTicks(1218), "Kyra_Metz@yahoo.ca", "Asthme", "Metz", "011 605 615", "3937344", "Kyra", "433-605-3682", "Jaydonville" },
                    { 29, "00110 Carter Flats", "F1Z 2C1", new DateTime(2006, 6, 1, 12, 7, 37, 371, DateTimeKind.Unspecified).AddTicks(2671), "Lulu.Murphy@hotmail.com", "Allergies saisonnières", "Murphy", "295 748 966", "5351808", "Lulu", "555-022-3673", "Lake Lianafort" },
                    { 30, "645 Jacey Expressway", "G6S 6K3", new DateTime(2005, 10, 15, 1, 34, 51, 36, DateTimeKind.Unspecified).AddTicks(5653), "Dewayne.Heller76@gmail.com", "Migraines chroniques", "Heller", "403 303 506", "4326127", "Dewayne", "622-360-0244", "Lake Edwardhaven" },
                    { 31, "340 Alexie Tunnel", "M9O 3W6", new DateTime(2007, 1, 2, 3, 36, 15, 115, DateTimeKind.Unspecified).AddTicks(8283), "Sonya51@hotmail.com", "Diabète de type 1", "Yost", "389 784 778", "7788693", "Sonya", "004-013-5306", "New Giovanishire" },
                    { 32, "6424 Bailey Brook", "T0X 0E3", new DateTime(2005, 6, 12, 10, 16, 28, 366, DateTimeKind.Unspecified).AddTicks(9221), "Cleora66@hotmail.com", "Allergie aux arachides", "Hyatt", "574 911 046", "1078439", "Cleora", "238-723-6092", "Teaganborough" },
                    { 33, "35835 Emanuel Lakes", "L5L 6A4", new DateTime(2005, 6, 28, 4, 23, 3, 304, DateTimeKind.Unspecified).AddTicks(2188), "Edmond73@hotmail.com", "Diabète de type 1", "Lowe", "054 251 095", "4982927", "Edmond", "271-614-9894", "Auerbury" },
                    { 34, "70925 Hackett Estate", "F3T 6Y4", new DateTime(2005, 7, 3, 18, 29, 51, 936, DateTimeKind.Unspecified).AddTicks(1171), "Danielle69@yahoo.ca", "Allergie aux fruits de mer", "Reinger", "853 652 394", "8284984", "Danielle", "554-946-2954", "Port Derickview" },
                    { 35, "08470 Elton Heights", "C5K 4S2", new DateTime(2007, 1, 12, 21, 57, 19, 501, DateTimeKind.Unspecified).AddTicks(8394), "Vada_Jaskolski48@hotmail.com", "Anémie", "Jaskolski", "040 092 439", "1393354", "Vada", "925-812-3818", "Beahanmouth" },
                    { 36, "3464 Reese Garden", "Z7Z 8Q8", new DateTime(2006, 1, 9, 11, 8, 36, 975, DateTimeKind.Unspecified).AddTicks(3008), "Nedra_Halvorson66@gmail.com", "Dyslexie", "Halvorson", "907 680 698", "5643840", "Nedra", "285-246-1590", "Lake Kodyhaven" },
                    { 37, "663 Kennith Pass", "P9H 1T9", new DateTime(2006, 1, 15, 21, 12, 6, 173, DateTimeKind.Unspecified).AddTicks(3247), "Johnathon65@hotmail.com", "Allergies saisonnières", "Dietrich", "678 550 534", "8757359", "Johnathon", "835-770-2290", "Marvinmouth" },
                    { 38, "438 Zena Summit", "Q1W 7W3", new DateTime(2006, 2, 9, 14, 25, 12, 71, DateTimeKind.Unspecified).AddTicks(3774), "Antonette42@gmail.com", "Allergie aux fruits de mer", "Hane", "389 242 769", "8781776", "Antonette", "122-573-5820", "Giovaniland" },
                    { 39, "4836 Goyette Fields", "V4L 4Z3", new DateTime(2005, 9, 24, 10, 41, 37, 620, DateTimeKind.Unspecified).AddTicks(5349), "Jermain_Haley56@hotmail.com", "Épilepsie", "Haley", "073 805 566", "9111275", "Jermain", "471-300-1155", "Barrychester" },
                    { 40, "2165 June Fall", "T8C 8K2", new DateTime(2006, 2, 1, 23, 1, 14, 135, DateTimeKind.Unspecified).AddTicks(351), "Lucinda93@hotmail.com", "Dyslexie", "Leuschke", "887 085 587", "1757882", "Lucinda", "849-488-2120", "Micheltown" },
                    { 41, "7916 Weimann Overpass", "Q0X 6P7", new DateTime(2005, 8, 27, 10, 19, 47, 762, DateTimeKind.Unspecified).AddTicks(2599), "Josianne.Bauch19@gmail.com", "Aucune condition particulière", "Bauch", "923 341 978", "2084501", "Josianne", "029-684-5705", "Alessiafort" },
                    { 42, "333 Hackett Light", "V8V 3O2", new DateTime(2005, 10, 15, 5, 3, 43, 942, DateTimeKind.Unspecified).AddTicks(2391), "Nelle63@yahoo.ca", "Épilepsie", "Jacobi", "863 661 237", "5296368", "Nelle", "109-773-5513", "Nikitaton" },
                    { 43, "958 Salvador Land", "T8W 3J1", new DateTime(2005, 4, 24, 21, 41, 32, 698, DateTimeKind.Unspecified).AddTicks(1232), "Drake36@gmail.com", "Anémie", "Kirlin", "580 931 772", "8856875", "Drake", "876-461-7672", "Balistrerichester" },
                    { 44, "66817 Prosacco Coves", "I1A 4P8", new DateTime(2006, 9, 18, 17, 35, 22, 362, DateTimeKind.Unspecified).AddTicks(576), "Mavis6@hotmail.com", "Asthme", "Bailey", "525 052 163", "0210356", "Mavis", "274-011-2844", "Pacochaview" },
                    { 45, "366 Kiehn River", "A0V 8R8", new DateTime(2005, 7, 30, 15, 25, 7, 381, DateTimeKind.Unspecified).AddTicks(5098), "Erna.Halvorson78@gmail.com", "Allergie aux arachides", "Halvorson", "516 177 110", "3355427", "Erna", "690-150-7484", "West Issacport" },
                    { 46, "173 Benedict Locks", "X1D 3L7", new DateTime(2006, 8, 7, 10, 17, 37, 3, DateTimeKind.Unspecified).AddTicks(5645), "Rafaela35@yahoo.ca", "Anémie", "Kreiger", "191 397 140", "8348973", "Rafaela", "303-117-9539", "Alisonport" },
                    { 47, "409 O'Keefe Shores", "V5L 4S4", new DateTime(2005, 12, 3, 7, 50, 59, 306, DateTimeKind.Unspecified).AddTicks(7211), "Nigel_Koch@gmail.com", "Anémie", "Koch", "838 264 851", "9330257", "Nigel", "111-015-0212", "South Chaimmouth" },
                    { 48, "17891 Stanton Track", "F0Z 3F5", new DateTime(2005, 7, 6, 17, 27, 47, 347, DateTimeKind.Unspecified).AddTicks(9492), "Tanner52@yahoo.ca", "Asthme", "Keebler", "293 327 086", "6873775", "Tanner", "721-082-9240", "Lake Randi" },
                    { 49, "1401 Arden Fall", "N0G 2I9", new DateTime(2005, 8, 15, 5, 5, 26, 316, DateTimeKind.Unspecified).AddTicks(5380), "Micheal.Rogahn88@yahoo.ca", "Migraines chroniques", "Rogahn", "292 428 596", "8389700", "Micheal", "287-942-0323", "Yvonneport" },
                    { 50, "23365 Meda Track", "D4I 8N5", new DateTime(2006, 8, 13, 18, 44, 51, 523, DateTimeKind.Unspecified).AddTicks(1915), "Dina_Hansen76@yahoo.ca", "Épilepsie", "Hansen", "423 252 493", "6177044", "Dina", "052-368-0741", "New Maeveport" }
                });

            migrationBuilder.InsertData(
                table: "Cours",
                columns: new[] { "Id", "CapaciteMax", "Code", "Credits", "DateDebut", "DateFin", "Description", "EnseignantId", "Local", "Titre" },
                values: new object[,]
                {
                    { 1, 29, "420-125", 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apprentissage des concepts fondamentaux du web", 1, "A-208", "Conception de sites web I" },
                    { 2, 38, "420-136", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction au Java et à la programmation", 2, "A-316", "Langage de programmation" },
                    { 3, 33, "420-246", 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principes et pratiques de la programmation orientée objet", 3, "A-975", "Programmation orientée objet" },
                    { 4, 27, "420-236", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conception et gestion des bases de données relationnelles", 4, "B-976", "Base de données" },
                    { 5, 28, "420-346", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technologies et méthodologies du développement web", 5, "C-435", "Programmation Web I" },
                    { 6, 20, "201-314", 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction aux concepts mathématiques pour l'informatique", 6, "A-460", "Mathématiques appliquées à l'informatique" },
                    { 7, 36, "420-435", 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concepts fondamentaux des réseaux informatiques", 7, "A-301", "Gestion de réseaux locaux" },
                    { 8, 33, "420-614", 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principes de base de la sécurité des systèmes informatiques", 8, "D-905", "Sécurité informatique" },
                    { 9, 28, "420-354", 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Étude des concepts des systèmes d'exploitation", 9, "D-946", "Systèmes d'exploitation" },
                    { 10, 20, "350-513", 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Méthodologies de développement logiciel", 10, "A-257", "Communication en contexte professionnel" }
                });

            migrationBuilder.InsertData(
                table: "Inscriptions",
                columns: new[] { "Id", "CoursId", "DateInscription", "EtudiantId", "NotePourcentage", "Statut" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2025, 4, 19, 18, 30, 22, 214, DateTimeKind.Unspecified).AddTicks(3275), 1, 72.492526589190840m, 1 },
                    { 2, 5, new DateTime(2025, 9, 1, 6, 45, 44, 8, DateTimeKind.Unspecified).AddTicks(2619), 1, null, 2 },
                    { 3, 9, new DateTime(2025, 9, 10, 5, 39, 9, 217, DateTimeKind.Unspecified).AddTicks(7775), 1, null, 0 },
                    { 4, 6, new DateTime(2025, 4, 15, 2, 55, 13, 469, DateTimeKind.Unspecified).AddTicks(1913), 1, 65.109618047769000m, 1 },
                    { 5, 10, new DateTime(2025, 5, 8, 18, 8, 35, 704, DateTimeKind.Unspecified).AddTicks(3746), 2, 96.158742474465960m, 1 },
                    { 6, 7, new DateTime(2025, 9, 3, 23, 11, 44, 591, DateTimeKind.Unspecified).AddTicks(2014), 2, null, 2 },
                    { 7, 4, new DateTime(2025, 9, 7, 10, 1, 7, 922, DateTimeKind.Unspecified).AddTicks(4272), 2, null, 2 },
                    { 8, 5, new DateTime(2025, 8, 25, 4, 39, 0, 638, DateTimeKind.Unspecified).AddTicks(4352), 2, null, 2 },
                    { 9, 8, new DateTime(2025, 8, 20, 23, 43, 47, 585, DateTimeKind.Unspecified).AddTicks(3585), 3, null, 2 },
                    { 10, 9, new DateTime(2025, 9, 11, 17, 9, 11, 24, DateTimeKind.Unspecified).AddTicks(1707), 3, null, 2 },
                    { 11, 7, new DateTime(2025, 9, 14, 1, 28, 37, 857, DateTimeKind.Unspecified).AddTicks(4989), 3, null, 2 },
                    { 12, 10, new DateTime(2025, 4, 15, 20, 20, 38, 220, DateTimeKind.Unspecified).AddTicks(9314), 3, 93.192080218900040m, 1 },
                    { 13, 10, new DateTime(2025, 8, 28, 4, 49, 56, 740, DateTimeKind.Unspecified).AddTicks(9319), 4, null, 2 },
                    { 14, 9, new DateTime(2025, 8, 31, 3, 35, 41, 913, DateTimeKind.Unspecified).AddTicks(4334), 4, null, 2 },
                    { 15, 5, new DateTime(2025, 4, 17, 9, 54, 53, 635, DateTimeKind.Unspecified).AddTicks(3805), 4, 65.338986630243720m, 1 },
                    { 16, 7, new DateTime(2025, 8, 20, 21, 40, 52, 938, DateTimeKind.Unspecified).AddTicks(89), 4, null, 2 },
                    { 17, 2, new DateTime(2025, 9, 6, 13, 40, 29, 701, DateTimeKind.Unspecified).AddTicks(4957), 5, null, 0 },
                    { 18, 3, new DateTime(2025, 4, 30, 11, 16, 38, 946, DateTimeKind.Unspecified).AddTicks(9777), 5, 77.084675755856880m, 1 },
                    { 19, 4, new DateTime(2025, 9, 12, 3, 13, 12, 823, DateTimeKind.Unspecified).AddTicks(4661), 5, null, 2 },
                    { 20, 9, new DateTime(2025, 8, 16, 19, 16, 57, 740, DateTimeKind.Unspecified).AddTicks(7469), 5, null, 0 },
                    { 21, 1, new DateTime(2025, 9, 2, 6, 21, 44, 100, DateTimeKind.Unspecified).AddTicks(6418), 5, null, 0 },
                    { 22, 2, new DateTime(2025, 9, 10, 11, 33, 42, 259, DateTimeKind.Unspecified).AddTicks(298), 6, null, 0 },
                    { 23, 6, new DateTime(2025, 9, 7, 5, 21, 3, 500, DateTimeKind.Unspecified).AddTicks(3910), 6, null, 2 },
                    { 24, 5, new DateTime(2025, 4, 21, 9, 53, 5, 36, DateTimeKind.Unspecified).AddTicks(6535), 6, 90.249155419994680m, 1 },
                    { 25, 1, new DateTime(2025, 9, 4, 9, 13, 10, 505, DateTimeKind.Unspecified).AddTicks(8062), 7, null, 0 },
                    { 26, 8, new DateTime(2025, 9, 12, 20, 45, 4, 162, DateTimeKind.Unspecified).AddTicks(51), 7, null, 0 },
                    { 27, 10, new DateTime(2025, 4, 29, 12, 35, 42, 354, DateTimeKind.Unspecified).AddTicks(818), 7, 68.143721729583920m, 1 },
                    { 28, 7, new DateTime(2025, 4, 21, 6, 43, 3, 344, DateTimeKind.Unspecified).AddTicks(6392), 7, 72.08063856329800m, 1 },
                    { 29, 2, new DateTime(2025, 8, 26, 6, 53, 29, 806, DateTimeKind.Unspecified).AddTicks(7012), 8, null, 0 },
                    { 30, 4, new DateTime(2025, 5, 11, 11, 10, 24, 94, DateTimeKind.Unspecified).AddTicks(8566), 8, 87.933563398166360m, 1 },
                    { 31, 6, new DateTime(2025, 5, 13, 5, 8, 20, 871, DateTimeKind.Unspecified).AddTicks(8577), 8, 85.617631704368440m, 1 },
                    { 32, 7, new DateTime(2025, 5, 1, 13, 9, 29, 619, DateTimeKind.Unspecified).AddTicks(4899), 8, 65.499080086825000m, 1 },
                    { 33, 3, new DateTime(2025, 9, 7, 17, 40, 26, 906, DateTimeKind.Unspecified).AddTicks(4127), 8, null, 2 },
                    { 34, 7, new DateTime(2025, 4, 30, 4, 33, 20, 448, DateTimeKind.Unspecified).AddTicks(2465), 9, 97.065347040568160m, 1 },
                    { 35, 5, new DateTime(2025, 4, 23, 22, 37, 19, 456, DateTimeKind.Unspecified).AddTicks(5559), 9, 99.429478347035800m, 1 },
                    { 36, 8, new DateTime(2025, 5, 10, 18, 54, 25, 224, DateTimeKind.Unspecified).AddTicks(1234), 9, 89.994584969242360m, 1 },
                    { 37, 9, new DateTime(2025, 8, 29, 13, 21, 33, 25, DateTimeKind.Unspecified).AddTicks(1018), 9, null, 0 },
                    { 38, 6, new DateTime(2025, 9, 7, 23, 22, 26, 510, DateTimeKind.Unspecified).AddTicks(1902), 9, null, 0 },
                    { 39, 9, new DateTime(2025, 8, 25, 22, 29, 46, 695, DateTimeKind.Unspecified).AddTicks(5434), 10, null, 2 },
                    { 40, 7, new DateTime(2025, 4, 30, 13, 0, 21, 862, DateTimeKind.Unspecified).AddTicks(2917), 10, 76.323506336809840m, 1 },
                    { 41, 4, new DateTime(2025, 9, 14, 7, 36, 13, 128, DateTimeKind.Unspecified).AddTicks(4656), 10, null, 2 },
                    { 42, 2, new DateTime(2025, 8, 19, 15, 19, 30, 809, DateTimeKind.Unspecified).AddTicks(845), 10, null, 2 },
                    { 43, 10, new DateTime(2025, 8, 21, 4, 4, 49, 280, DateTimeKind.Unspecified).AddTicks(3797), 10, null, 2 },
                    { 44, 1, new DateTime(2025, 9, 10, 16, 20, 1, 53, DateTimeKind.Unspecified).AddTicks(7690), 11, null, 0 },
                    { 45, 7, new DateTime(2025, 5, 13, 9, 33, 56, 984, DateTimeKind.Unspecified).AddTicks(3003), 11, 99.247473775990080m, 1 },
                    { 46, 3, new DateTime(2025, 4, 28, 16, 56, 14, 966, DateTimeKind.Unspecified).AddTicks(2996), 11, 79.768894882765080m, 1 },
                    { 47, 8, new DateTime(2025, 8, 19, 6, 42, 43, 350, DateTimeKind.Unspecified).AddTicks(4205), 11, null, 2 },
                    { 48, 6, new DateTime(2025, 9, 10, 5, 29, 50, 786, DateTimeKind.Unspecified).AddTicks(7688), 12, null, 2 },
                    { 49, 9, new DateTime(2025, 4, 30, 18, 33, 7, 870, DateTimeKind.Unspecified).AddTicks(6006), 12, 74.722630146296040m, 1 },
                    { 50, 5, new DateTime(2025, 8, 27, 4, 41, 17, 282, DateTimeKind.Unspecified).AddTicks(715), 12, null, 0 },
                    { 51, 3, new DateTime(2025, 8, 22, 21, 13, 51, 128, DateTimeKind.Unspecified).AddTicks(4987), 13, null, 2 },
                    { 52, 6, new DateTime(2025, 8, 25, 23, 0, 45, 203, DateTimeKind.Unspecified).AddTicks(7497), 13, null, 0 },
                    { 53, 4, new DateTime(2025, 8, 22, 23, 1, 15, 849, DateTimeKind.Unspecified).AddTicks(4897), 13, null, 0 },
                    { 54, 7, new DateTime(2025, 5, 5, 14, 40, 27, 459, DateTimeKind.Unspecified).AddTicks(3316), 13, 87.295483363464240m, 1 },
                    { 55, 7, new DateTime(2025, 9, 3, 0, 9, 43, 529, DateTimeKind.Unspecified).AddTicks(4443), 14, null, 0 },
                    { 56, 10, new DateTime(2025, 8, 20, 16, 37, 32, 267, DateTimeKind.Unspecified).AddTicks(5808), 14, null, 0 },
                    { 57, 1, new DateTime(2025, 8, 20, 15, 32, 21, 582, DateTimeKind.Unspecified).AddTicks(9770), 14, null, 2 },
                    { 58, 4, new DateTime(2025, 5, 8, 8, 7, 44, 856, DateTimeKind.Unspecified).AddTicks(8096), 15, 74.751586175873680m, 1 },
                    { 59, 1, new DateTime(2025, 9, 11, 12, 50, 47, 65, DateTimeKind.Unspecified).AddTicks(9725), 15, null, 0 },
                    { 60, 6, new DateTime(2025, 9, 6, 0, 59, 31, 716, DateTimeKind.Unspecified).AddTicks(540), 15, null, 0 },
                    { 61, 7, new DateTime(2025, 4, 21, 8, 58, 53, 444, DateTimeKind.Unspecified).AddTicks(2706), 16, 73.655063367288120m, 1 },
                    { 62, 6, new DateTime(2025, 5, 11, 5, 49, 44, 346, DateTimeKind.Unspecified).AddTicks(9822), 16, 63.2177085816942640m, 1 },
                    { 63, 8, new DateTime(2025, 9, 1, 20, 15, 9, 64, DateTimeKind.Unspecified).AddTicks(5191), 16, null, 2 },
                    { 64, 10, new DateTime(2025, 8, 24, 22, 37, 3, 932, DateTimeKind.Unspecified).AddTicks(2788), 16, null, 0 },
                    { 65, 8, new DateTime(2025, 8, 25, 11, 15, 25, 968, DateTimeKind.Unspecified).AddTicks(1741), 17, null, 0 },
                    { 66, 1, new DateTime(2025, 9, 6, 20, 29, 50, 268, DateTimeKind.Unspecified).AddTicks(9935), 17, null, 2 },
                    { 67, 9, new DateTime(2025, 4, 22, 9, 52, 35, 515, DateTimeKind.Unspecified).AddTicks(9928), 17, 67.6628973743240m, 1 },
                    { 68, 6, new DateTime(2025, 8, 16, 15, 38, 19, 680, DateTimeKind.Unspecified).AddTicks(7733), 17, null, 0 },
                    { 69, 5, new DateTime(2025, 4, 15, 1, 55, 43, 64, DateTimeKind.Unspecified).AddTicks(3352), 17, 81.928577619571520m, 1 },
                    { 70, 10, new DateTime(2025, 5, 5, 11, 53, 1, 498, DateTimeKind.Unspecified).AddTicks(2867), 18, 64.974787665984960m, 1 },
                    { 71, 5, new DateTime(2025, 9, 3, 4, 43, 48, 418, DateTimeKind.Unspecified).AddTicks(2866), 18, null, 0 },
                    { 72, 8, new DateTime(2025, 8, 15, 20, 17, 53, 391, DateTimeKind.Unspecified).AddTicks(1273), 18, null, 2 },
                    { 73, 3, new DateTime(2025, 8, 18, 2, 32, 19, 630, DateTimeKind.Unspecified).AddTicks(8569), 18, null, 0 },
                    { 74, 10, new DateTime(2025, 8, 17, 22, 12, 40, 871, DateTimeKind.Unspecified).AddTicks(4551), 19, null, 0 },
                    { 75, 6, new DateTime(2025, 9, 1, 20, 18, 57, 570, DateTimeKind.Unspecified).AddTicks(2602), 19, null, 0 },
                    { 76, 5, new DateTime(2025, 9, 4, 2, 40, 4, 294, DateTimeKind.Unspecified).AddTicks(6413), 19, null, 0 },
                    { 77, 8, new DateTime(2025, 8, 20, 19, 45, 3, 940, DateTimeKind.Unspecified).AddTicks(6139), 19, null, 0 },
                    { 78, 3, new DateTime(2025, 9, 11, 13, 34, 28, 92, DateTimeKind.Unspecified).AddTicks(7147), 19, null, 2 },
                    { 79, 9, new DateTime(2025, 9, 11, 23, 23, 23, 433, DateTimeKind.Unspecified).AddTicks(4783), 20, null, 0 },
                    { 80, 4, new DateTime(2025, 5, 11, 17, 32, 8, 786, DateTimeKind.Unspecified).AddTicks(1611), 20, 77.809362028636680m, 1 },
                    { 81, 3, new DateTime(2025, 4, 26, 15, 20, 21, 790, DateTimeKind.Unspecified).AddTicks(4616), 20, 88.418741835476240m, 1 },
                    { 82, 6, new DateTime(2025, 9, 10, 11, 15, 11, 201, DateTimeKind.Unspecified).AddTicks(6077), 20, null, 2 },
                    { 83, 8, new DateTime(2025, 5, 12, 18, 52, 16, 545, DateTimeKind.Unspecified).AddTicks(1190), 20, 72.844287759086240m, 1 },
                    { 84, 5, new DateTime(2025, 5, 12, 1, 50, 46, 941, DateTimeKind.Unspecified).AddTicks(5398), 20, 91.98485804348480m, 1 },
                    { 85, 2, new DateTime(2025, 9, 1, 8, 52, 24, 3, DateTimeKind.Unspecified).AddTicks(3734), 21, null, 2 },
                    { 86, 5, new DateTime(2025, 8, 17, 4, 36, 26, 82, DateTimeKind.Unspecified).AddTicks(3634), 21, null, 2 },
                    { 87, 6, new DateTime(2025, 8, 23, 0, 14, 14, 880, DateTimeKind.Unspecified).AddTicks(3766), 21, null, 2 },
                    { 88, 9, new DateTime(2025, 9, 11, 13, 53, 26, 972, DateTimeKind.Unspecified).AddTicks(337), 22, null, 2 },
                    { 89, 10, new DateTime(2025, 9, 3, 9, 58, 44, 676, DateTimeKind.Unspecified).AddTicks(506), 22, null, 0 },
                    { 90, 1, new DateTime(2025, 4, 30, 20, 47, 31, 538, DateTimeKind.Unspecified).AddTicks(6349), 22, 62.7065700305190720m, 1 },
                    { 91, 5, new DateTime(2025, 9, 11, 13, 9, 16, 281, DateTimeKind.Unspecified).AddTicks(2400), 22, null, 0 },
                    { 92, 4, new DateTime(2025, 8, 20, 18, 47, 36, 839, DateTimeKind.Unspecified).AddTicks(1325), 22, null, 2 },
                    { 93, 2, new DateTime(2025, 5, 4, 0, 59, 44, 950, DateTimeKind.Unspecified).AddTicks(4622), 23, 88.549723768862760m, 1 },
                    { 94, 6, new DateTime(2025, 9, 4, 8, 4, 7, 367, DateTimeKind.Unspecified).AddTicks(9872), 23, null, 0 },
                    { 95, 3, new DateTime(2025, 9, 1, 8, 59, 38, 185, DateTimeKind.Unspecified).AddTicks(6092), 23, null, 2 },
                    { 96, 4, new DateTime(2025, 8, 27, 13, 29, 23, 424, DateTimeKind.Unspecified).AddTicks(4012), 23, null, 0 },
                    { 97, 10, new DateTime(2025, 9, 13, 6, 59, 55, 719, DateTimeKind.Unspecified).AddTicks(2732), 23, null, 0 },
                    { 98, 7, new DateTime(2025, 5, 11, 10, 26, 29, 761, DateTimeKind.Unspecified).AddTicks(4475), 24, 97.721217553001440m, 1 },
                    { 99, 5, new DateTime(2025, 9, 3, 6, 49, 5, 252, DateTimeKind.Unspecified).AddTicks(306), 24, null, 0 },
                    { 100, 9, new DateTime(2025, 5, 5, 1, 0, 3, 823, DateTimeKind.Unspecified).AddTicks(4638), 24, 79.799548620264760m, 1 },
                    { 101, 4, new DateTime(2025, 9, 8, 12, 3, 29, 424, DateTimeKind.Unspecified).AddTicks(6739), 24, null, 0 },
                    { 102, 3, new DateTime(2025, 5, 10, 22, 6, 25, 704, DateTimeKind.Unspecified).AddTicks(5500), 25, 87.066828416225880m, 1 },
                    { 103, 8, new DateTime(2025, 8, 18, 12, 16, 45, 250, DateTimeKind.Unspecified).AddTicks(96), 25, null, 2 },
                    { 104, 1, new DateTime(2025, 8, 22, 3, 33, 0, 974, DateTimeKind.Unspecified).AddTicks(931), 25, null, 2 },
                    { 105, 5, new DateTime(2025, 8, 17, 17, 38, 50, 886, DateTimeKind.Unspecified).AddTicks(9777), 26, null, 2 },
                    { 106, 3, new DateTime(2025, 9, 8, 6, 42, 2, 818, DateTimeKind.Unspecified).AddTicks(4738), 26, null, 0 },
                    { 107, 7, new DateTime(2025, 9, 12, 14, 58, 2, 875, DateTimeKind.Unspecified).AddTicks(1726), 26, null, 0 },
                    { 108, 10, new DateTime(2025, 9, 14, 12, 36, 48, 294, DateTimeKind.Unspecified).AddTicks(3398), 27, null, 0 },
                    { 109, 1, new DateTime(2025, 4, 30, 18, 32, 20, 2, DateTimeKind.Unspecified).AddTicks(210), 27, 77.927461908165120m, 1 },
                    { 110, 4, new DateTime(2025, 5, 10, 17, 58, 35, 240, DateTimeKind.Unspecified).AddTicks(4818), 27, 73.933427452078760m, 1 },
                    { 111, 2, new DateTime(2025, 8, 29, 15, 17, 40, 805, DateTimeKind.Unspecified).AddTicks(7383), 27, null, 0 },
                    { 112, 6, new DateTime(2025, 9, 6, 14, 58, 23, 280, DateTimeKind.Unspecified).AddTicks(508), 27, null, 0 },
                    { 113, 5, new DateTime(2025, 8, 26, 23, 51, 12, 275, DateTimeKind.Unspecified).AddTicks(2420), 28, null, 2 },
                    { 114, 7, new DateTime(2025, 9, 13, 3, 18, 38, 711, DateTimeKind.Unspecified).AddTicks(4190), 28, null, 0 },
                    { 115, 2, new DateTime(2025, 5, 9, 13, 51, 50, 321, DateTimeKind.Unspecified).AddTicks(9846), 28, 71.369034597356360m, 1 },
                    { 116, 4, new DateTime(2025, 8, 26, 1, 23, 8, 17, DateTimeKind.Unspecified).AddTicks(8072), 28, null, 2 },
                    { 117, 2, new DateTime(2025, 8, 16, 6, 2, 13, 14, DateTimeKind.Unspecified).AddTicks(8589), 29, null, 2 },
                    { 118, 8, new DateTime(2025, 9, 9, 9, 32, 9, 55, DateTimeKind.Unspecified).AddTicks(6561), 29, null, 0 },
                    { 119, 3, new DateTime(2025, 8, 29, 22, 47, 51, 234, DateTimeKind.Unspecified).AddTicks(2600), 29, null, 0 },
                    { 120, 10, new DateTime(2025, 8, 18, 0, 31, 50, 17, DateTimeKind.Unspecified).AddTicks(3214), 29, null, 0 },
                    { 121, 6, new DateTime(2025, 9, 11, 19, 18, 8, 859, DateTimeKind.Unspecified).AddTicks(898), 30, null, 0 },
                    { 122, 3, new DateTime(2025, 9, 5, 21, 44, 17, 275, DateTimeKind.Unspecified).AddTicks(5850), 30, null, 2 },
                    { 123, 4, new DateTime(2025, 5, 10, 13, 10, 44, 67, DateTimeKind.Unspecified).AddTicks(3662), 30, 61.0136892651271480m, 1 },
                    { 124, 8, new DateTime(2025, 9, 5, 13, 59, 12, 785, DateTimeKind.Unspecified).AddTicks(9699), 30, null, 2 },
                    { 125, 2, new DateTime(2025, 4, 30, 20, 26, 50, 976, DateTimeKind.Unspecified).AddTicks(5843), 30, 61.0920484555382520m, 1 },
                    { 126, 10, new DateTime(2025, 5, 4, 9, 13, 8, 15, DateTimeKind.Unspecified).AddTicks(935), 31, 94.784601812616280m, 1 },
                    { 127, 2, new DateTime(2025, 8, 27, 23, 24, 43, 857, DateTimeKind.Unspecified).AddTicks(7857), 31, null, 2 },
                    { 128, 9, new DateTime(2025, 9, 7, 8, 23, 35, 369, DateTimeKind.Unspecified).AddTicks(9405), 31, null, 2 },
                    { 129, 4, new DateTime(2025, 9, 9, 20, 28, 57, 869, DateTimeKind.Unspecified).AddTicks(1167), 31, null, 0 },
                    { 130, 3, new DateTime(2025, 4, 17, 11, 53, 34, 168, DateTimeKind.Unspecified).AddTicks(9202), 31, 96.369700318374520m, 1 },
                    { 131, 7, new DateTime(2025, 4, 23, 3, 50, 31, 820, DateTimeKind.Unspecified).AddTicks(3350), 31, 69.936090544767720m, 1 },
                    { 132, 4, new DateTime(2025, 8, 19, 23, 38, 37, 866, DateTimeKind.Unspecified).AddTicks(4589), 32, null, 2 },
                    { 133, 10, new DateTime(2025, 4, 15, 15, 8, 41, 450, DateTimeKind.Unspecified).AddTicks(3855), 32, 69.631431740537040m, 1 },
                    { 134, 6, new DateTime(2025, 5, 11, 4, 24, 37, 279, DateTimeKind.Unspecified).AddTicks(6496), 32, 65.912207293283280m, 1 },
                    { 135, 3, new DateTime(2025, 4, 16, 12, 31, 9, 260, DateTimeKind.Unspecified).AddTicks(4916), 32, 99.47232870360480m, 1 },
                    { 136, 9, new DateTime(2025, 8, 18, 21, 42, 57, 428, DateTimeKind.Unspecified).AddTicks(8244), 32, null, 0 },
                    { 137, 2, new DateTime(2025, 9, 13, 5, 35, 37, 416, DateTimeKind.Unspecified).AddTicks(294), 32, null, 0 },
                    { 138, 10, new DateTime(2025, 8, 28, 1, 40, 25, 579, DateTimeKind.Unspecified).AddTicks(7921), 33, null, 0 },
                    { 139, 7, new DateTime(2025, 4, 25, 12, 42, 38, 117, DateTimeKind.Unspecified).AddTicks(4274), 33, 93.197465312293480m, 1 },
                    { 140, 3, new DateTime(2025, 8, 19, 15, 8, 58, 400, DateTimeKind.Unspecified).AddTicks(421), 33, null, 0 },
                    { 141, 6, new DateTime(2025, 5, 2, 3, 33, 40, 127, DateTimeKind.Unspecified).AddTicks(8538), 33, 65.366176574195800m, 1 },
                    { 142, 1, new DateTime(2025, 5, 9, 5, 20, 16, 418, DateTimeKind.Unspecified).AddTicks(7312), 33, 93.588612598175480m, 1 },
                    { 143, 2, new DateTime(2025, 4, 16, 8, 53, 58, 609, DateTimeKind.Unspecified).AddTicks(9413), 34, 82.195692817771680m, 1 },
                    { 144, 9, new DateTime(2025, 4, 27, 6, 52, 8, 945, DateTimeKind.Unspecified).AddTicks(1804), 34, 98.478346745706320m, 1 },
                    { 145, 7, new DateTime(2025, 9, 2, 6, 41, 43, 188, DateTimeKind.Unspecified).AddTicks(6064), 34, null, 0 },
                    { 146, 3, new DateTime(2025, 8, 19, 21, 59, 2, 842, DateTimeKind.Unspecified).AddTicks(4980), 34, null, 0 },
                    { 147, 6, new DateTime(2025, 4, 29, 2, 44, 11, 699, DateTimeKind.Unspecified).AddTicks(8575), 34, 92.325616531225680m, 1 },
                    { 148, 1, new DateTime(2025, 5, 5, 14, 48, 18, 601, DateTimeKind.Unspecified).AddTicks(8980), 34, 93.496546146225440m, 1 },
                    { 149, 6, new DateTime(2025, 8, 22, 17, 40, 23, 946, DateTimeKind.Unspecified).AddTicks(1390), 35, null, 2 },
                    { 150, 2, new DateTime(2025, 8, 17, 11, 41, 21, 299, DateTimeKind.Unspecified).AddTicks(4691), 35, null, 2 },
                    { 151, 7, new DateTime(2025, 8, 15, 8, 9, 57, 17, DateTimeKind.Unspecified).AddTicks(7102), 35, null, 0 },
                    { 152, 5, new DateTime(2025, 8, 24, 23, 19, 5, 841, DateTimeKind.Unspecified).AddTicks(8760), 36, null, 2 },
                    { 153, 2, new DateTime(2025, 4, 24, 12, 37, 7, 137, DateTimeKind.Unspecified).AddTicks(459), 36, 74.650204262999000m, 1 },
                    { 154, 1, new DateTime(2025, 8, 19, 7, 8, 9, 128, DateTimeKind.Unspecified).AddTicks(3453), 36, null, 0 },
                    { 155, 9, new DateTime(2025, 9, 4, 14, 13, 44, 953, DateTimeKind.Unspecified).AddTicks(2774), 36, null, 0 },
                    { 156, 7, new DateTime(2025, 4, 23, 18, 18, 6, 247, DateTimeKind.Unspecified).AddTicks(8503), 37, 74.844183705208920m, 1 },
                    { 157, 10, new DateTime(2025, 4, 29, 5, 44, 2, 789, DateTimeKind.Unspecified).AddTicks(3496), 37, 72.462557411036720m, 1 },
                    { 158, 1, new DateTime(2025, 4, 22, 12, 43, 33, 920, DateTimeKind.Unspecified).AddTicks(9871), 37, 75.638228289614520m, 1 },
                    { 159, 5, new DateTime(2025, 9, 9, 16, 5, 10, 344, DateTimeKind.Unspecified).AddTicks(152), 38, null, 0 },
                    { 160, 2, new DateTime(2025, 9, 13, 11, 30, 8, 368, DateTimeKind.Unspecified).AddTicks(1761), 38, null, 2 },
                    { 161, 8, new DateTime(2025, 8, 22, 20, 57, 39, 558, DateTimeKind.Unspecified).AddTicks(4714), 38, null, 2 },
                    { 162, 3, new DateTime(2025, 5, 5, 21, 26, 8, 598, DateTimeKind.Unspecified).AddTicks(4077), 38, 94.532367416905400m, 1 },
                    { 163, 1, new DateTime(2025, 5, 2, 16, 16, 27, 922, DateTimeKind.Unspecified).AddTicks(9193), 38, 68.177072167479000m, 1 },
                    { 164, 7, new DateTime(2025, 8, 25, 12, 52, 16, 142, DateTimeKind.Unspecified).AddTicks(3753), 39, null, 2 },
                    { 165, 6, new DateTime(2025, 9, 11, 9, 0, 42, 631, DateTimeKind.Unspecified).AddTicks(9303), 39, null, 2 },
                    { 166, 10, new DateTime(2025, 8, 18, 12, 11, 22, 892, DateTimeKind.Unspecified).AddTicks(9167), 39, null, 0 },
                    { 167, 1, new DateTime(2025, 8, 18, 15, 6, 17, 57, DateTimeKind.Unspecified).AddTicks(5255), 39, null, 0 },
                    { 168, 4, new DateTime(2025, 9, 2, 23, 1, 9, 795, DateTimeKind.Unspecified).AddTicks(64), 40, null, 2 },
                    { 169, 7, new DateTime(2025, 8, 19, 6, 16, 13, 910, DateTimeKind.Unspecified).AddTicks(2782), 40, null, 0 },
                    { 170, 3, new DateTime(2025, 9, 7, 0, 1, 12, 391, DateTimeKind.Unspecified).AddTicks(8826), 40, null, 0 },
                    { 171, 8, new DateTime(2025, 9, 13, 22, 37, 2, 348, DateTimeKind.Unspecified).AddTicks(7428), 40, null, 0 },
                    { 172, 2, new DateTime(2025, 4, 16, 0, 24, 18, 563, DateTimeKind.Unspecified).AddTicks(5639), 40, 65.17252223807040m, 1 },
                    { 173, 7, new DateTime(2025, 8, 28, 21, 8, 59, 778, DateTimeKind.Unspecified).AddTicks(4796), 41, null, 2 },
                    { 174, 2, new DateTime(2025, 9, 7, 4, 15, 3, 778, DateTimeKind.Unspecified).AddTicks(5557), 41, null, 0 },
                    { 175, 9, new DateTime(2025, 8, 16, 14, 12, 30, 417, DateTimeKind.Unspecified).AddTicks(2504), 41, null, 0 },
                    { 176, 6, new DateTime(2025, 8, 26, 21, 40, 44, 845, DateTimeKind.Unspecified).AddTicks(7575), 41, null, 0 },
                    { 177, 8, new DateTime(2025, 9, 3, 22, 6, 41, 116, DateTimeKind.Unspecified).AddTicks(8180), 41, null, 2 },
                    { 178, 4, new DateTime(2025, 8, 28, 22, 19, 20, 587, DateTimeKind.Unspecified).AddTicks(3721), 41, null, 0 },
                    { 179, 8, new DateTime(2025, 5, 3, 11, 21, 11, 538, DateTimeKind.Unspecified).AddTicks(2975), 42, 67.978714056303120m, 1 },
                    { 180, 4, new DateTime(2025, 8, 21, 0, 34, 50, 633, DateTimeKind.Unspecified).AddTicks(1594), 42, null, 2 },
                    { 181, 6, new DateTime(2025, 9, 6, 14, 46, 15, 816, DateTimeKind.Unspecified).AddTicks(824), 42, null, 2 },
                    { 182, 1, new DateTime(2025, 8, 15, 19, 33, 51, 529, DateTimeKind.Unspecified).AddTicks(4549), 43, null, 2 },
                    { 183, 5, new DateTime(2025, 4, 25, 9, 23, 31, 135, DateTimeKind.Unspecified).AddTicks(1901), 43, 91.992701828476360m, 1 },
                    { 184, 4, new DateTime(2025, 5, 11, 10, 32, 32, 462, DateTimeKind.Unspecified).AddTicks(5985), 43, 76.345728699278880m, 1 },
                    { 185, 6, new DateTime(2025, 8, 19, 15, 17, 44, 289, DateTimeKind.Unspecified).AddTicks(6462), 43, null, 0 },
                    { 186, 6, new DateTime(2025, 8, 23, 14, 4, 11, 218, DateTimeKind.Unspecified).AddTicks(266), 44, null, 2 },
                    { 187, 9, new DateTime(2025, 4, 27, 8, 40, 50, 487, DateTimeKind.Unspecified).AddTicks(8830), 44, 83.761030595638320m, 1 },
                    { 188, 5, new DateTime(2025, 8, 24, 7, 26, 24, 512, DateTimeKind.Unspecified).AddTicks(9093), 44, null, 0 },
                    { 189, 6, new DateTime(2025, 8, 24, 17, 51, 42, 230, DateTimeKind.Unspecified).AddTicks(6116), 45, null, 2 },
                    { 190, 5, new DateTime(2025, 4, 29, 16, 24, 24, 94, DateTimeKind.Unspecified).AddTicks(4667), 45, 84.186374221083880m, 1 },
                    { 191, 9, new DateTime(2025, 4, 25, 1, 7, 8, 872, DateTimeKind.Unspecified).AddTicks(6974), 45, 62.7615221416398520m, 1 },
                    { 192, 8, new DateTime(2025, 4, 21, 7, 19, 27, 759, DateTimeKind.Unspecified).AddTicks(5470), 45, 60.21670870493012880m, 1 },
                    { 193, 1, new DateTime(2025, 8, 23, 23, 27, 39, 326, DateTimeKind.Unspecified).AddTicks(5986), 45, null, 0 },
                    { 194, 2, new DateTime(2025, 4, 19, 6, 46, 1, 827, DateTimeKind.Unspecified).AddTicks(9198), 45, 72.148518512094640m, 1 },
                    { 195, 10, new DateTime(2025, 9, 13, 1, 6, 17, 163, DateTimeKind.Unspecified).AddTicks(1408), 46, null, 0 },
                    { 196, 1, new DateTime(2025, 9, 2, 17, 21, 44, 806, DateTimeKind.Unspecified).AddTicks(2422), 46, null, 0 },
                    { 197, 4, new DateTime(2025, 8, 15, 10, 19, 7, 722, DateTimeKind.Unspecified).AddTicks(7667), 46, null, 2 },
                    { 198, 6, new DateTime(2025, 5, 6, 5, 0, 51, 541, DateTimeKind.Unspecified).AddTicks(820), 46, 74.455501890953400m, 1 },
                    { 199, 7, new DateTime(2025, 8, 15, 20, 50, 6, 663, DateTimeKind.Unspecified).AddTicks(1204), 46, null, 2 },
                    { 200, 10, new DateTime(2025, 9, 8, 20, 12, 33, 864, DateTimeKind.Unspecified).AddTicks(2745), 47, null, 0 },
                    { 201, 7, new DateTime(2025, 8, 28, 4, 52, 9, 454, DateTimeKind.Unspecified).AddTicks(6358), 47, null, 0 },
                    { 202, 1, new DateTime(2025, 4, 24, 12, 13, 11, 889, DateTimeKind.Unspecified).AddTicks(1069), 47, 89.180619488088720m, 1 },
                    { 203, 8, new DateTime(2025, 4, 30, 2, 41, 35, 936, DateTimeKind.Unspecified).AddTicks(674), 48, 65.757959524988160m, 1 },
                    { 204, 4, new DateTime(2025, 8, 23, 13, 7, 38, 136, DateTimeKind.Unspecified).AddTicks(4494), 48, null, 0 },
                    { 205, 10, new DateTime(2025, 9, 13, 13, 6, 7, 454, DateTimeKind.Unspecified).AddTicks(7043), 48, null, 2 },
                    { 206, 7, new DateTime(2025, 8, 17, 5, 12, 50, 133, DateTimeKind.Unspecified).AddTicks(809), 48, null, 2 },
                    { 207, 8, new DateTime(2025, 9, 1, 11, 29, 29, 660, DateTimeKind.Unspecified).AddTicks(9630), 49, null, 0 },
                    { 208, 5, new DateTime(2025, 9, 9, 1, 10, 59, 212, DateTimeKind.Unspecified).AddTicks(5063), 49, null, 2 },
                    { 209, 7, new DateTime(2025, 8, 16, 2, 56, 41, 39, DateTimeKind.Unspecified).AddTicks(4667), 49, null, 2 },
                    { 210, 2, new DateTime(2025, 8, 27, 7, 58, 54, 547, DateTimeKind.Unspecified).AddTicks(5152), 49, null, 2 },
                    { 211, 7, new DateTime(2025, 4, 29, 15, 46, 1, 999, DateTimeKind.Unspecified).AddTicks(9315), 50, 69.408927061319800m, 1 },
                    { 212, 10, new DateTime(2025, 9, 11, 0, 6, 45, 180, DateTimeKind.Unspecified).AddTicks(6228), 50, null, 0 },
                    { 213, 2, new DateTime(2025, 5, 12, 11, 45, 57, 6, DateTimeKind.Unspecified).AddTicks(7245), 50, 97.982612307175360m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnseignantId",
                table: "AspNetUsers",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EtudiantId",
                table: "AspNetUsers",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseignantId",
                table: "Cours",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_CoursId",
                table: "Inscriptions",
                column: "CoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EtudiantId",
                table: "Inscriptions",
                column: "EtudiantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Enseignants");
        }
    }
}
