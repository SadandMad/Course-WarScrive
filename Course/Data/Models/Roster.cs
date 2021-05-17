using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data.Models
{
    public class Roster
    {
        private readonly AppDBContent appDBContent;
        public Roster(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }
        public string rosterId { get; set; }
        public List<RosterItem> listRosterItems { get; set; }

        public static Roster GetRoster(IServiceProvider services) {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string rosterId = session.GetString("rosterId") ?? Guid.NewGuid().ToString();
            session.SetString("rosterId", rosterId);
            return new Roster(context) { rosterId = rosterId };
        }   

        public void AddToRoster(Unit unit) {
            this.appDBContent.RosterItem.Add(new RosterItem {
                rosterId = rosterId, unit = unit
            });

            appDBContent.SaveChanges();
        }

        public void deleteFromRoster(int id) {
            appDBContent.RosterItem.Remove(appDBContent.RosterItem.FirstOrDefault(c => c.rosterId == rosterId && c.Id == id));
            appDBContent.SaveChanges();
        }

        public void clearRoster() {
            appDBContent.RosterItem.RemoveRange(appDBContent.RosterItem.Where(c => c.rosterId == rosterId).Include(s => s.unit));
            appDBContent.SaveChanges();
        }

        public List<RosterItem> getRosterItems() {
            return appDBContent.RosterItem.Where(c => c.rosterId == rosterId).OrderBy(c => c.unit.Category).ThenByDescending(c => c.unit.Id).Include(s => s.unit).ToList();
        }
    }
}