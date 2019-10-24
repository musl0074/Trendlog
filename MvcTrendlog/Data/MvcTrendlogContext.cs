using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcTrendlog.Models
{
    public class MvcTrendlogContext : DbContext
    {
        public MvcTrendlogContext (DbContextOptions<MvcTrendlogContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTrendlog.Models.AuthorModel> AuthorModel { get; set; }
        public DbSet<MvcTrendlog.Models.TrendlogApiModel.Alarmsettings> AlarmSettingModel { get; set; }
        public DbSet<MvcTrendlog.Models.TrendlogApiModel.Channel> ChannelModel { get; set; }
        public DbSet<MvcTrendlog.Models.TrendlogApiModel.Feed> FeedModel { get; set; }
        public DbSet<MvcTrendlog.Models.TrendlogApiModel.Point> PointModel { get; set; }
        public DbSet<MvcTrendlog.Models.TrendlogApiModel.RootObject> RootObjectModel { get; set; }

    }
}
