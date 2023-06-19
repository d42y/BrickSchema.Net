using BrickSchema.Net.Classes;
using BrickSchema.Net.EntityProperties;
using BrickSchema.Net.Relationships;
using BrickSchema.Net.Shapes;
using Newtonsoft.Json;
using System.Drawing;

namespace BrickSchema.Net
{
    public class BrickEntity
    {
        [JsonIgnore]
        internal List<BrickEntity> OtherEntities { get; set; }

        public string Id { get; set; }
        public string? Type { get; set; }
        public List<EntityProperty> Properties { get; set; }
        public List<BrickRelationship> Relationships { get; set; }
        
        public List<BrickShape> Shapes { get; set; }

        public Dictionary<string, string> RegisteredBehaviors { get; set; } //type, guid

        [JsonIgnore]
        public List<BrickBehavior> Behaviors { get; set; }

        public BrickEntity()
        {
            OtherEntities = new List<BrickEntity>();
            Id = Guid.NewGuid().ToString();
            Properties = new List<EntityProperty>();
            Relationships = new List<BrickRelationship>();
            Shapes = new List<BrickShape>();
            RegisteredBehaviors = new Dictionary<string, string>();
            Behaviors = new List<BrickBehavior>();

            Type = null;
        }

    
        public List<BrickEntity> GetChildEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(AssociatedWith).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            entities.AddRange(GetFedEntitites().Except(entities));
            entities.AddRange(GetMeterEntities().Except(entities));
            entities.AddRange(GetPartEntitites().Except(entities));
            entities.AddRange(GetPointEntities().Except(entities));
            return entities;
        }

