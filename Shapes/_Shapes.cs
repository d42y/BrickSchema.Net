using BrickSchema.Net.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Keep namespace as BirckSchema.Net
namespace BrickSchema.Net
{
    /// <summary>
    /// This class is part of BrickEnity. Placing in this folder for organization purpose only.
    /// </summary>
    public partial class BrickEntity
    {

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

    }
}
