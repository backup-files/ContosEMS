using ContosEMS.Data.Entities;
using System;
using System.Linq;

namespace ContosEMS.Data
{
    public static class InitializeData
    {
        public static void Seed(this EMSDbContext context)
        {
            if (!context.Equipments.Any())
            {
                AddEquipments(context);
            }

            if(!context.Technicians.Any())
            {
                AddTechnicians(context);
            }

            if (!context.PlantAdmins.Any())
            {
                AddPlantAdmins(context);
            }

            if (!context.Notifications.Any())
            {
                AddNotifications(context);
            }

            context.SaveChanges();
        }

        private static void AddNotifications(EMSDbContext context)
        {
            context.Notifications.Add(new Notification
            {
                TechnicianEmail = "angalineshyan@gmail.com",
                EquipmentId = 01,
                Title = "Increase Temperature",
                Severity = 3,
                Comments = "The temperature of equipment is exceeding the limit",
                Timestamp = DateTime.Now.ToString(),
                Status = "active"
            });
            context.Notifications.Add(new Notification
            {
                TechnicianEmail = "kartiksharma35@gmail.com",
                EquipmentId = 01,
                Title = "Equipment Not Working",
                Severity = 2,
                Comments = "The equipment is not working properly",
                Timestamp = DateTime.Now.ToString(),
                Status = "active"
            });
            context.Notifications.Add(new Notification
            {
                TechnicianEmail = "kartiksharma35@gmail.com",
                EquipmentId = 01,
                Title = "DOC generator Demo",
                Severity = 4,
                Comments = "Generator running on low power",
                Timestamp = DateTime.Now.ToString(),
                Status = "completed"
            });

            context.Notifications.Add(new Notification
            {
                TechnicianEmail = "angalineshyan@gmail.com",
                EquipmentId = 01,
                Title = "Leak in Pipe stoppers",
                Severity = 4,
                Comments = "Oil leak near pipe stoppers. Immediate action required.",
                Timestamp = DateTime.Now.ToString(),
                Status = "completed"
            });

            context.Notifications.Add(new Notification
            {
                TechnicianEmail = "josephroy23@gmail.com",
                EquipmentId = 01,
                Title = "Boiler UPS A1",
                Severity = 2,
                Comments = "Communication Error- Communication with the device has failed",
                Timestamp = DateTime.Now.ToString(),
                Status = "dismissed"
            });

            context.Notifications.Add(new Notification
            {
                TechnicianEmail = "anygoyal28@gmail.com",
                EquipmentId = 01,
                Title = "Gas Compressor Pressure",
                Severity = 1,
                Comments = "Pressure in Gas Compressor is decreasing slowly. Increase the pressure of the compressor",
                Timestamp = DateTime.Now.ToString(),
                Status = "dismissed"
            });
        }

        private static void AddPlantAdmins(EMSDbContext context)
        {
            context.PlantAdmins.Add(new PlantAdmin
            {
                Email = "mackKol21@gmail.com",
                HashedPassword = "kol1234#",
                Name = "Mack Kol"
            });
        }

        private static void AddTechnicians(EMSDbContext context)
        {
            context.Technicians.Add(new Technician
            {
                Email = "kartiksharma35@gmail.com",
                HashedPassword = "kar1234#",
                Name = "Kartik Sharma"
            });
            context.Technicians.Add(new Technician
            {
                Email = "josephroy23@gmail.com",
                HashedPassword = "jos1234#",
                Name = "Joseph Roy"
            });
            context.Technicians.Add(new Technician
            {
                Email = "angalineshyan@gmail.com",
                HashedPassword = "anj1234#",
                Name = "Angaline Shyan"
            });
            context.Technicians.Add(new Technician
            {
                Email = "anygoyal28@gmail.com",
                HashedPassword = "anu1234#",
                Name = "Anu Goyal"
            });
        }

