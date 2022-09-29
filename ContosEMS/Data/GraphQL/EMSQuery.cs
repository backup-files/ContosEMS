using ContosEMS.Data.Entities;
using ContosEMS.Data.GraphQL.Types;
using ContosEMS.Repositories;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL
{
    public class EMSQuery: ObjectGraphType
    {
        public EMSQuery(
            EquipmentRepository equipmentRepository, 
            NotificationRepository notificationRepository,
            PlantAdminRepository plantAdminRepository,
            TechnicianRepository technicianRepository)
        {
            base.Field<ListGraphType<EquipmentType>>("all", resolve: context => {
                return equipmentRepository.All();
            });

            base.Field<ListGraphType<EquipmentType>>("allEquipments", resolve: context =>
            {
                return equipmentRepository.AllEquipments();
            });

            base.Field<ListGraphType<EquipmentType>>("allLocations", resolve: context =>
            {
                return equipmentRepository.AllLocations();
            });

            base.Field<EquipmentType>(
                "equipmentById",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return equipmentRepository.GetEquipmentById(id);
                }
            );

            base.Field<ListGraphType<EquipmentType>>(
                "equipmentsByManufacturer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "manufacturer" }),
                resolve: context =>
                {
                    var manufacturer = context.GetArgument<string>("manufacturer");
                    Console.WriteLine(manufacturer);
                    return equipmentRepository.GetEquipmentByManufacturer(manufacturer);
                }
            );

            //base.Field<NotificationType>(
            //    "equipmentsDueThisMonth",
            //    resolve: context =>
            //    {
            //        return equipmentRepository.GetEquipmentsDueThisMonth();
            //    }
            //);

            base.Field<ListGraphType<NotificationType>>("allNotifications", resolve: context => {
                return notificationRepository.AllNotifications();
            });

            base.Field<ListGraphType<NotificationType>>("allActiveNotifications", resolve: context => {
                return notificationRepository.AllActiveNotifications();
            });
            
            base.Field<ListGraphType<NotificationType>>("allDismissedNotifications", resolve: context => {
                return notificationRepository.AllDismissedNotifications();
            });

            base.Field<ListGraphType<NotificationType>>("allCompletedNotifications", resolve: context => {
                return notificationRepository.AllCompletedNotifications();
            });

            base.Field<TechnicianType>("getTechnicianByEmail",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return technicianRepository.GetTechnicianByEmail(email);
                }
            );

            base.Field<PlantAdminType>("getPlantAdminByEmail",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return plantAdminRepository.GetPlantAdminByEmail(email);
                }
            );

            base.Field<StringGraphType>("isTechnicianLoggedIn",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return UserManager.IsLoggedIn[email];
                }
            );

            base.Field<StringGraphType>("isPlantAdminLoggedIn",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return UserManager.IsAdminLoggedIn[email];
                }
            );
        }
    }
}
