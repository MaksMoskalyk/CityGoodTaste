﻿namespace CityGoodTaste.BusinessLayer
{
    public abstract class DataManagerCreator
    {
        public abstract IBaseDataManager GetBaseDataManager();

        public abstract IRestaurantDataManager GetRestaurantDataManager();

        public abstract IAdministrationDataManager GetAdministrationDataManager();
    }


    public class DefaultDataManagerCreator : DataManagerCreator
    {
        public override IBaseDataManager GetBaseDataManager()
        {
            return new BaseDataManager();
        }

        public override IRestaurantDataManager GetRestaurantDataManager()
        {
            return new RestaurantDataManager();
        }

        public override IAdministrationDataManager GetAdministrationDataManager()
        {
            return new AdministrationDataManager();
        }
    }
}