        private static void AddEquipments(EMSDbContext context)
        {
            context.Equipments.Add(new Equipment
            {
                Name = "Solar Generator",
                Description = "Diesel or petrol generators tend to be quite noisy and are generally expensive to run, which makes them a poor choice " +
                "for camping or other outdoor activities. The Goal Zero Solar Generator, however, can be connected to a compatible solar panel and charged by the sun.",
                InstalledDate = "01-01-2022",
                ServiceDueDate = "01-10-2022",
                Manufacturer = "Jackery",
                Model = "SL-15",
                Temperature = 40.5M,
                AngularVelocity = 1000.0M,
                Pressure = 1.2M,
                Type = "equipment",
                ImageLink = "https://i5.walmartimages.com/asr/c01e742f-b8b1-42ec-9e23-20cd8be98b69.d39fcf0710e28881d5c1cdd7acbba0e9.jpeg?odnWidth=1000&odnHeight=1000&odnBg=ffffff"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "CBD Hemp Oil Extraction",
                Description = "BB series centrifuge is top discharging, hermetic closure type equipment. The dry material dip in ethanol, and then use centrifuge for dewatering. " +
                "The working temperature is very low, around -40~-80, to prevent the ethanol from volatilization. The installation requires no foundation.",
                InstalledDate = "10-05-2022",
                ServiceDueDate = "10-05-2023",
                Manufacturer = "Peony",
                Model = "CB-24",
                Temperature = 54M,
                AngularVelocity = 700.0M,
                Pressure = 0.9M,
                Type = "equipment",
                ImageLink = "https://www.separator-centrifuge.com/photo/pl31097818-top_discharge_industrial_basket_centrifuge_hemp_oil_extraction_machine.jpg"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "Activepowerclean - Self-cleaning Heat Exchanger",
                Description = "The self-cleaning Activepowerclean heat exchanger reduces scaling and blocking of pipes already during the evaporation process." +
                " Inside the heat exchanger there are small ceramic balls, the so called Activepowerclean grinding balls. " +
                "Due to high flow rates inside the heat exchanger pipes those grinding balls are circulated, reducing scaling reliably.",
                InstalledDate = "11-02-2020",
                ServiceDueDate = "01-06-2023",
                Manufacturer = "Vacudest",
                Model = "AP-25",
                Temperature = 510M,
                AngularVelocity = 900.0M,
                Pressure = 1.0M,
                Type = "location",
                ImageLink = "https://www.athco-engineering.dk/wp-content/uploads/2020/03/therm-x-3-600x435.jpg"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "Steam Boiler",
                Description = "The steam boiler CSBs low emissions already comply with future requirements of the MCP Directive (EU) 2015/2193. - Available in six output " +
                "sizes, from 300 to 5,200 kg/h for pressures ranging between 0.5 and 16 bar - High efficiency rating of up to 95.3% with integrated economiser and helical" +
                " heat exchanger tubes - Versatile design for use with different fuel types ",
                InstalledDate = "08-04-2022",
                ServiceDueDate = "17-11-2023",
                Manufacturer = "Bosch",
                Model = "SB-08",
                Temperature = 98M,
                AngularVelocity = 1100M,
                Pressure = 1.5M,
                Type = "equipment",
                ImageLink = "https://www.filter.eu/images/references/AO251477_X.jpg"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "AC/DC Modular Power Supplies",
                Description = "High Efficiency, High Reliability, Modular-Configurable Power Supplies. Advanced Energy's Excelsys UltiMod AC/DC modular power supplies " +
                "combine high reliability, efficiency, and user flexibility to provide low-total-cost solutions for medical, life science, and industrial applications ",
                InstalledDate = "18-04-2022",
                ServiceDueDate = "26-01-2023",
                Manufacturer = "UltiMod",
                Model = "MP-03",
                Temperature = 60M,
                AngularVelocity = 920M,
                Pressure = 1.2M,
                Type = "location",
                ImageLink = "https://www.heliosps.co.nz/wp-content/uploads/sites/3/2018/06/iHP12.png"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "Screw Compressor",
                Description = "The biogas compressor series VMX is an oil-injected screw compressor in 5 sizes for volume flows up to 3080 m³/h and 13 bar overpressure." +
                " It  is suitable for boosting the intake pressure of treatment plants for biogas (BGTP) or as an essential part of biogas injection plants (BGIP) for the " +
                "compression of biomethane to inject into gas grids. ",
                InstalledDate = "11-03-2021",
                ServiceDueDate = "15-02-2022",
                Manufacturer = "Arezen",
                Model = "SC-07",
                Temperature = 30M,
                AngularVelocity = 970.0M,
                Pressure = 1.01M,
                Type = "equipment",
                ImageLink = "https://www.howden.com/Howden/media/Howden/img/products/m127screwcompressor.jpg"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "Coal Pulverised Thermowells",
                Description = "The MVD Process is normally applied to the insertion portion of the Thermowell." +
                " When applied, the significant increase in wear life is achieved without sacrificing the corrosion or temperature features of the thermowell material.",
                InstalledDate = "04-06-2020",
                ServiceDueDate = "10-12-2022",
                Manufacturer = "Crozen",
                Model = "TTEC",
                Temperature = 80M,
                AngularVelocity = 700M,
                Pressure = 1.4M,
                Type = "location",
                ImageLink = "https://th.bing.com/th/id/R.2cd0c41c7726bcb4cd83248e7d084ed0?rik=6BLU%2ftzlb61lNg&riu=http%3a%2f%2fthermocouples.tteconline.com%2fAsset%2fMVD--11-.JPG&ehk=AnmzGhtUAakTp7D4zktzdT3j9TDvKYUgVLNeotX3rpE%3d&risl=&pid=ImgRaw&r=0"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "Brake Calliper",
                Description = "The Hilliard M400SH brake caliper is a spring applied, hydraulically released brake for use in heavy duty industrial applications." +
                " The brake comes standard with marine grade epoxy paint suitable for outdoor environments." +
                " The M400SH is available with standard force ratings which when paired with the correct disc size produces an exact braking torque for the application. The caliper features 'Maintenance Mode' which removes all stored spring energy within the cylinder assembly. This allows for brake pad replacement, monitor unit adjustment and seal replacement without the need to remove the brake from service.",
                InstalledDate = "07-11-2020",
                ServiceDueDate = "08-10-2022",
                Manufacturer = "Hilliard",
                Model = "M400SH",
                Temperature = 54M,
                AngularVelocity = 1020.0M,
                Pressure = 2M,
                Type = "equipment",
                ImageLink = "https://joredabe.com/wp-content/uploads/2020/08/a400.jpg"
            });
            context.Equipments.Add(new Equipment
            {
                Name = "Phoenix Fusion Machine",
                Description = "Propane/Natural Gas Phoenix VFD 4000. Produces 4 Beads Simultaneously. Automatic Swirling, Pouring & Cooling. Individual Mold Timer; 2 Stage Variable Cooling Rate. Reset Anytime. Mold Holders Included Refurbished to exact standards as a new current model." +
                " PREMIER Certified Refurbished Equipment (PCRE) carries the same warranty as new system (12 months) and includes 10 k of flux.",
                InstalledDate = "24-05-2022",
                ServiceDueDate = "24-05-2023",
                Manufacturer = "M-Refurbished",
                Model = "4000",
                Temperature = 60M,
                AngularVelocity = 500.0M,
                Pressure = 1.0M,
                Type = "equipment",
                ImageLink = "https://www.azom.com/images/slideshows/Equipment/5842/1.jpg?width=618&height=352"
            });
            context.Equipments.Add(new Equipment
            {
                Name = " Oil Gas Pipe Stoppers",
                Description = "Inflatable oil gas stoppers are produced to be used in the petrochemical industry, oil, gas, petroleum, fuel and all other chemical industry pipelines, they are derived from the basic pipe stoppers unlike material type, difference is in their surface layer that is made from oil and gas resistant material, their material has high resistant the oil and gas.",
                InstalledDate = "10-04-2022",
                ServiceDueDate = "19-05-2023",
                Manufacturer = "Plugline",
                Model = "PS-08",
                Temperature = 20M,
                AngularVelocity = 300.0M,
                Pressure = 0.8M,
                Type = "equipment",
                ImageLink = "https://www.zoro.com/static/cms/product/large/Z-vs-vjcpIx_.JPG"
            });
            context.Equipments.Add(new Equipment
            {
                Name = " Navigator - Model II - Digital Matching Networks",
                Description = "The Navigator® ll is equipped with microprocessor-controlled, stepper-motor drives, " +
                "and advanced tuning algorithms — enabling optimized RF power. An optional internal Z’Scan® II RF sensor " +
                "provides real-time analysis of process power and impedance — allowing you to quickly identify and significantly reduce process variability.",
                InstalledDate = "04-03-2019",
                ServiceDueDate = "04-06-2022",
                Manufacturer = "RF Match Networks",
                Model = "MODEL II",
                Temperature = 71M,
                AngularVelocity = 350.07M,
                Pressure = 1.9M,
                Type = "location",
                ImageLink = "https://www.seikigt.com.sg/wp-content/uploads/2021/02/MATCH-AE-Navigator-II-480x438.jpg"
            });

            context.Equipments.Add(new Equipment
            {
                Name = "Inciner8 - General Incinerator",
                Description = "I8-250G model is the first of our larger format models. " +
                "It has the internal capacity to handle larger single items that can be easily loaded via its " +
                "wide primary chamber door. The model features a high capacity primary chamber and is capable of " +
                "large continuous burn cycles that can be used for a variety of applications. ",
                InstalledDate = "01-01-2021",
                ServiceDueDate = "31-12-2022",
                Manufacturer = "Incinerators - General",
                Model = "Model I8-250G",
                Temperature = 92M,
                AngularVelocity = 220.25M,
                Pressure = 0.8M,
                Type = "equipment",
                ImageLink = "https://img.agriexpo.online/images_ag/photo-m2/181156-11358816.jpg"
            });



        }
    }
}
