﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickSchema.Net.Classes;
using BrickSchema.Net.Classes.Collection;
using BrickSchema.Net.Classes.Collection.Loop;
using BrickSchema.Net.Classes.Devices;
using BrickSchema.Net.Classes.Equipments;
using BrickSchema.Net.Classes.Equipments.HVACType;
using BrickSchema.Net.Classes.Equipments.HVACType.TerminalUnits;
using BrickSchema.Net.Classes.Locations;
using BrickSchema.Net.Classes.Measureable;
using BrickSchema.Net.Classes.Points;


namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        private List<BrickEntity> _entities;
        private readonly string? _brickPath;


        public BrickSchemaManager()
        {
            _entities = new List<BrickEntity>();
        }

        public BrickSchemaManager(string brickFilePath)
        {
            _entities = new List<BrickEntity>();
            _brickPath = brickFilePath;
            LoadSchema(_brickPath);
        }


        public void LoadSchema(string jsonLdFilePath)
        {
            _entities = BrickSchemaUtility.ImportBrickSchema(jsonLdFilePath);
            // Update the OtherEntities property of all entities
            foreach (var existingEntity in _entities)
            {
                foreach (var _e in _entities)
                {
                    existingEntity.OtherEntities.Add(_e);
                }
                
            }
        }

        public void SaveSchema()
        {
            if (!string.IsNullOrEmpty(_brickPath)) { SaveSchema(_brickPath ?? string.Empty); }
            else throw new NullReferenceException("Brick file path is null or empty.");
        }

        public void SaveSchema(string jsonLdFilePath)
        {
            
            BrickSchemaUtility.ExportBrickSchema(_entities, jsonLdFilePath);
        }

        public List<dynamic> SearchEntities(Func<dynamic, bool> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public bool UpdateEntity(dynamic updatedEntity)
        {
            BrickEntity? entityToUpdate = _entities.FirstOrDefault(e => e.Id == updatedEntity.Id);
            if (entityToUpdate == null)
            {
                return false;
            }

            entityToUpdate.Type = updatedEntity.Type;
            entityToUpdate.Properties = updatedEntity.Properties;
            entityToUpdate.Relationships = updatedEntity.Relationships;

            return true;
        }

        public bool IsEntity(string id)
        {
            return _entities.Any(x=>x.Id.Equals(id));
        }

        public bool IsTag(string name)
        {
            var tags = _entities.Where(x => (x.Type?.Equals(typeof(Tag).Name) ?? false)).ToList();
            foreach (var tag in tags)
            {
                var t = tag as Tag;
                if (t.Name.Equals(name)) return true;
            }
            return false;
        }

        public T AddEntity<T>(string id, string name) where T : BrickEntity, new()
        {
            if (!string.IsNullOrEmpty(id))
            {
                var existingEntity = _entities.FirstOrDefault(x => x.Id.Equals(id));
                if (existingEntity != null) return (T)existingEntity;
            }
            T entity = new T
            {
                Id = id ?? Guid.NewGuid().ToString(),
                Type = typeof(T).Name
                
            };
            entity.AddOrUpdateProperty(EntityProperties.PropertiesEnum.Name, name);

            foreach (var _e in _entities)
            {
                //entity.OtherEntities.Add(_e);
                var e = _e as BrickEntity;
                e.OtherEntities.Add(entity);
            }
            entity.OtherEntities = new List<BrickEntity>(_entities);
            _entities.Add(entity);
            return entity;
        }

        public T AddEntity<T>(string? id) where T : BrickEntity, new()
        {
            T entity;
            if (id == null)
            {
                entity = AddEntity<T>();
            }
            else
            {
                entity = AddEntity<T>(id, "");
            }
            return entity;
        }

        public T AddEntity<T>() where T : BrickEntity, new()
        {
            T entity = new T
            {
                Id = Guid.NewGuid().ToString(),
                Type = typeof(T).Name
            };

            foreach (var _e in _entities)
            {
                entity.OtherEntities.Add(_e);
            }
            _entities.Add(entity);
            return entity;
        }

        public BrickEntity? GetEntity(string id, bool byReference = false)
        {
            var entity = _entities.FirstOrDefault(x => x.Id.Equals(id));
            return byReference ? entity : entity?.Clone();
        }
        public List<BrickEntity> GetEntities(bool byReference = false)
        {
            if (byReference)
            {
                return _entities;
            }

            List<BrickEntity> entities = new();
            foreach (var entity in _entities)
            {
                entities.Add(entity.Clone());

            }
            return entities;

        }
        public List<BrickEntity> GetEntities<T>(bool byReference = false)
        {
            var type = Helpers.EntityUntils.GetTypeName<T>();
            if (string.IsNullOrEmpty(type) || type.Equals("null"))
            { //no type so get all
                return GetEntities(byReference);
            }  else
            { //get specified type
                List<BrickEntity> entities = new();
                var isBrickClass = typeof(T).IsSubclassOf(typeof(BrickClass));
                foreach (var entity in _entities)
                {
                    bool add = entity.GetType() == typeof(T);
                    if (!add && isBrickClass)
                    {
                        var brickClassName = entity.GetProperty<string>(EntityProperties.PropertiesEnum.BrickClass);
                        if (brickClassName?.Equals(type)??false) {
                            add = true;
                        }
                    }

                    if (add)
                    {
                        if (byReference)
                        {
                            entities.Add(entity);
                        }
                        else
                        {
                            entities.Add(entity.Clone());
                        }
                    }

                }
                return entities;
            }
            
        }

        public Tag? GetTag(string name, bool byReference = false)
        {
            var tags = _entities.Where(x => (x.Type?.Equals(typeof(Tag).Name) ?? false)).ToList();
            if (tags == null) return null;
            if (tags.Count == 0) return null;
            foreach (var tag in tags)
            {
                var t = tag as Tag;
                if (t.Name.Equals(name)) return byReference?t:t.Clone(); 
            }
            return null;
        }

        public List<BrickEntity> GetEquipments(List<string> equipmentIds, bool byReference = false)
        {
            List<BrickEntity> entities = new List<BrickEntity>();

            foreach (var entity in _entities)
            {
                if (entity is Equipment)
                {
                    entities.Add(byReference?entity:entity.Clone());
                }
            }

            if (equipmentIds.Count > 0)
            {
                entities = entities.Where(x => equipmentIds.Contains(x.Id)).ToList();
            }
            return entities;
        }

    }
}
