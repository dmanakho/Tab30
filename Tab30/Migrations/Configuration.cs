namespace Tab30.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tab30.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Tab30.DAL.TabDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tab30.DAL.TabDBContext context)
        {

            //var locations = new List<Location>
            //            {
            //                new Location{ShortDescription="US",LongDescription="Upper School"},
            //                new Location{ShortDescription="MS",LongDescription="Middle School"},
            //                new Location{ShortDescription="AD",LongDescription="Administration Building"},
            //                new Location{ShortDescription="SEA",LongDescription="Sports and Education Annex"}
            //            };
            //locations.ForEach(t => context.Locations.AddOrUpdate(i => i.ShortDescription, t));
            //context.SaveChanges();

            //var tablets = new List<Tablet>
            //            {
            //                new Tablet{LocationID= 2, TabletName = "YS-DIMA-MONK",AssetTag = "C110110",SerialNo = "MP05YTHG",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4), ADPEnabled = true},
            //                new Tablet{TabletName = "YS-ERIC-MOORE",AssetTag = "C110111",SerialNo = "MP05YTDF",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4), ADPEnabled = true},
            //                new Tablet{TabletName = "YS-PETER-TODD",AssetTag = "C110112",SerialNo = "MP05YTTR",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4), ADPEnabled = true},
            //                new Tablet{TabletName = "YS-KRIS-LING",AssetTag = "C110113",SerialNo = "MP05YFGD",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4), ADPEnabled = true},
            //                new Tablet{TabletName = "YS-DEAN-SAULS",AssetTag = "C110114",SerialNo = "MP05YFHH",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4), ADPEnabled = true},
            //                new Tablet{TabletName = "YS-BIFF-BULLY",AssetTag = "C110119",SerialNo = "MP05YFLK",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Peter-Todd",AssetTag = "C110705",SerialNo = "5CG719005Q",LocationID= 2,Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Alicia-Morris",AssetTag = "C110699",SerialNo = "5CG71824D0", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Allison-McCoppin",AssetTag = "C110698",SerialNo = "5CG71824GR", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Allyson-Buie",AssetTag = "C110697",SerialNo = "5CG71825DZ", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Andrew-Chiaraviglio",AssetTag = "C110696",SerialNo = "5CG7182BKF", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Belinda-Blackwood",AssetTag = "C110694",SerialNo = "5CG718240H", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Betsy-MacDonald",AssetTag = "C110693",SerialNo = "5CG7182043", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Bill-Velto",AssetTag = "C110692",SerialNo = "5CG7181YMG", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Bonnie-Dodwell",AssetTag = "C110691",SerialNo = "5CG7181ZFC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Brandon-Carter",AssetTag = "C110689",SerialNo = "5CG7182386", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Brandon-Pope",AssetTag = "C110688",SerialNo = "5CG71823W2", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Cheryl-Cotter",AssetTag = "C110687",SerialNo = "5CG71824MQ", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Chris-Gilmore",AssetTag = "C110686",SerialNo = "5CG7181YV6", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Conrad-Hall",AssetTag = "C110685",SerialNo = "5CG71824S8", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Craig-Lazarski",AssetTag = "C110684",SerialNo = "5CG71823TW", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Danae-Shipp",AssetTag = "C110683",SerialNo = "5CG71823NV", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Darshana-Wani",AssetTag = "C110682",SerialNo = "5CG718259F", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-David-Snively",AssetTag = "C110681",SerialNo = "5CG7181YZ5", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Dawn-Smith",AssetTag = "C110680",SerialNo = "5CG71823SV", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Dean-Sauls",AssetTag = "C110679",SerialNo = "5CG718227X", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Debby-Reichel",AssetTag = "C110678",SerialNo = "5CG718200M", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-NAOMI-BARLAZ",AssetTag = "C110677",SerialNo = "5CG718242Z", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Delia-Follet",AssetTag = "C110676",SerialNo = "5CG71821HF", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Denise-Goodman",AssetTag = "C110675",SerialNo = "5CG7181YBN", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Dick-Mentock",AssetTag = "C110674",SerialNo = "5CG7181Y66", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Dima-Manakhov",AssetTag = "C110673",SerialNo = "5CG7182352", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Donna-Eason",AssetTag = "C110669",SerialNo = "5CG71824HV", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Dorrys-McArdle",AssetTag = "C110672",SerialNo = "5CG71824NV", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Ellen-Doyle",AssetTag = "C110671",SerialNo = "5CG7182053", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Ellen-Gooding",AssetTag = "C110670",SerialNo = "5CG71820YS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Emily-Turner",AssetTag = "C110668",SerialNo = "5CG7181YG8", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Eric-Grush",AssetTag = "C110667",SerialNo = "5CG71822Q3", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Eric-Moore",AssetTag = "C110666",SerialNo = "5CG71824L7", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Fred-Haas",AssetTag = "C110665",SerialNo = "5CG71824Q0", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Gabriele-Verhoeven",AssetTag = "C110664",SerialNo = "5CG718213M", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-German-Urioste",AssetTag = "C110663",SerialNo = "5CG718248W", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-SELANNA-SEGAL",AssetTag = "C110662",SerialNo = "5CG7181XPS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Gray-Rushin",AssetTag = "C110661",SerialNo = "5CG7181Y1P", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-7",AssetTag = "C110660",SerialNo = "5CG71824JM", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Heidi-Maloy",AssetTag = "C110659",SerialNo = "5CG7181Z8D", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Jason-Franklin",AssetTag = "C110658",SerialNo = "5CG718268L", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Jeff-Wacenske",AssetTag = "C110657",SerialNo = "5CG718245F", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Jess-Garcia",AssetTag = "C110656",SerialNo = "5CG7182445", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Laura-Price",AssetTag = "C110655",SerialNo = "5CG71824B1", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-John-Noland",AssetTag = "C110654",SerialNo = "5CG71822F3", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Joselyn-Todd",AssetTag = "C110653",SerialNo = "5CG71820VK", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kara-Caccuit",AssetTag = "C110652",SerialNo = "5CG718250V", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Karen-McKenzie",AssetTag = "C110651",SerialNo = "5CG71825GD", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kathleen-Mason",AssetTag = "C110650",SerialNo = "5CG71822WC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kathy-Riley",AssetTag = "C110649",SerialNo = "5CG7181Z0C", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Katie-Levinthal",AssetTag = "C110648",SerialNo = "5CG71824M1", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Katie-Taylor",AssetTag = "C110647",SerialNo = "5CG71822NC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Katy-Allen",AssetTag = "C110646",SerialNo = "5CG7181Y7H", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kelly-Cotronis",AssetTag = "C110645",SerialNo = "5CG7182538", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kelly-Wiebe",AssetTag = "C110644",SerialNo = "5CG71822SS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kevin-Jones",AssetTag = "C110643",SerialNo = "5CG7181YQS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kevin-Rokuskie",AssetTag = "C110642",SerialNo = "5CG7181XWW", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kimberly-Shaw",AssetTag = "C110641",SerialNo = "5CG7181Z6S", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kim-Fogleman",AssetTag = "C110640",SerialNo = "5CG71823Q3", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kristi-McGauley",AssetTag = "C110639",SerialNo = "5CG7181Z1T", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kristin-Lane",AssetTag = "C110638",SerialNo = "5CG7181ZS8", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Kristi-Sergent",AssetTag = "C110637",SerialNo = "5CG718226J", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-9",AssetTag = "C110636",SerialNo = "5CG71820P5", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Laura-Sellers",AssetTag = "C110635",SerialNo = "5CG718204G", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Laura-Werner",AssetTag = "C110634",SerialNo = "5CG71821ZL", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Leslie-Williams",AssetTag = "C110633",SerialNo = "5CG7182473", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Leya-Jones",AssetTag = "C110632",SerialNo = "5CG718251X", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Linda-Goodfriend",AssetTag = "C110631",SerialNo = "5CG718202P", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Linda-Velto",AssetTag = "C110630",SerialNo = "5CG718204W", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Liz-Smith",AssetTag = "C110629",SerialNo = "5CG7181YD8", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-1",AssetTag = "C110628",SerialNo = "5CG71823FK", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-10",AssetTag = "C110627",SerialNo = "5CG7182553", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-11",AssetTag = "C110626",SerialNo = "5CG71824V0", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-12",AssetTag = "C110625",SerialNo = "5CG71822K5", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-2",AssetTag = "C110624",SerialNo = "5CG7181ZNL", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-3",AssetTag = "C110623",SerialNo = "5CG7181XQQ", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-4",AssetTag = "C110622",SerialNo = "5CG71825KQ", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-5",AssetTag = "C110621",SerialNo = "5CG718215Z", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-6",AssetTag = "C110620",SerialNo = "5CG7181Z9P", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-HEATHER-CLAR",AssetTag = "C110619",SerialNo = "5CG7181ZJD", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-SHELTON-SHEP",AssetTag = "C110618",SerialNo = "5CG7181ZVM", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-KRIS-WETTERLING",AssetTag = "C110617",SerialNo = "5CG71825HK", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Longzhi-Lund",AssetTag = "C110616",SerialNo = "5CG71824ZS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Lucy-Dawson",AssetTag = "C110615",SerialNo = "5CG7181XLL", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Lynne-Fountain",AssetTag = "C110614",SerialNo = "5CG7182257", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Mali-Burnett",AssetTag = "C110613",SerialNo = "5CG71824T7", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Maret-Jones",AssetTag = "C110612",SerialNo = "5CG718222N", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Margo-Smith",AssetTag = "C110611",SerialNo = "5CG7181ZH5", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Marie-Spell",AssetTag = "C110610",SerialNo = "5CG71823GP", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Marlene-Sanchez",AssetTag = "C110609",SerialNo = "5CG7182335", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Marti-Jenkins",AssetTag = "C110608",SerialNo = "5CG71825BY", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Martina-Greene",AssetTag = "C110607",SerialNo = "5CG7181Z3C", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Matt-Greenwolfe",AssetTag = "C110606",SerialNo = "5CG7182299", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Matthew-RipleyMoffit",AssetTag = "C110605",SerialNo = "5CG7181YLC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Melanie-Bryant",AssetTag = "C110604",SerialNo = "5CG718219X", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Melissa-Davenport",AssetTag = "C110603",SerialNo = "5CG7181ZX4", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Meredith-Stewart",AssetTag = "C110602",SerialNo = "5CG71821C5", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Michael-Hayes",AssetTag = "C110601",SerialNo = "5CG7181YRS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Michael-McElreath",AssetTag = "C110600",SerialNo = "5CG718223X", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Michael-Raskevitz",AssetTag = "C110599",SerialNo = "5CG7181Y92", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Mina-Harris",AssetTag = "C110598",SerialNo = "5CG7181ZYQ", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Nicky-Allen",AssetTag = "C110597",SerialNo = "5CG71820S2", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Nuria-Lopez",AssetTag = "C110596",SerialNo = "5CG71821MM", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Paige-Meszaros",AssetTag = "C110595",SerialNo = "5CG71823YL", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Palmer-Seeley",AssetTag = "C110594",SerialNo = "5CG7181Z4Z", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Pam-Hoffman",AssetTag = "C110593",SerialNo = "5CG71825JS", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Pat-Martin",AssetTag = "C110592",SerialNo = "5CG7181ZWC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Rachel-Atay",AssetTag = "C110590",SerialNo = "5CG71822JC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Ray-Pope",AssetTag = "C110589",SerialNo = "5CG7181ZL3", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Rick-Harris",AssetTag = "C110588",SerialNo = "5CG718236T", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-RJ-Pellicciotta",AssetTag = "C110587",SerialNo = "5CG71823MC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Robin-Edelstein",AssetTag = "C110586",SerialNo = "5CG71822VN", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Robin-Follet",AssetTag = "C110585",SerialNo = "5CG71825LW", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Sam-Goeuriot",AssetTag = "C110584",SerialNo = "5CG71824KC", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Sara-Mizelle",AssetTag = "C110583",SerialNo = "5CG71821L6", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Sequenta-Blackman",AssetTag = "C110582",SerialNo = "5CG7181ZCV", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-AARON-YONTZ",AssetTag = "C110581",SerialNo = "5CG7181YJY", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Sharice-Chandler",AssetTag = "C110580",SerialNo = "5CG7181ZZM", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Shawn-Nix",AssetTag = "C110579",SerialNo = "5CG71820XD", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Sheila-Hall",AssetTag = "C110578",SerialNo = "5CG7181YNH", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-LOANER-8",AssetTag = "C110577",SerialNo = "5CG71821WT", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Stephanie-Dungan",AssetTag = "C110576",SerialNo = "5CG71820T5", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Sue-Sheets",AssetTag = "C110575",SerialNo = "5CG718211P", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Toye-Eskridge",AssetTag = "C110573",SerialNo = "5CG718201M", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Trish-Yu",AssetTag = "C110572",SerialNo = "5CG71823HZ", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Troy-Weaver",AssetTag = "C110571",SerialNo = "5CG718218G", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Tyler-Gaviria",AssetTag = "C110570",SerialNo = "5CG71823KB", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Vic-Quesadaher",AssetTag = "C110569",SerialNo = "5CG71821FY", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Yenisel-Solis",AssetTag = "C110568",SerialNo = "5CG718204P", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-FutureEmployee1",AssetTag = "C110567",SerialNo = "5CG7181XSY", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-FutureEmployee2",AssetTag = "C110566",SerialNo = "5CG7181ZTH", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-FutureEmployee3",AssetTag = "C110565",SerialNo = "5CG7182104", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Owen-Asplundh",AssetTag = "C110564",SerialNo = "5CG71821VR", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-Emily-Hawhee",AssetTag = "C110563",SerialNo = "5CG7181YPK", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-FREYA-KRIDLE",AssetTag = "C110591",SerialNo = "5CG718205D", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-MARISA-SCOVI",AssetTag = "C110562",SerialNo = "5CG71821JL", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
            //                new Tablet{TabletName = "HE-ROB-ASSADURI",AssetTag = "C110690",SerialNo = "5CG71824FG", LocationID= 2, Model = "X3U19AV",Make = "HP EliteBook x360 1030 G2",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)}

            //            };
            //tablets.ForEach(t => context.Tablets.AddOrUpdate(i => i.SerialNo, t));
            //context.SaveChanges();



            //var users = new List<User>
            //            {
            //                new User{ImportID = "VC564321", FirstName="Kris",LastName="Wetterling",UserName="kris_wetterling",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            //                new User{ImportID = "VC564322", FirstName="Alex",LastName="Manakhov",UserName="alex_manakhov", ClassOf=2024,CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            //                new User{ImportID = "VC564323", FirstName="Peter",LastName="Todd",UserName="peter_todd",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            //                new User{ImportID = "VC564324", FirstName="Dima",LastName="Monk",UserName="dima_monk", ClassOf = 2019,CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            //                new User{ImportID = "VC564325", FirstName="Eric",LastName="Moore",UserName="eric_moore", ClassOf = 2019,CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            //                new User{ImportID = "VC564326", FirstName="Dean",LastName="Sauls",UserName="dean_sauls", CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            //            };
            //users.ForEach(t => context.Users.AddOrUpdate(i => i.UserName, t));
            //context.SaveChanges();
            //var parts = new List<Part>
            //            {
            //                new Part{PartNo="04Y2620",Description="ThinkPad Yoga 12 Keyboard (Faculty and Student)", RefundRate = 0},
            //                new Part{PartNo="04X4058",Description="ThinkPad Yoga 256Gb SSD", RefundRate = 0},
            //                new Part{PartNo="45N0473",Description="ThinkPad Yoga AC Adapter (Scrap)", RefundRate = 0},
            //                new Part{PartNo="45N0300",Description="ThinkPad Yoga AC Adapter (Warrenty Return)", RefundRate = 0},
            //                new Part{PartNo="42T5008",Description="ThinkPad Yoga AC LINECORD US/CA,1M,2P,NON-LH,LGW", RefundRate = 0},
            //                new Part{PartNo="04X6452",Description="ThinkPad Yoga Antenna", RefundRate = 0},
            //                new Part{PartNo="45N1705",Description="ThinkPad Yoga Battery 14.8 V Li-ion", RefundRate = 0},
            //                new Part{PartNo="04X6444",Description="ThinkPad Yoga Bottom Base Cover Assembly", RefundRate = 0},
            //                new Part{PartNo="04X6440",Description="ThinkPad Yoga CPU Fan", RefundRate = 0},
            //                new Part{PartNo="04X6462",Description="ThinkPad Yoga Digitizer Cable", RefundRate = 0},
            //                new Part{PartNo="04X6463",Description="ThinkPad Yoga HDD and Button Subcard Cable", RefundRate = 0},
            //                new Part{PartNo="04X6441",Description="ThinkPad Yoga HDD Subcard", RefundRate = 0},
            //                new Part{PartNo="04X6483",Description="ThinkPad Yoga Hinge", RefundRate = 0},
            //                new Part{PartNo="04X6459",Description="ThinkPad Yoga LCD Cable ASM", RefundRate = 0},
            //                new Part{PartNo="04X6467",Description="ThinkPad Yoga LCD Misc Kit", RefundRate = 0},
            //                new Part{PartNo="04X6457",Description="ThinkPad Yoga LCD Windows Button Bezel", RefundRate = 0},
            //                new Part{PartNo="04X5236",Description="ThinkPad Yoga motherboard", RefundRate = 0},
            //                new Part{PartNo="04X6454",Description="ThinkPad Yoga P-Sensor", RefundRate = 0},
            //                new Part{PartNo="04X6448",Description="ThinkPad Yoga Rear (Display) Cover", RefundRate = 0},
            //                new Part{PartNo="1AW571",Description="ThinkPad Yoga Rubber Feet (qt4)", RefundRate = 0},
            //                new Part{PartNo="04X6465",Description="ThinkPad Yoga Sensor", RefundRate = 0},
            //                new Part{PartNo="04x6443",Description="ThinkPad Yoga Speakers", RefundRate = 0},
            //                new Part{PartNo="04X6468",Description="ThinkPad Yoga Stylus", RefundRate = 0},
            //                new Part{PartNo="04X6466",Description="ThinkPad Yoga System Misc Kit", RefundRate = 0},
            //                new Part{PartNo="00HM067",Description="ThinkPad Yoga TouchPad/KB Bezel", RefundRate = 0},
            //                new Part{PartNo="04X6011",Description="ThinkPad Yoga Wireless Card", RefundRate = 0},
            //                new Part{PartNo="710412-001",Description="HP EliteBook AC Adapter", RefundRate = 0},
            //                new Part{PartNo="213349-001",Description="HP EliteBook Power Cord", RefundRate = 0},
            //                new Part{PartNo="846410-001",Description="HP EliteBook Stylus", RefundRate = 0},
            //                new Part{PartNo="00PA847",Description="Yoga 12 Keyboard", RefundRate = 0},
            //                new Part{PartNo="00HT705",Description="YOGA 12 Motherboard - BDPLANAR WIN,i5-5200U,INT,TPM,8G", RefundRate = 0},
            //                new Part{PartNo="00HW027",Description="Yoga 260 Battery", RefundRate = 0},
            //                new Part{PartNo="00UP940",Description="ThinkPad Yoga Display", RefundRate = 0}
            //            };
            //parts.ForEach(t => context.Parts.AddOrUpdate(i => i.PartNo, t));
            ////parts.ForEach(t => context.Parts.Add(t));
            //context.SaveChanges();

            //var problems = new List<ProblemArea>
            //            {
            //                new ProblemArea{Description = "Display"},
            //                new ProblemArea{Description = "Keyboard"},
            //                new ProblemArea{Description = "TrackPoint/TrackPad"},
            //                new ProblemArea{Description = "Touch Screen"},
            //                new ProblemArea{Description = "Keyboard Bezel"},
            //                new ProblemArea{Description = "Bottom Cover"},
            //                new ProblemArea{Description = "Display Cover"},
            //                new ProblemArea{Description = "Motherboard"},
            //                new ProblemArea{Description = "Stylus Input"}

            //            };
            ////problems.ForEach(t => context.ProblemAreas.Add(t));
            //problems.ForEach(t => context.ProblemAreas.AddOrUpdate(p => p.Description, t));
            //context.SaveChanges();

            //var repairTypes = new List<RepairType>
            //            {
            //                new RepairType{Description = "Warranty"},
            //                new RepairType{Description = "Out of Warranty"},
            //                new RepairType{Description = "ADP"},
            //                new RepairType{Description = "Not Covered"},
            //                new RepairType{Description = "Declined"}
            //            };
            ////repairTypes.ForEach(t => context.RepairTypes.Add(t));
            //repairTypes.ForEach(t => context.RepairTypes.AddOrUpdate(p => p.Description, t));
            //context.SaveChanges();

        }
    }
}
