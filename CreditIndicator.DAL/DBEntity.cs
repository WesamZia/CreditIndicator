﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using CreditIndicator.Contracts.Models;

namespace CreditIndicator.DAL
{
    public class DBEntity : DbContext
    {
        public DBEntity() : base(BuildConnectionString())
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new IndicatorDataInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO
            //modelBuilder.Configurations.Add(new DigitMapper());
            //modelBuilder.Configurations.Add(new FeatureMapper());
        }


        public virtual DbSet<FeatureModel> Features { get; set; }
        public virtual DbSet<DigitModel> Digits { get; set; }


        private static string BuildConnectionString()
        {
            var _conbuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            _conbuilder.IntegratedSecurity = true;
            _conbuilder.DataSource = @"(LocalDb)\MSSQLLocalDB";
            _conbuilder.InitialCatalog = "CreditDB";
            return _conbuilder.ConnectionString;
        }
    }
}
