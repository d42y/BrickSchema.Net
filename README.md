
# BrickSchema.Net User Manual

The BrickSchema.Net is a C# library implimentation of Brick Schema. This user manual will guide you through the process of setting up, importing, and working with the Brick Schema.

For more information about Brick Schema, please visit https://brickschema.org/

As of 4/20/2023 - The library implemented 80% of Brick Schema v1.3.

## Package Version
The package version format is a.b.x (1.3.1). 
a.b = Brick Schema version. https://brickschema.org/ontology
x = package revision

## Table of Contents

1. [Installation and Setup](#installation-and-setup)
2. [Loading and Saving Schemas](#loading-and-saving-schemas)
3. [Working with Entities](#working-with-entities)
4. [Searching Entities](#searching-entities)
5. [Updating Entities](#updating-entities)
6. [Adding Entities](#adding-entities)
7. [Working with Entity](#working-with-entity)

## Installation and Setup

### Prerequisites

To use the BrickSchema.Net, you need to have the following software installed:

- .NET7
- A compatible C# IDE, such as Visual Studio or Visual Studio Code

### Installation

1. Download and add the BrickSchema.Net library to your project.
2. Import the required namespaces in your source code file:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickSchema.Net.Classes;
using BrickSchema.Net.Classes.Collection;
using BrickSchema.Net.Classes.Collection.Loop;
using BrickSchema.Net.Classes.Equipment;
using BrickSchema.Net.Classes.Location;
using BrickSchema.Net.Classes.Measureable;
using BrickSchema.Net.Classes.Point;
```
## Loading and Saving Schemas
To load a Brick schema froma  JSON-LD file:
```csharp
var manager = new BrickSchemaManager();
manager.LoadSchema("path/to/your/brick-schema.jsonld");
```
To save a Brick schema to a JSON-LD file:
```csharp
manager.SaveSchema("path/to/save/brick-schema.jsonld");
```
## Working with Entities
Entities in the Brick schema are represented as objects of classes that inherit from the BrickEntity class. Each entity has an Id, Type, Properties, and Relationships.

To access the entities managed by the BrickSchemaManager:
```csharp
var entities = manager.Entities;
```
## Searching Entities
To search for entities in the Brick schema, use the SearchEntities method and provide a predicate function:
```csharp
var entityToUpdate = new Sensor
{
    Id = "existing-entity-id",
    Type = "NewType",
    Properties = newProperties,
    Relationships = newRelationships,
};

bool success = manager.UpdateEntity(entityToUpdate);
```
## Updating Entities
To update an existing entity in the Brick schema, use the UpdateEntity method:
```csharp
var entityToUpdate = new Sensor
{
    Id = "existing-entity-id",
    Type = "NewType",
    Properties = newProperties,
    Relationships = newRelationships,
};

bool success = manager.UpdateEntity(entityToUpdate);
```
## Adding Entities
To add a new entity to the Brick schema, use one of the AddEntity methods for the specific entity type:
```csharp
// Add a new floor location entity
var floor = manager.AddLocationFloor();

// Add a HVAC AHU entity
var ahu = manager.AddEquipmentHVACAHU();

// Add a HVAC VAV entity
var vav = manager.AddEquipmentHVACTerminalUnitVAV();

// Add a new sensor point entity
var sensor = manager.AddPointSensor();
```
## Working with Entity
```cshard
// Add a new floor location entity
var floor = manager.AddLocationFloor();
//Add property relating to this entity
foor.AddProperty("Name", "Level 1");

// Add a HVAC AHU entity
var ahu = manager.AddEquipmentHVACAHU();
//Add property relating to this entity
ahu.AddProperty("Name", "AHU1");
//Add ahu to Level 1 floor location (relationship)
ahu.AddRelationshipLocationOf(floor.Id);

// Add a HVAC VAV entity
var vav = manager AddEquipmentHVACTerminalUnitVAV();
//Add property relating to this entity
vav.AddProperty("Name", "VAV1-1");
//Add vav to Level 1 floor locatio (relationship)
vav.AddRelationshipLocationOf(floor.Id);
//Add vav feed from AHU (relationship)
vav.AddRelationshipFedBy(ahu.Id);

// Add a new sensor point entity
var sensor = manager.AddPointSensor();
// Associate the point with VAV
sensor.AddRelationshipAssociatedWith(vav.Id);
// sensor is point of VAV
sensor.AddRelationshipPointOf(vav.Id);
```
