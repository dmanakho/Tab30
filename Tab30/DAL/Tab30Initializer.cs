using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tab30.Models;

namespace Tab30.DAL
{
    public class Tab30Initializer : DropCreateDatabaseIfModelChanges<TabDBContext>
    {
        protected override void Seed(TabDBContext context)
        {
            var tablets = new List<Tablet>
            {
                new Tablet{TabletName = "YS-DIMA-MONK",AssetTag = "C110110",SerialNo = "MP05YTHG",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
                new Tablet{TabletName = "YS-ERIC-MOORE",AssetTag = "C110111",SerialNo = "MP05YTDF",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
                new Tablet{TabletName = "YS-PETER-TODD",AssetTag = "C110112",SerialNo = "MP05YTTR",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
                new Tablet{TabletName = "YS-KRIS-LING",AssetTag = "C110113",SerialNo = "MP05YFGD",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4)},
                new Tablet{TabletName = "YS-DEAN-SAULS",AssetTag = "C110114",SerialNo = "MP05YFHH",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now, WarrantyExpiresOn = DateTime.Today.AddYears(4) }
            };

            tablets.ForEach(t => context.Tablets.Add(t));
            context.SaveChanges();

            var locations = new List<Location>
            {
                new Location{ShortDescription="US",LongDescription="Upper School"},
                new Location{ShortDescription="MS",LongDescription="Middle School"},
                new Location{ShortDescription="AD",LongDescription="Administration Building"},
                new Location{ShortDescription="SEA",LongDescription="Sports and Education Annex"}
            };
            locations.ForEach(t => context.Locations.Add(t));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{FirstName="Kris",LastName="Wetterling",UserName="kris_wetterling",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
                new User{FirstName="Alex",LastName="Manakhov",UserName="alex_manakhov", ClassOf=2024,CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
                new User{FirstName="Peter",LastName="Todd",UserName="peter_todd",CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
                new User{FirstName="Dima",LastName="Monk",UserName="dima_monk", ClassOf = 2019,CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
                new User{FirstName="Eric",LastName="Moore",UserName="eric_moore", ClassOf = 2019,CreatedOn = DateTime.Now,UpdatedOn = DateTime.Now},
            };
            users.ForEach(t => context.Users.Add(t));
            context.SaveChanges();
            var parts = new List<Part>
            {
                new Part{PartNo="04Y2620",Description="ThinkPad Yoga 12 Keyboard (Faculty and Student)", RefundRate = 0},
                new Part{PartNo="04X4058",Description="ThinkPad Yoga 256Gb SSD", RefundRate = 0},
                new Part{PartNo="45N0473",Description="ThinkPad Yoga AC Adapter (Scrap)", RefundRate = 0},
                new Part{PartNo="45N0300",Description="ThinkPad Yoga AC Adapter (Warrenty Return)", RefundRate = 0},
                new Part{PartNo="42T5008",Description="ThinkPad Yoga AC LINECORD US/CA,1M,2P,NON-LH,LGW", RefundRate = 0},
                new Part{PartNo="04X6452",Description="ThinkPad Yoga Antenna", RefundRate = 0},
                new Part{PartNo="45N1705",Description="ThinkPad Yoga Battery 14.8 V Li-ion", RefundRate = 0},
                new Part{PartNo="04X6444",Description="ThinkPad Yoga Bottom Base Cover Assembly", RefundRate = 0},
                new Part{PartNo="04X6440",Description="ThinkPad Yoga CPU Fan", RefundRate = 0},
                new Part{PartNo="04X6462",Description="ThinkPad Yoga Digitizer Cable", RefundRate = 0},
                new Part{PartNo="04X6463",Description="ThinkPad Yoga HDD and Button Subcard Cable", RefundRate = 0},
                new Part{PartNo="04X6441",Description="ThinkPad Yoga HDD Subcard", RefundRate = 0},
                new Part{PartNo="04X6483",Description="ThinkPad Yoga Hinge", RefundRate = 0},
                new Part{PartNo="04X6459",Description="ThinkPad Yoga LCD Cable ASM", RefundRate = 0},
                new Part{PartNo="04X6467",Description="ThinkPad Yoga LCD Misc Kit", RefundRate = 0},
                new Part{PartNo="04X6457",Description="ThinkPad Yoga LCD Windows Button Bezel", RefundRate = 0},
                new Part{PartNo="04X5236",Description="ThinkPad Yoga motherboard", RefundRate = 0},
                new Part{PartNo="04X6454",Description="ThinkPad Yoga P-Sensor", RefundRate = 0},
                new Part{PartNo="04X6448",Description="ThinkPad Yoga Rear (Display) Cover", RefundRate = 0},
                new Part{PartNo="1AW571",Description="ThinkPad Yoga Rubber Feet (qt4)", RefundRate = 0},
                new Part{PartNo="04X6465",Description="ThinkPad Yoga Sensor", RefundRate = 0},
                new Part{PartNo="04x6443",Description="ThinkPad Yoga Speakers", RefundRate = 0},
                new Part{PartNo="04X6468",Description="ThinkPad Yoga Stylus", RefundRate = 0},
                new Part{PartNo="04X6466",Description="ThinkPad Yoga System Misc Kit", RefundRate = 0},
                new Part{PartNo="00HM067",Description="ThinkPad Yoga TouchPad/KB Bezel", RefundRate = 0},
                new Part{PartNo="04X6011",Description="ThinkPad Yoga Wireless Card", RefundRate = 0},
                new Part{PartNo="710412-001",Description="HP EliteBook AC Adapter", RefundRate = 0},
                new Part{PartNo="213349-001",Description="HP EliteBook Power Cord", RefundRate = 0},
                new Part{PartNo="846410-001",Description="HP EliteBook Stylus", RefundRate = 0},
                new Part{PartNo="00PA847",Description="Yoga 12 Keyboard", RefundRate = 0},
                new Part{PartNo="00HT705",Description="YOGA 12 Motherboard - BDPLANAR WIN,i5-5200U,INT,TPM,8G", RefundRate = 0},
                new Part{PartNo="00HW027",Description="Yoga 260 Battery", RefundRate = 0},
                new Part{PartNo="00UP940",Description="ThinkPad Yoga Display", RefundRate = 0}
            };
            parts.ForEach(t => context.Parts.Add(t));
            context.SaveChanges();
        }

    }
}