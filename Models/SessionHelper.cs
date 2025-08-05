using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Equinox.Models
{
    public class SessionHelper
    {
        private readonly ISession _session;

        private const string BookingKey = "Bookings";
        private const string ClubFilterKey = "SelectedClub";
        private const string CategoryFilterKey = "SelectedCategory";

        public SessionHelper(ISession session)
        {
            _session = session;
        }

        public List<int> GetBookings() =>
            _session.GetObjectFromJson<List<int>>(BookingKey) ?? new List<int>();

        public void SetBookings(List<int> bookings) =>
            _session.SetObjectAsJson(BookingKey, bookings);

        public string GetSelectedClub() =>
            _session.GetString(ClubFilterKey) ?? "All";

        public void SetSelectedClub(string club) =>
            _session.SetString(ClubFilterKey, club);

        public string GetSelectedCategory() =>
            _session.GetString(CategoryFilterKey) ?? "All";

        public void SetSelectedCategory(string category) =>
            _session.SetString(CategoryFilterKey, category);
    }
}
