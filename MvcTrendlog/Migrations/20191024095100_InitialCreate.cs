using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTrendlog.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmSettingModel",
                columns: table => new
                {
                    alarmid = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmSettingModel", x => x.alarmid);
                });

            migrationBuilder.CreateTable(
                name: "AuthorModel",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Earnings = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModel", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "ChannelModel",
                columns: table => new
                {
                    channel_id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    timezone = table.Column<string>(nullable: true),
                    lifetime = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    elevation = table.Column<string>(nullable: true),
                    alarmsettingsalarmid = table.Column<string>(nullable: true),
                    created = table.Column<string>(nullable: true),
                    updated = table.Column<string>(nullable: true),
                    maxsize = table.Column<string>(nullable: true),
                    pcount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelModel", x => x.channel_id);
                    table.ForeignKey(
                        name: "FK_ChannelModel_AlarmSettingModel_alarmsettingsalarmid",
                        column: x => x.alarmsettingsalarmid,
                        principalTable: "AlarmSettingModel",
                        principalColumn: "alarmid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedModel",
                columns: table => new
                {
                    feed_id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    label = table.Column<string>(nullable: true),
                    scale = table.Column<string>(nullable: true),
                    alarm = table.Column<string>(nullable: true),
                    enable_alarm = table.Column<string>(nullable: true),
                    alarm_settings = table.Column<string>(nullable: true),
                    channel_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedModel", x => x.feed_id);
                    table.ForeignKey(
                        name: "FK_FeedModel_ChannelModel_channel_id",
                        column: x => x.channel_id,
                        principalTable: "ChannelModel",
                        principalColumn: "channel_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RootObjectModel",
                columns: table => new
                {
                    rootObjectid = table.Column<string>(nullable: false),
                    channel_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObjectModel", x => x.rootObjectid);
                    table.ForeignKey(
                        name: "FK_RootObjectModel_ChannelModel_channel_id",
                        column: x => x.channel_id,
                        principalTable: "ChannelModel",
                        principalColumn: "channel_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointModel",
                columns: table => new
                {
                    pointid = table.Column<string>(nullable: false),
                    timestamp = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    feed_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointModel", x => x.pointid);
                    table.ForeignKey(
                        name: "FK_PointModel_FeedModel_feed_id",
                        column: x => x.feed_id,
                        principalTable: "FeedModel",
                        principalColumn: "feed_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelModel_alarmsettingsalarmid",
                table: "ChannelModel",
                column: "alarmsettingsalarmid");

            migrationBuilder.CreateIndex(
                name: "IX_FeedModel_channel_id",
                table: "FeedModel",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_PointModel_feed_id",
                table: "PointModel",
                column: "feed_id");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjectModel_channel_id",
                table: "RootObjectModel",
                column: "channel_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModel");

            migrationBuilder.DropTable(
                name: "PointModel");

            migrationBuilder.DropTable(
                name: "RootObjectModel");

            migrationBuilder.DropTable(
                name: "FeedModel");

            migrationBuilder.DropTable(
                name: "ChannelModel");

            migrationBuilder.DropTable(
                name: "AlarmSettingModel");
        }
    }
}
