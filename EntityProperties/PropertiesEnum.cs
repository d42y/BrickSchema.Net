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

        //behavior
        PollRate = 100,
        Running = 101,
        Insight = 102,
        Resoltuion = 103,

        //analytics
        Conformance = 200,
        


        Aggregate= 300,

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

    }
}
