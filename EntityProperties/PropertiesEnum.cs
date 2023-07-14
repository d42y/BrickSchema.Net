using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net.EntityProperties
{
    public enum PropertiesEnum
    {

        //Genral
        Name = 0,
        Description = 1,
        BrickClass,
        Info,
        Value,
        Timestamp,
        ValueQuality,

        //behavior
        PollRate = 100,
        Runable,
        Running,
        Insight,
        Resoltuion,
        ExecutionReturnCode,
        ExecutionExceptionMessage,
        LastExecutionStart,
        LastExecutionEnd,
        BehaviorType,
        BehaviorMode,
        Errors,
        HasError,
        BehaviorValues,


        //analytics
        Conformance = 200,
        Deviation,
        Weight,

        

        Aggregate = 300,

        //area
        Area = 400,
        GrossArea,
        NetArea,
        PanelArea,

        Azimuth,

        BuildingPrimaryFunction,

        //Conversion Efficiency
        ConversionEfficiency = 500,
        MeasuredModuleConversionEfficiency,
        RatedModuleconversionEfficiency,

        CoolingCapacity,

        //Cordinates
        Cordinates = 600,
        LatitudeCordinate,
        LongitudeCordinate,
        ElevationCordinate,

        CurrentFlowtype = 700,
        RatedCurrentInput,
        RatedMaximumCurrentInput,
        RatedMinimumCurrentInput,
        RatedCurrentOutput,
        RatedMaximumCurrentOutput,
        RatedMinimumCurrentOutput,

        Deprecation,

        ElectricalPhaseCount,
        ElectricalPhases,
        ElectricalPhaseA,
        ElectricalPhaseB,
        ElectricalPhaseC,

        IsVirtualMeter,

        LastKnownValue,

        MeasuredPowerInput,
        MeasuredPowerOutput,

        OperationalStage,
        OperationalStageCount,

        PowerComplexity,
        PowerFlow,
        RatedPowerInput,
        RatedPowerOutput,
        RatedVoltageInput,
        RatedVoltageOutput,

        TemperatureCoefficientOfPmax,

        ThermalTransmittance,
        BuildingThermalTransmittance,

        Tilt,

        Volume,

        YearBuilt,

        Unit,

        //chiller
        COP,
    }
}
