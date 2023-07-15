using iQuest.HotelQueries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.HotelQueries
{
    public class Hotel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// 1) Return a collection with all rooms that can accomodate exactly 2 persons.
        /// </summary>
        public IEnumerable<Room> GetAllRoomsForTwoPersons()
        {
            return Rooms.Where(capacity => capacity.MaxPersonCount == 2);
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            return Customers.Where(name => name.FullName.Contains(text, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            var companiesCustomer = Reservations
                .Where(x => x.Customer is CompanyCustomer);

            return companiesCustomer;
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            var womenCustomers = Customers.OfType<PersonCustomer>()
                .Where(womenCustomer => (womenCustomer.LastAccommodation >= startTime && womenCustomer.LastAccommodation <= endTime) && (womenCustomer.Gender == PersonGender.Female));

            return womenCustomers;
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            var numberOfPerson = Rooms.Sum(capacity => capacity.MaxPersonCount);
            return numberOfPerson;
        }

        /// <summary>
        /// 6) Return a single page containing a number of exactly pageSize Rooms, ordered by surface.
        /// The pageNumber starts from 0.
        ///
        /// This is useful when paginating a large number of items in order to display them in a webpage.
        /// </summary>
        public IEnumerable<Room> GetPageOfRoomsOrderedBySurface(int pageNumber, int pageSize)
        {
            var pageOfRooms = Rooms
                .OrderBy(room => room.Surface)
                .Skip(pageNumber * pageSize)
                .Take(pageSize);

            return pageOfRooms;
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            var sortedRooms = Rooms
                .OrderByDescending(room => room.MaxPersonCount).ThenBy(room => room.Number);

            return sortedRooms;
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            var reservations = Reservations
                .Where(reservation => reservation.Customer.Id == customerId)
                .OrderByDescending(reservation => reservation.StartDate);

            return reservations;
        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            var groupedCustomers = Customers
                .GroupBy(customer => customer.LastAccommodation.Year)
                .OrderByDescending(kv => kv.Key)
                .ToDictionary(kv => kv.Key, kv => kv.OrderBy(customer => customer.FullName).ToArray())
                .ToList();

            return groupedCustomers;
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            var numberOfReservations = Reservations
                .GroupBy(x => x.StartDate.Month)
                .Average(reservation => reservation.Count());

            return numberOfReservations;
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            var conflictReservation = Reservations
                    .Select(res => new
                    {
                        Reservation = res,
                        Conflicts = Reservations
                            .Where(res.ConflictsWith)
                            .ToList()
                    })
                    .Where(kv => kv.Conflicts.Count!= 0)
                    .ToDictionary(kv => kv.Reservation, kv => kv.Conflicts);
            return conflictReservation;
        }

        /// <summary>
        /// 12) We have a reservation for a room, but there is a conflict: there is another reservation for the same room.
        /// Your task is to propose another similar room for the reservation.
        ///
        /// A similar room is a room that has the same number of maximum occupants or grater, has air conditioner if
        /// the original reserved room had, is disabled friendly if the original reserved room was and
        /// has balcony if the original reserved room had one.
        /// </summary>
        public Room FindNewFreeRoomFor(Reservation reservation)
        {
            var rooms = Rooms
                .Where(room => room != reservation.Room
                               && room.MaxPersonCount >= reservation.Room.MaxPersonCount
                               && room.HasAirConditioner == reservation.Room.HasAirConditioner
                               && room.IsDisabledFriendly == reservation.Room.IsDisabledFriendly
                               && room.HasBalcony == reservation.Room.HasBalcony);

            var reservations = rooms.Select(room => new
            {
                Key = room,
                Value = Reservations
                    .Where(res => res.ConflictsWith(reservation.StartDate, reservation.EndDate))
                    .Where(res => res.Room.Equals(room))
                    .ToList()
            });

            return reservations.FirstOrDefault(x => x.Value.Count == 0)?.Key;
        }
    }
}