using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Initializer
{
    public class DBInitializer
    {
        public static void Initialize(VisiAgeDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roles = new Role[]
                {
                    new Role {Name = "Dependent"},
                    new Role {Name = "Confidant"},
                    new Role {Name = "Caregiver"},
                    new Role {Name = "Administrator"},
                };

                foreach (Role r in roles)
                {
                    context.Roles.Add(r);
                }

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User {
                        FirstName = "John",
                        LastName = "Smith",
                        BirthDate = new DateTime(1968, 10, 21),
                        PhoneNumber = "1234567890",
                        Email = "johnsmith@visiage.com",
                        Address = "Stokt 48, 2440 Geel",
                        RoleId = 1,
                    },
                    new User {
                        FirstName = "Rosa",
                        LastName = "Hendriks",
                        BirthDate = new DateTime(1958, 8, 21),
                        PhoneNumber = "1234567890",
                        Email = "rosahendriks@visiage.com",
                        Address = "Stelenseweg 88, 2440 Geel",
                        RoleId = 2,
                        DependentId = 1,
                    },
                    new User {
                        FirstName = "Jonas",
                        LastName = "Joe",
                        BirthDate = new DateTime (1965, 5, 21),
                        PhoneNumber = "1234567890",
                        Email = "jonasjoe@visiage.com",
                        Address = "Dr.-Peetersstraat 20, 2440 Geel",
                        RoleId = 3,
                    },
                    new User {
                        FirstName = "Admin",
                        LastName = "Admin",
                        BirthDate = new DateTime(2003, 9, 21),
                        PhoneNumber = "1234567890",
                        Email = "admin@visiage.com",
                        Address = "Excelsiorlaan 43/bus 2, 1930 Zaventem",
                        RoleId = 4,
                    },
                };

                foreach (User u in users)
                {
                    context.Users.Add(u);
                }

                context.SaveChanges();
            }

            if (!context.Coughs.Any())
            {
                var coughs = new Cough[]
                {
                    new Cough {
                        Severity = 70,
                        Duration = new TimeSpan(0, 1, 30),
                        Amount = 10,
                        AudioPath = "temp_audio.mp3",
                        DependentId = 1,
                    },
                    new Cough {
                        Severity = 40,
                        Duration = new TimeSpan(0, 0, 30),
                        Amount = 3,
                        AudioPath = "temp_audio.mp3",
                        DependentId = 1,
                    },
                    new Cough {
                        Severity = 90,
                        Duration = new TimeSpan(0, 4, 30),
                        Amount = 40,
                        AudioPath = "temp_audio.mp3",
                        DependentId = 1,
                    },
                    new Cough {
                        Severity = 20,
                        Duration = new TimeSpan(0, 4, 30),
                        Amount = 5,
                        AudioPath = "temp_audio.mp3",
                        DependentId = 1,
                    },
                };

                foreach (Cough c in coughs)
                {
                    context.Coughs.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.CameraRooms.Any())
            {
                var cameraRooms = new CameraRoom[]
                {
                    new CameraRoom {
                        Name = "Living Room",
                        DependentId = 1,
                    },
                    new CameraRoom {
                        Name = "Garage",
                        DependentId = 1,
                    },
                };

                foreach (CameraRoom c in cameraRooms)
                {
                    context.CameraRooms.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.IncidentTypes.Any())
            {
                var incidentTypes = new IncidentType[]
                {
                    new IncidentType {Name = "Fall"},
                    new IncidentType {Name = "Manual Alert"},
                };

                foreach (IncidentType i in incidentTypes)
                {
                    context.IncidentTypes.Add(i);
                }

                context.SaveChanges();
            }

            if (!context.Alerts.Any())
            {
                var alerts = new Alert[]
                {
                    new Alert {
                        TimeStamp = new DateTime(2024,01,17,09,15,00),
                        KeepFootage = true,
                        AccuracyScore = 80,
                        VideoPath = "temp_video.mp4",
                        IncidentTypeId = 1,
                        CameraRoomId = 1,
                        DependentId = 1,
                    },
                    new Alert {
                        TimeStamp = new DateTime(2024,01,15,14,15,00),
                        Reason = "I feel very dizzy and unwell.",
                        IncidentTypeId = 2,
                        CameraRoomId = 1,
                        DependentId = 1,
                    },
                    new Alert {
                        TimeStamp = new DateTime(2024,01,18,18,15,00),
                        KeepFootage = false,
                        AccuracyScore = 90,
                        IncidentTypeId = 1,
                        CameraRoomId = 2,
                        DependentId = 1,
                    },
                };

                foreach (Alert a in alerts)
                {
                    context.Alerts.Add(a);
                }

                context.SaveChanges();
            }

            if (!context.AlertStatusTypes.Any())
            {
                var alertStatusTypes = new AlertStatusType[]
                {
                    new AlertStatusType {Name = "Resolved"},
                    new AlertStatusType {Name = "Waiting"},
                    new AlertStatusType {Name = "Escalated"},
                    new AlertStatusType {Name = "Emergency Services Contacted"},
                };

                foreach (AlertStatusType a in alertStatusTypes)
                {
                    context.AlertStatusTypes.Add(a);
                }

                context.SaveChanges();
            }

            if (!context.AlertStatuses.Any())
            {
                var alertStatuses = new AlertStatus[]
                {
                    new AlertStatus {
                        TimeStamp = new DateTime(2024,01,17,09,20,00),
                        Message = "John can't stand up anymore and I don't know what to do.",
                        AlertId = 1,
                        AlertStatusTypeId = 3,
                        ResolverId = 2,
                    },
                    new AlertStatus {
                        TimeStamp = new DateTime(2024,01,17,09,40,00),
                        AlertId = 1,
                        AlertStatusTypeId = 4,
                    },
                    new AlertStatus {
                        TimeStamp = new DateTime(2024,01,15,14,20,00),
                        AlertId = 2,
                        AlertStatusTypeId = 1,
                        ResolverId = 3,
                    },
                    new AlertStatus {
                        TimeStamp = new DateTime(2024,01,18,18,15,00),
                        AlertId = 3,
                        AlertStatusTypeId = 2,
                    },
                };

                foreach (AlertStatus a in alertStatuses)
                {
                    context.AlertStatuses.Add(a);
                }

                context.SaveChanges();
            }
        }
    }
}

