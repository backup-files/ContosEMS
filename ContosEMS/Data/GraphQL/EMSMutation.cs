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
    public class EMSMutation: ObjectGraphType
    {
        public EMSMutation(
            EquipmentRepository equipmentRepository,
            NotificationRepository notificationRepository,
            PlantAdminRepository plantAdminRepository,
            TechnicianRepository technicianRepository
        )
        {
            base.Field<StringGraphType>(
                "addEquipment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EquipmentInputType>> { Name = "equipment" }
                ),
                resolve: context =>
                {
                    var equipment = context.GetArgument<Equipment>("equipment");
                    return equipmentRepository.AddEquipment(equipment);
                }
            );

            base.Field<StringGraphType>(
                "updateEquipment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EquipmentInputType>> { Name = "equipment" }
                ),
                resolve: context =>
                {
                    var equipment = context.GetArgument<Equipment>("equipment");
                    return equipmentRepository.UpdateEquipment(equipment);
                }
            );

            base.Field<StringGraphType>(
                "deleteEquipment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "equipmentId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("equipmentId");
                    return equipmentRepository.DeleteEquipment(id);
                }
            );

            base.Field<StringGraphType>(
                "dismissNotification",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "notificationId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("notificationId");
                    return notificationRepository.DismissNotification(id);
                }
            );

            base.Field<StringGraphType>(
                "completeNotification",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "notificationId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("notificationId");
                    return notificationRepository.CompleteNotification(id);
                }
            );

            base.Field<StringGraphType>(
                "raiseNotification",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<NotificationInputType>> { Name = "notification" }
                ),
                resolve: context =>
                {
                    var notification = context.GetArgument<Notification>("notification");
                    return notificationRepository.RaiseNotification(notification);
                }
            );

            base.Field<StringGraphType>(
                "registerTechnician",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TechnicianInputType>> { Name = "technician" }
                ),
                resolve: context =>
                {
                    var technician = context.GetArgument<Technician>("technician");
                    return technicianRepository.RegisterTechnician(technician);
                }
            );

            base.Field<StringGraphType>(
                "registerPlantAdmin",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlantAdminInputType>> { Name = "plantAdmin" }
                ),
                resolve: context =>
                {
                    var plantAdmin = context.GetArgument<PlantAdmin>("plantAdmin");
                    return plantAdminRepository.RegisterPlantAdmin(plantAdmin);
                }
            );

            base.Field<StringGraphType>("loginTechnician",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TechnicianInputType>> { Name = "technician" }),
                resolve: context => {
                    var technician = context.GetArgument<Technician>("technician");
                    return technicianRepository.LoginTechnician(technician);
                }
            );

            base.Field<StringGraphType>("loginPlantAdmin",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PlantAdminInputType>> { Name = "plantAdmin" }),
                resolve: context => {
                    var plantAdmin = context.GetArgument<PlantAdmin>("plantAdmin");
                    return plantAdminRepository.LoginPlantAdmin(plantAdmin);
                }
            );

            base.Field<StringGraphType>(
                "logoutTechnician",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }
                ),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return technicianRepository.LogoutTechnician(email);
                }
            );

            base.Field<StringGraphType>(
                "logoutPlantAdmin",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }
                ),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return plantAdminRepository.LogoutPlantAdmin(email);
                }
            );
        }
    }
}