        public List<BrickEntity> GetFedEntitites()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(Fedby).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetMeterEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(MeterBy).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }
        public List<BrickEntity> GetPartEntitites()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PartOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            return entities;
        }
        public List<Classes.Point> GetPointEntities()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PointOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();

            List<Classes.Point> points = new List<Classes.Point>();
            foreach (var entity in entities)
            {
                points.Add((Classes.Point)entity);
            }

            return points;
        }

        public List<Classes.Point> GetPointEntities(List<Tag> tags)
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(PointOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();

            List<Classes.Point> points = new List<Classes.Point>();
            foreach (var entity in entities)
            {
                var foundTags = entity.GetTags();
                foreach (var tag in foundTags)
                {
                    if (tags.Any(x=>x.Type.Equals(tag.Type)))
                    {
                        points.Add((Classes.Point)entity);
                    }
                }
            }

            return points;
        }

        public List<Tag> GetTags()
        {
            var tags = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => (relationship.Type?.Equals(typeof(TagOf).Name) ?? false) && relationship.ParentId == this.Id))
            .ToList();
            List<Tag> foundTags = new List<Tag>();
            foreach (var tag in tags)
            {
                foundTags.Add(tag as Tag);
            }
            return foundTags;
        }

        public List<BrickEntity> GetFeedingParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(Fedby).Name) ?? false))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetMeetingParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(MeterBy).Name) ?? false))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetPartOfParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(PartOf).Name) ?? false))
            .ToList();
            return entities;
        }

        public List<BrickEntity> GetPointOfParent()
        {
            var entities = OtherEntities
            .Where(entity => entity.Relationships.Any(relationship => relationship.Type?.Equals(typeof(PointOf).Name) ?? false))
            .ToList();
            return entities;
        }


        #region Properties

        public void AddOrUpdateProperty<T>(string propertyName, T propertyValue)
        {
            EntityProperty? property = Properties.FirstOrDefault(x => x.Name.Equals(propertyName));
            if (property == null)
            {
                property = new EntityProperty();
                property.SetValue(propertyName, propertyValue);
                Properties.Add(property);
            }
            else
            {
                property.SetValue(propertyName, propertyValue);
            }
        }

        public void AddOrUpdateProperty<T>(PropertiesEnum property, T propertyValue)
        {
            AddOrUpdateProperty(property.ToString(), propertyValue);
        }
        public T? GetProperty<T>(string propertyName)
        {
            EntityProperty? property = Properties.FirstOrDefault(x => x.Name.Equals(propertyName));
            if (property != null)
            {
                return property.GetValue<T>();
            }
            
            return default(T?);
        }

        public T? GetProperty<T>(PropertiesEnum property)
        {
            return GetProperty<T>(property.ToString());
        }

        #endregion Properties


        #region Relationships

        public T AddRelationship<T>(string parentId) where T : BrickRelationship, new()
        {
            T relationship = new T
            {
                Id = Guid.NewGuid().ToString(),
                Type = typeof(T).Name,
                ParentId = parentId,
            };

            Relationships.Add(relationship);
            return relationship;
        }

        public List<BrickRelationship> GetRelationships()
        {
            return Relationships;
        }

        //Relationship
        public AssociatedWith AddRelationshipAssociatedWith(string parentId) => AddRelationship<AssociatedWith>(parentId);
        public Fedby AddRelationshipFedBy(string parentId) => AddRelationship<Fedby>(parentId);

        public LocationOf AddRelationshipLocationOf(string parentId) => AddRelationship<LocationOf>(parentId);
        
        public MeterBy AddRelationshipMeterBy(string parentId) => AddRelationship<MeterBy>(parentId);

        public PointOf AddRelationshipPointOf(string parentId) => AddRelationship<PointOf>(parentId);

        public PartOf AddRelationshipPartOf(string parentId) => AddRelationship<PartOf>(parentId);

        public TagOf AddRelationshipTagOf(string parentId) => AddRelationship<TagOf>(parentId);

        public SubmeterOf AddRelationshipSubmeterOf(string parentId) => AddRelationship<SubmeterOf>(parentId);

        #endregion Relationships

        #region Shapes
        public T AddShape<T>() where T : BrickShape, new()
        {
            T shape = new T
            {
                Id = Guid.NewGuid().ToString(),
                Type = typeof(T).Name,

            };

            Shapes.Add(shape);
            return shape;
        }

        public List<BrickShape> GetShapes()
        {
            return Shapes;
        }
        //Shape

        public AbsoluteHumidity AddShape() => AddShape<AbsoluteHumidity>();
        public ActiveEnergy AddShapeActiveEnergy() => AddShape<ActiveEnergy>();
        public ActivePower AddShapeActivePower() => AddShape<ActivePower>();
        public Aggregation AddShapeAggregation() => AddShape<Aggregation>();
        public AlternatingCurrentFrequency AddShapeAlternatingCurrentFrequency() => AddShape<AlternatingCurrentFrequency>();
        public AmmoniaConcentration AddShapeAmmoniaConcentration() => AddShape<AmmoniaConcentration>();
        public Angle AddShapeAngle() => AddShape<Angle>();
        public ApparentEnergy AddShapeApparentEnergy() => AddShape<ApparentEnergy>();
        public ApparentPower AddShapeApparentPower() => AddShape<ApparentPower>();
        public Area AddShapeArea() => AddShape<Area>();
        public AtmosphericPressure AddShapeAtmosphericPressure() => AddShape<AtmosphericPressure>();
        public Azimuth AddShapeAzimuth() => AddShape<Azimuth>();
        public BACnetReference AddShapeBACnetReference() => AddShape<BACnetReference>();
        public BuildingMeterRule AddShapeBuildingMeterRule() => AddShape<BuildingMeterRule>();
        public BuildingPrimaryFunction AddShapeBuildingPrimaryFunction() => AddShape<BuildingPrimaryFunction>();
        public CO2Concentration AddShapeCO2Concentration() => AddShape<CO2Concentration>();
        public COConcentration AddShapeCOConcentration() => AddShape<COConcentration>();
        public ComplexPower AddShapeComplexPower() => AddShape<ComplexPower>();

        public Conductivity AddShapeConductivity() => AddShape<Conductivity>();
        public CoolingCapacity AddShapeCoolingCapacity() => AddShape<CoolingCapacity>();
        public Coordinate AddShapeCoordinate() => AddShape<Coordinate>();
        public CurrentFlowType AddShapeCurrentFlowType() => AddShape<CurrentFlowType>();

        public CurrentAngle AddShapeCurrentAngle() => AddShape<CurrentAngle>();


        public CurrentImbalance AddShapeCurrentImbalance() => AddShape<CurrentImbalance>();


        public CurrentTotalHarmonicDistortion AddShapeCurrentTotalHarmonicDistortion() => AddShape<CurrentTotalHarmonicDistortion>();


        public DeprecationRule AddShapeDeprecationRule() => AddShape<DeprecationRule>();

        public DeprecationRuleForInstances AddShapeDeprecationRuleForInstances() => AddShape<DeprecationRuleForInstances>();


        public Deprecation AddShapeDeprecation() => AddShape<Deprecation>();

        public Dewpoint AddShapeDewpoint() => AddShape<Dewpoint>();


        public DifferentialCO2Concentration AddShapeDifferentialCO2Concentration() => AddShape<DifferentialCO2Concentration>();

        public DifferentialCOConcentration AddShapeDifferentialCOConcentration() => AddShape<DifferentialCOConcentration>();


        public DifferentialDynamicPressure AddShapeDifferentialDynamicPressure() => AddShape<DifferentialDynamicPressure>();

        public DifferentialStaticPressure AddShapeDifferentialStaticPressure() => AddShape<DifferentialStaticPressure>();


        public DifferentialTemperature AddShapeDifferentialTemperature() => AddShape<DifferentialTemperature>();


        public DryBulbTemperature AddShapeDryBulbTemperature() => AddShape<DryBulbTemperature>();

        public Efficiency AddShapeEfficiency() => AddShape<Efficiency>();


        public ElectricCurrent AddShapeElectricCurrent() => AddShape<ElectricCurrent>();

        public ElectricEnergy AddShapeElectricEnergy() => AddShape<ElectricEnergy>();

        public ElectricPower AddShapeElectricPower() => AddShape<ElectricPower>();

        public Enthalpy AddShapeEnthalpy() => AddShape<Enthalpy>();

        public ExternalReference AddShapeExternalReference() => AddShape<ExternalReference>();

        public Flow AddShapeFlow() => AddShape<Flow>();


        public FlowLoss AddShapeFlowLoss() => AddShape<FlowLoss>();


        public FormaldehydeConcentration AddShapeFormaldehydeConcentration() => AddShape<FormaldehydeConcentration>();


        public Frequency AddShapeFrequency() => AddShape<Frequency>();

        public GrainsOfMoisture AddShapeGrainsOfMoisture() => AddShape<GrainsOfMoisture>();


        public IFCReference AddShapeIFCReference() => AddShape<IFCReference>();


        public Illuminance AddShapeIlluminance() => AddShape<Illuminance>();

        public InferInverseProperties AddShapeInferInverseProperties() => AddShape<InferInverseProperties>();


        public InferSymmetricProperties AddShapeInferSymmetricProperties() => AddShape<InferSymmetricProperties>();

        public Irradiance AddShapeIrradiance() => AddShape<Irradiance>();


        public LastKnownValue AddShapeLastKnownValue() => AddShape<LastKnownValue>();

        public Level AddShapeLevel() => AddShape<Level>();


        public LinearSpeed AddShapeLinearSpeed() => AddShape<LinearSpeed>();


        public Luminance AddShapeLuminance() => AddShape<Luminance>();

        public LuminousFlux AddShapeLuminousFlux() => AddShape<LuminousFlux>();

        public LuminousIntensity AddShapeLuminousIntensity() => AddShape<LuminousIntensity>();

        public Mass AddShapeMass() => AddShape<Mass>();


        public MeterRelationshipRule AddShapeMeterRelationshipRule() => AddShape<MeterRelationshipRule>();

        public MethaneConcentration AddShapeMethaneConcentration() => AddShape<MethaneConcentration>();

        public NO2Concentration NO2Concentration() => AddShape<NO2Concentration>();

        public OWLEquivalentClassRule1 AddShapeOWLEquivalentClassRule1() => AddShape<OWLEquivalentClassRule1>();


        public OWLEquivalentClassRule2 AddShapeOWLEquivalentClassRule2() => AddShape<OWLEquivalentClassRule2>();

        public OccupancyPercentage AddShapeOccupancyPercentage() => AddShape<OccupancyPercentage>();

        public OneLastKnownValuePerEntity AddShapeOneLastKnownValuePerEntity() => AddShape<OneLastKnownValuePerEntity>();


        public OperativeTemperature AddShapeOperativeTemperature() => AddShape<OperativeTemperature>();


        public OzoneConcentration AddShapeOzoneConcentration() => AddShape<OzoneConcentration>();


        public PM10Concentration AddShapePM10Concentration() => AddShape<PM10Concentration>();


        public PM1Concentration AddShapePM1Concentration() => AddShape<PM1Concentration>();


        public PM2p5Concentration AddShapePM2p5Concentration() => AddShape<PM2p5Concentration>();

        public PeakPower AddShapePeakPower() => AddShape<PeakPower>();

        public PhaseCount AddShapePhaseCount() => AddShape<PhaseCount>();


        public Phases AddShapePhases() => AddShape<Phases>();

        public PhasorAngle AddShapePhasorAngle() => AddShape<PhasorAngle>();

        public PhasorMagnitude AddShapePhasorMagnitude() => AddShape<PhasorMagnitude>();

        public Position AddShapePosition() => AddShape<Position>();


        public PowerComplexity AddShapePowerComplexity() => AddShape<PowerComplexity>();

        public PowerFlow AddShapePowerFlow() => AddShape<PowerFlow>();


        public Power AddShapePower() => AddShape<Power>();

        public PowerFactor AddShapePowerFactor() => AddShape<PowerFactor>();

        public Precipitation AddShapePrecipitation() => AddShape<Precipitation>();


        public Pressure AddShapePressure() => AddShape<Pressure>();

        public RDFSRangeRule AddShapeRDFSRangeRule() => AddShape<RDFSRangeRule>();


        public RDFSSubPropertyOfRule AddShapeRDFSSubPropertyOfRule() => AddShape<RDFSSubPropertyOfRule>();

        public Radiance AddShapeRadiance() => AddShape<Radiance>();


        public RadiantTemperature AddShapeRadiantTemperature() => AddShape<RadiantTemperature>();


        public RadonConcentration AddShapeRadonConcentration() => AddShape<RadonConcentration>();


        public ReactiveEnergy AddShapeReactiveEnergy() => AddShape<ReactiveEnergy>();


        public ReactivePower AddShapeReactivePower() => AddShape<ReactivePower>();


        public RealPower AddShapeRealPower() => AddShape<RealPower>();


        public RelativeHumidity AddShapeRelativeHumidity() => AddShape<RelativeHumidity>();


        public RotationalSpeed AddShapeRotationalSpeed() => AddShape<RotationalSpeed>();


        public SolarIrradiance AddShapeSolarIrradiance() => AddShape<SolarIrradiance>();


        public SolarRadiance AddShapeSolarRadiance() => AddShape<SolarRadiance>();


        public Speed AddShapeSpeed() => AddShape<Speed>();

        public Stage AddShapeStage() => AddShape<Stage>();


        public StaticPressure AddShapeStaticPressure() => AddShape<StaticPressure>();


        public TVOCConcentration AddShapeTVOCConcentration() => AddShape<TVOCConcentration>();


        public TagInferenceRule AddShapeTagInferenceRule() => AddShape<TagInferenceRule>();

        public TemperatureCoefficientPerDegreeCelsius AddShapeTemperatureCoefficientPerDegreeCelsius() => AddShape<TemperatureCoefficientPerDegreeCelsius>();


        public Temperature AddShapeTemperature() => AddShape<Temperature>();

        public ThermalTransmittance AddShapeThermalTransmittance() => AddShape<ThermalTransmittance>();


        public ThermalEnergy AddShapeThermalEnergy() => AddShape<ThermalEnergy>();


        public ThermalPower AddShapeThermalPower() => AddShape<ThermalPower>();


        public Tilt AddShapeTilt() => AddShape<Tilt>();

        public Time AddShapeTime() => AddShape<Time>();


        public TimeseriesReference AddShapeTimeseriesReference() => AddShape<TimeseriesReference>();

        public TimeseriesReferenceOnPointsConstraint AddShapeTimeseriesReferenceOnPointsConstraint() => AddShape<TimeseriesReferenceOnPointsConstraint>();



        public Torque AddShapeTorque() => AddShape<Torque>();


        public VelocityPressure AddShapeVelocityPressure() => AddShape<VelocityPressure>();


        public VirtualMeterRule AddShapeVirtualMeterRule() => AddShape<VirtualMeterRule>();

        public VirtualMeter AddShapeVirtualMeter() => AddShape<VirtualMeter>();


        public Voltage AddShapeVoltage() => AddShape<Voltage>();

        public VoltageAngle AddShapeVoltageAngle() => AddShape<VoltageAngle>();

        public VoltageImbalance AddShapeVoltageImbalance() => AddShape<VoltageImbalance>();

        public Volume AddShapeVolume() => AddShape<Volume>();


        public WetBulbTemperature AddShapeWetBulbTemperature() => AddShape<WetBulbTemperature>();

        public WindDirection AddShapeWindDirection() => AddShape<WindDirection>();

        public YearBuilt AddShapeYearBuilt() => AddShape<YearBuilt>();

        #endregion Shapes

        #region Behaviors
        public BrickBehavior AddBehavior(BrickBehavior behavior)
        {
           
            var behaviors = GetBehaviors(behavior.Type);
            if (behaviors.Count > 1)
            {
                RemoveBehavior(behavior.Type);
                
                
            }
            else if (behaviors.Count == 1)
            {
                return behaviors[0];
            }

            if (RegisteredBehaviors.ContainsKey(behavior.Type))
            {
                behavior.Id = RegisteredBehaviors[behavior.Type];
            } else
            {
                RegisteredBehaviors.Add(behavior.Type, behavior.Id);
            }

            behavior.Parent = this; //must set this before start
            behavior.Start();
            Behaviors.Add(behavior);
            return behavior;
        }

        public void RemoveBehavior(string type)
        {
            var behaviors = GetBehaviors(type);
            foreach (var behavior in behaviors)
            {
                behavior.Stop();
                Behaviors.Remove(behavior);
            }
        }

        public List<BrickBehavior> GetBehaviors()
        {
            return Behaviors;
        }

        public List<BrickBehavior> GetBehaviors(string type)
        {
            return Behaviors.Where(x=>x.Type == type).ToList();
        }


        #endregion Behaviors
    }
}