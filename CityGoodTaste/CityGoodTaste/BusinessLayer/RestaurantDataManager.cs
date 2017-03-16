using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGoodTaste.Models;
using System.Data.Entity;
using CityGoodTaste.Models.ViewModels;
using Microsoft.AspNet.Identity;



namespace CityGoodTaste.BusinessLayer
{
    abstract class RestaurantDataManagerCreator
    {
        public abstract IRestaurantDataManager GetManager();
    }
    class DefaultRestaurantDataManagerCreator : RestaurantDataManagerCreator
    {
        public override IRestaurantDataManager GetManager()
        {
            return new RestaurantDataManager();
        }
    }

    public interface IRestaurantDataManager
    {
        Restaurant GetRestaurant(int? id);
        List<Restaurant> GetListRestaurants();
        RestaurantSchema GetRestaurantSchema(int? id);
        List<RestaurantEvent> GetListRestaurantEvents();
        RestaurantShemaViewModel GetRestaurantViewModelSchema(int? id);
        List<EventType> GetAllEventTypes();
        List<Cuisine> GetAllCuisines();
        List<RestaurantFeature> GetAllRestaurantFeatures();
        List<MealGroup> GetAllMealGroups();
        void ReservTables(List<TableViewModel> tables);
    }

    public class RestaurantDataManager: IRestaurantDataManager
    {
        public Restaurant GetRestaurant(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Restaurant Rest = context.Restaurants.Include(t => t.Likes).FirstOrDefault(t => t.Id == id);
                    Rest = context.Restaurants.Include(t => t.City).FirstOrDefault(t => t.Id == id);
                    Rest.City = context.Cities.Include(t => t.Country).FirstOrDefault(t => t.Country.Id == Rest.City.Country.Id);
                    Rest = context.Restaurants.Include(t => t.RestaurantFeatures).FirstOrDefault(t => t.Id == id);
                    Rest = context.Restaurants.Include(t => t.WorkHours).FirstOrDefault(t => t.Id == id);
                    Rest = context.Restaurants.Include(t => t.Reviews).FirstOrDefault(t => t.Id == id);
                    Rest.Reviews = context.RestaurantReviews.Include(t => t.User).ToList();
                    Rest = context.Restaurants.Include(t => t.RestaurantSchemas).FirstOrDefault(t=>t.Id==id);
                    var tables = context.Tables.Include(t => t.TableReservation);
                    Rest.RestaurantSchemas = context.RestaurantSchemas.Include(t => t.Tables = tables.ToList()).ToList();

                    

                    return Rest;
                }
                catch
                {
                    throw new Exception("Restaurant not found");
                }
            }

        }
        public List<Restaurant> GetListRestaurants()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Restaurant> result = context.Restaurants.Include(t => t.Likes).Include(t => t.City).
                        Include(t => t.RestaurantFeatures).Include(t => t.Reviews).Include(t => t.WorkHours).
                        Include(t => t.Cuisines).Include(t => t.Likes).Include(t => t.RestaurantFeatures).Include(t => t.RestaurantGroup).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurants not found");
                }
            }

        }
        public List<RestaurantEvent> GetListRestaurantEvents()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantEvent> result = context.RestaurantEvent.Include(t => t.Restaurant).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Events not found");
                }
            }

        }
        public List<EventType> GetAllEventTypes()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<EventType> result = context.EventTypes.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Event types not found");
                }
            }

        }
        public List<Cuisine> GetAllCuisines()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Cuisine> result = context.Cuisines.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Cuisines not found");
                }
            }

        }
        public List<RestaurantFeature> GetAllRestaurantFeatures()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantFeature> result = context.RestaurantFeatures.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant features not found");
                }
            }
        }
        public List<MealGroup> GetAllMealGroups()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<MealGroup> result = context.MealGroups.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant features not found");
                }
            }
        }
        public RestaurantSchema GetRestaurantSchema(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Restaurant Rest = context.Restaurants.Find(id);
                    RestaurantSchema Schema = Rest.RestaurantSchemas.FirstOrDefault();
                    Schema = context.RestaurantSchemas.Include(t => t.Restaurant).FirstOrDefault(t => t.Id == id);
                    Schema = context.RestaurantSchemas.Include(t => t.Tables).FirstOrDefault();
                    return Schema;
                }
                catch
                {
                    throw new Exception("Restaurant not found");
                }
            }
        }

        public RestaurantShemaViewModel GetRestaurantViewModelSchema(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Restaurant Rest = context.Restaurants.Find(id);
                    RestaurantSchema Schema = Rest.RestaurantSchemas.FirstOrDefault();
                    Schema = context.RestaurantSchemas.Include(t => t.Restaurant).FirstOrDefault(t => t.Id == id);
                    Schema = context.RestaurantSchemas.Include(t => t.Tables).FirstOrDefault();
                    RestaurantShemaViewModel vmSchema = new RestaurantShemaViewModel();
                    vmSchema.Id = Schema.Id;
                    vmSchema.Name = Schema.Name;
                    List<TableViewModel> vmTables = new List<TableViewModel>();

                    foreach (var table in Schema.Tables)
                    {
                        TableViewModel vmTable = new TableViewModel { Id = table.Id, X = table.X, Y = table.Y, Seats = table.Seats, ReservedAndConfirmed = false, Reserved = false };
                        foreach (var reserv in table.TableReservation)
                        {
                            if (reserv.Date.Date == DateTime.Now.Date)
                            {
                                vmTable.ReservedAndConfirmed = true;
                                break;
                            }
                        }
                        vmTables.Add(vmTable);
                    }

                    vmSchema.Tables = vmTables;
                    vmSchema.XLength = Schema.XLength;
                    vmSchema.YLength = Schema.YLength;
                    return vmSchema;
                }
                catch
                {
                    throw new Exception("Restaurant not found");
                }
            }
        }

        public void ReservTables(List<TableViewModel> tables)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                foreach (var item in tables)
                {
                    if (item.Reserved == true)
                    {                        
                        //ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == HttpContext.Current.User.Identity.GetUserId());
                        ApplicationUser currentUser = context.Users.FirstOrDefault();
                        Table table = context.Tables.Find(item.Id);
                        TableReservation reserv = new TableReservation { Date = DateTime.Now, Table = table, User = currentUser, Reserved = true, ReservedAndConfirmed=false };
                        context.TableReservations.Add(reserv);
                        context.SaveChanges();
                    }
                }
            }
        }
    }


}