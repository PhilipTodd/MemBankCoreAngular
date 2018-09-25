using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MemBankCoreAngular.DAL
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<MemBankContext> options) : base(options)
        {
        }

        private List<string> insertChangeDateColumns = new List<string> { "Created" };
        private List<string> updateChangeDateColumns = new List<string> { "Modified" };
        protected virtual void preSaveEntity(object entity, EntityState state) { }
        protected virtual void postSaveChanges() { }

        public int SqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        public override int SaveChanges()
        {
            prepareEntities();
            //preSaveChanges();

            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);

                try
                {
                    Validator.ValidateObject(entity, validationContext);
                }
                catch (ValidationException ex)
                {
                    Trace.WriteLine("Property: {0} Error: {1}" +
                         ex.ValidationResult.MemberNames.First() +
                         ex.ValidationResult.ErrorMessage);
                }
            }

            return base.SaveChanges();
        }

        private void prepareEntities()
        {
            // prepare the items for saving
            foreach (var entry in this.ChangeTracker.Entries().ToList())
            {
                // Populate the last changed information
                if ((entry.State == EntityState.Added) || (entry.State == EntityState.Modified))
                {
                    setChangeInformation(entry.Entity, (entry.State == EntityState.Added));
                    preSaveEntity(entry.Entity, entry.State);
                }

                if ((entry.State == EntityState.Deleted))
                {
                    preSaveEntity(entry.Entity, entry.State);
                }

                // Trim any long strings
                if ((entry.State == EntityState.Added) || (entry.State == EntityState.Modified))
                {
                    trimStrings(entry);
                }
            }
        }

        private void setChangeInformation(object entity, bool isNewEntity)
        {
            // The property lookup should be cached for performance
            Type entityType = entity.GetType();
            PropertyInfo[] props = entityType.GetProperties();

            this.updateChangeDateColumns.ForEach(columnName =>
            {
                var property = entityType.GetProperty(columnName);
                if (property != null) property.SetValue(entity, DateTime.UtcNow, null);
            });


            if (isNewEntity)
            {
                this.insertChangeDateColumns.ForEach(columnName =>
                {
                    var property = entityType.GetProperty(columnName);
                    if (property != null) property.SetValue(entity, DateTime.UtcNow, null);
                });

            }
        }

        private void trimStrings(EntityEntry entry)
        {
            // Trim any string properties based on the StringLengthAttribute property attribute
            Type entityType = entry.Entity.GetType();

            PropertyInfo[] properties2 = entityType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties2)
            {
                try
                {
                    if (propertyInfo.IsDefined(typeof(StringLengthAttribute), true))
                    {
                        StringLengthAttribute attrib = (StringLengthAttribute)propertyInfo.GetCustomAttributes(typeof(StringLengthAttribute), true)[0];
                        int length = attrib.MaximumLength;
                        var checkProperty = entityType.GetProperty(propertyInfo.Name);
                        if (checkProperty != null)
                        {
                            string value = (string)checkProperty.GetValue(entry.Entity, null);
                            if (!String.IsNullOrEmpty(value))
                            {
                                if (value.Length > attrib.MaximumLength)
                                {
                                    checkProperty.SetValue(entry.Entity, value.Substring(0, attrib.MaximumLength), null);
                                }
                            }
                        }
                    }
                    if (propertyInfo.IsDefined(typeof(MaxLengthAttribute), true))
                    {
                        MaxLengthAttribute attrib = (MaxLengthAttribute)propertyInfo.GetCustomAttributes(typeof(MaxLengthAttribute), true)[0];
                        int length = attrib.Length;
                        var checkProperty = entityType.GetProperty(propertyInfo.Name);
                        if (checkProperty != null)
                        {
                            string value = (string)checkProperty.GetValue(entry.Entity, null);
                            if (!String.IsNullOrEmpty(value))
                            {
                                if (value.Length > attrib.Length)
                                {
                                    checkProperty.SetValue(entry.Entity, value.Substring(0, attrib.Length), null);
                                }
                            }
                        }
                    }

                    if (propertyInfo.PropertyType.FullName.StartsWith("Synergy5."))
                    {
                        var checkProperty = entityType.GetProperty(propertyInfo.Name);
                        var value = checkProperty.GetValue(entry.Entity, null);
                        if (value != null)
                        {
                            this.recursiveTrimStrings(value, checkProperty.PropertyType);
                        }
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.Message;
                }


            }
        }

        void recursiveTrimStrings(object entity, Type entityType)
        {
            PropertyInfo[] properties2 = entityType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties2)
            {
                try
                {
                    if (propertyInfo.IsDefined(typeof(StringLengthAttribute), true))
                    {
                        StringLengthAttribute attrib = (StringLengthAttribute)propertyInfo.GetCustomAttributes(typeof(StringLengthAttribute), true)[0];
                        int length = attrib.MaximumLength;
                        var checkProperty = entityType.GetProperty(propertyInfo.Name);
                        if (checkProperty != null)
                        {
                            string value = (string)checkProperty.GetValue(entity, null);
                            if (!String.IsNullOrEmpty(value))
                            {
                                if (value.Length > attrib.MaximumLength)
                                {
                                    checkProperty.SetValue(entity, value.Substring(0, attrib.MaximumLength), null);
                                }
                            }
                        }
                    }
                    if (propertyInfo.IsDefined(typeof(MaxLengthAttribute), true))
                    {
                        MaxLengthAttribute attrib = (MaxLengthAttribute)propertyInfo.GetCustomAttributes(typeof(MaxLengthAttribute), true)[0];
                        int length = attrib.Length;
                        var checkProperty = entityType.GetProperty(propertyInfo.Name);
                        if (checkProperty != null)
                        {
                            string value = (string)checkProperty.GetValue(entity, null);
                            if (!String.IsNullOrEmpty(value))
                            {
                                if (value.Length > attrib.Length)
                                {
                                    checkProperty.SetValue(entity, value.Substring(0, attrib.Length), null);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.Message;
                }

            }
        }
    }
}
