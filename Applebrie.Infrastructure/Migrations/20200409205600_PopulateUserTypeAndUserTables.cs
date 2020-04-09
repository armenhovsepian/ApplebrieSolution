using Microsoft.EntityFrameworkCore.Migrations;

namespace Applebrie.Infrastructure.Migrations
{
    public partial class PopulateUserTypeAndUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                      SET IDENTITY_INSERT [dbo].[UserType] ON
                           INSERT INTO [dbo].[UserType]
                              ([Id],[Name])
                           VALUES
                              (1001,'Software Engineer I'),
                              (1002,'GIS Technical Architect'),
                              (1003,'Marketing Assistant'),
                              (1004,'Desktop Support Technician'),
                              (1005,'Research Assistant IV'),
                              (1006,'Statistician III'),
                              (1007,'Professor'),
                              (1008,'Occupational Therapist'),
                              (1009,'General Manager'),
                              (1010,'Teacher')
                      SET IDENTITY_INSERT [dbo].[UserType] OFF
                    ");



            migrationBuilder.Sql(@"
                      SET IDENTITY_INSERT [dbo].[User] ON
                      INSERT INTO [dbo].[User]
                              ([Id],[FirstName],[LastName],[UserTypeId])
                           VALUES
                              (1001,'Minny','Reye',1005),
                              (1002,'Cob','Churchill',1007),
                              (1003,'Nettle','Dagg',1001),
                              (1004,'Raviv','Nabarro',1002),
                              (1005,'Chip','Lillgard',1001),
                              (1006,'Cairistiona','Tytherton',1001),
                              (1007,'Rutherford','Hiseman',1007),
                              (1008,'Iosep','Praundlin',1001),
                              (1009,'Vanya','Bridgwood',1009),
                              (1010,'Flore','Totterdell',1002),
                              (1011,'Elinor','Mashro',1010),
                              (1012,'Kerk','Gollard',1007),
                              (1013,'Conrade','Clapperton',1004),
                              (1014,'Corey','Goodley',1005),
                              (1015,'Meara','Smithe',1009),
                              (1016,'Eryn','Raigatt',1003),
                              (1017,'Harriet','Prickett',1001),
                              (1018,'Hervey','Tegeller',1002),
                              (1019,'Cortie','Verheijden',1002),
                              (1020,'Janeta','Lung',1006)
                     SET IDENTITY_INSERT [dbo].[User] OFF
                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
     DELETE [dbo].[User]
                         WHERE 
                              [Id]
                         IN
                              (1001,
                               1002,
                               1003,
                               1004,
                               1005,
                               1006,
                               1007,
                               1008,
                               1009,
                               1010,
                               1011,
                               1012,
                               1013,
                               1014,
                               1015,
                               1016,
                               1017,
                               1018,
                               1019,
                               1020)
");


            migrationBuilder.Sql(@"
DELETE [dbo].[UserType]
                         WHERE 
                              [Id]
                         IN
                              (1001,
                               1002,
                               1003,
                               1004,
                               1005,
                               1006,
                               1007,
                               1008,
                               1009,
                               1010)
");
        }
    }
}
