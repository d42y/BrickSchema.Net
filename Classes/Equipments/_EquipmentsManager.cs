using BrickSchema.Net.Classes.Equipments;
using BrickSchema.Net.Classes.Equipments.HVACType;
using BrickSchema.Net.Classes.Equipments.HVACType.TerminalUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //Equipment
        public Camera AddEquipmentCamera(string? id = null) => AddEntity<Camera>(id);
        public Electrical AddEquipmentElectrical(string? id = null) => AddEntity<Electrical>(id);
        public Elevator AddEquipmentElevator(string? id = null) => AddEntity<Elevator>(id);
        public FireSafety AddEquipmentFireSafety(string? id = null) => AddEntity<FireSafety>(id);
        public Furniture AddEquipmentFurniture(string? id = null) => AddEntity<Furniture>(id);
        public GasDistribution AddEquipmentGasDistribution(string? id = null) => AddEntity<GasDistribution>(id);

        //HVAC
        public HVAC AddEquipmentHVAC(string? id = null) => AddEntity<HVAC>(id);

        public AHU AddEquipmentHVACAHU(string? id = null) => AddEntity<AHU>(id);
        public AirHandlerUnit AddEquipmentHVACAirHandlerUnit(string? id = null) => AddEntity<AirHandlerUnit>(id);
        public AirHandlingUnit AddEquipmentHVACAirHandlingUnit(string? id = null) => AddEntity<AirHandlingUnit>(id);
        public AirPlenum AddEquipmentHVACAirPlenum(string? id = null) => AddEntity<AirPlenum>(id);
        public Boiler AddEquipmentHVACBoiler(string? id = null) => AddEntity<Boiler>(id);
        public BypassValve AddEquipmentHVACBypassValve(string? id = null) => AddEntity<BypassValve>(id);
        public CRAC AddEquipmentHVACCRAC(string? id = null) => AddEntity<CRAC>(id);
        public CRAH AddEquipmentHVACCRAH(string? id = null) => AddEntity<CRAH>(id);
        //chiller
        public Chiller AddEquipmentHVACChiller(string? id = null) => AddEntity<Chiller>(id);
        public AbsorptionChiller AddEquipmentHVACChillerAbsorptionChiller(string? id = null) => AddEntity<AbsorptionChiller>(id);
        public CentrifugalChiller AddEquipmentHVACChillerCentrifugalChiller(string? id = null) => AddEntity<CentrifugalChiller>(id);


        public ColdDeck AddEquipmentHVACColdDeck(string? id = null) => AddEntity<ColdDeck>(id);
        public Compressor AddEquipmentHVACCompressor(string? id = null) => AddEntity<Compressor>(id);
        public ComputerRoomAirConditioning AddEquipmentHVACComputerRoomAirConditioning(string? id = null) => AddEntity<ComputerRoomAirConditioning>(id);
        public ComputerRoomAirHandler AddEquipmentHVACComputerRoomAirHandler(string? id = null) => AddEntity<ComputerRoomAirHandler>(id);
        public Condenser AddEquipmentHVACCondenser(string? id = null) => AddEntity<Condenser>(id);
        public CoolingTower AddEquipmentHVACCoolingTower(string? id = null) => AddEntity<CoolingTower>(id);
        public CoolingValve AddEquipmentHVACCoolingValve(string? id = null) => AddEntity<CoolingValve>(id);
        //damper
        public Damper AddEquipmentHVACDamper(string? id = null) => AddEntity<Damper>(id);
        public EconomizerDamper AddEquipmentHVACDamperEconomizerDamper(string? id = null) => AddEntity<EconomizerDamper>(id);
        public ExhaustDamper AddEquipmentHVACDamperExhaustDamper(string? id = null) => AddEntity<ExhaustDamper>(id);
        public FireSmokeDamper AddEquipmentHVACDamperFireSmokeDamper(string? id = null) => AddEntity<FireSmokeDamper>(id);
        public MixedDamper AddEquipmentHVACDamperMixedDamper(string? id = null) => AddEntity<MixedDamper>(id);
        public OutsideDamper AddEquipmentHVACDamperOutsideDamper(string? id = null) => AddEntity<OutsideDamper>(id);
        public ReliefDamper AddEquipmentHVACDamperReliefDamper(string? id = null) => AddEntity<ReliefDamper>(id);
        public ReturnDamper AddEquipmentHVACDamperReturnDamper(string? id = null) => AddEntity<ReturnDamper>(id);



        public DryCooler AddEquipmentHVACDryCooler(string? id = null) => AddEntity<DryCooler>(id);
        public Economizer AddEquipmentHVACEconomizer(string? id = null) => AddEntity<Economizer>(id);

        //Fan
        public Fan AddEquipmentHVACFan(string? id = null) => AddEntity<Fan>(id);
        public BoosterFan AddEquipmentHVACFanBoosterFan(string? id = null) => AddEntity<BoosterFan>(id);
        public CeilingFan AddEquipmentHVACFanCeilingFan(string? id = null) => AddEntity<CeilingFan>(id);
        public CoolingTowerFan AddEquipmentHVACFanCoolingTowerFan(string? id = null) => AddEntity<CoolingTowerFan>(id);
        public DischargeFan AddEquipmentHVACFanDischargeFan(string? id = null) => AddEntity<DischargeFan>(id);
        public ExhaustFan AddEquipmentHVACFanExhaustFan(string? id = null) => AddEntity<ExhaustFan>(id);
        public OutsideFan AddEquipmentHVACFanOutsideFan(string? id = null) => AddEntity<OutsideFan>(id);
        public ReliefFan AddEquipmentHVACFanReliefFan(string? id = null) => AddEntity<ReliefFan>(id);
        public ReturnFan AddEquipmentHVACFanReturnFan(string? id = null) => AddEntity<ReturnFan>(id);
        public StandbyFan AddEquipmentHVACFanStandbyFan(string? id = null) => AddEntity<StandbyFan>(id);
        public SupplyFan AddEquipmentHVACFanSupplyFan(string? id = null) => AddEntity<SupplyFan>(id);
        public TransferFan AddEquipmentHVACFanTransferFan(string? id = null) => AddEntity<TransferFan>(id);

        //filter
        public Filter AddEquipmentHVACFilter(string? id = null) => AddEntity<Filter>(id);
        public FinalFilter AddEquipmentHVACFilterFinalFilter(string? id = null) => AddEntity<FinalFilter>(id);
        public IntakeAirFilter AddEquipmentHVACFilterIntakeAirFilter(string? id = null) => AddEntity<IntakeAirFilter>(id);
        public MixedAirFilter AddEquipmentHVACFilterMixedAirFilter(string? id = null) => AddEntity<MixedAirFilter>(id);
        public PreFilter AddEquipmentHVACFilterPreFilter(string? id = null) => AddEntity<PreFilter>(id);
        public ReturnAirFilter AddEquipmentHVACFilterReturnAirFilter(string? id = null) => AddEntity<ReturnAirFilter>(id);


        public FumeHood AddEquipmentHVACFumeHood(string? id = null) => AddEntity<FumeHood>(id);
        public Classes.Equipments.HVACType.Valve AddEquipmentHVACValve(string? id = null) => AddEntity<Classes.Equipments.HVACType.Valve>(id);
        public HX AddEquipmentHVACHX(string? id = null) => AddEntity<HX>(id);
        public HeatExchanger AddEquipmentHVACHeatExchanger(string? id = null) => AddEntity<HeatExchanger>(id);
        public HeatingValve AddEquipmentHVACHeatingValve(string? id = null) => AddEntity<HeatingValve>(id);
        public HotDeck AddEquipmentHVACHotDeck(string? id = null) => AddEntity<HotDeck>(id);
        public Humidifier AddEquipmentHVACHumidifier(string? id = null) => AddEntity<Humidifier>(id);
        public IsolationValve AddEquipmentHVACIsolationValve(string? id = null) => AddEntity<IsolationValve>(id);
        public Pump AddEquipmentHVACPump(string? id = null) => AddEntity<Pump>(id);
        public SpaceHeater AddEquipmentHVACSpaceHeater(string? id = null) => AddEntity<SpaceHeater>(id);
        public SteamValve AddEquipmentHVACSteamValve(string? id = null) => AddEntity<SteamValve>(id);
        public Thermostat AddEquipmentHVACThermostat(string? id = null) => AddEntity<Thermostat>(id);

        //HVAC Terminal Unit
        public TerminalUnit AddEquipmentHVACTerminalUnit(string? id = null) => AddEntity<TerminalUnit>(id);

        public AirDiffuser AddEquipmentHVACTerminalUnitAirDiffuser(string? id = null) => AddEntity<AirDiffuser>(id);
        public CAV AddEquipmentHVACTerminalUnitCAV(string? id = null) => AddEntity<CAV>(id);
        public ChilledBeam AddEquipmentHVACTerminalUnitChilledBeam(string? id = null) => AddEntity<ChilledBeam>(id);
        public ConstantAirVolumeBox AddEquipmentHVACTerminalUnitConstantAirVolumeBox(string? id = null) => AddEntity<ConstantAirVolumeBox>(id);
        public FCU AddEquipmentHVACTerminalUnitFCU(string? id = null) => AddEntity<FCU>(id);
        public FanCoilUnit AddEquipmentHVACTerminalUnitFanCoilUnit(string? id = null) => AddEntity<FanCoilUnit>(id);
        public InductionUnit AddEquipmentHVACTerminalUnitInductionUnit(string? id = null) => AddEntity<InductionUnit>(id);
        public RadiantPanel AddEquipmentHVACTerminalUnitRadiantPanel(string? id = null) => AddEntity<RadiantPanel>(id);
        public Radiator AddEquipmentHVACTerminalUnitRadiator(string? id = null) => AddEntity<Radiator>(id);
        //VAV
        public VAV AddEquipmentHVACTerminalUnitVAV(string? id = null) => AddEntity<VAV>(id);
        public VariableAirVolumeBox AddEquipmentHVACTerminalUnitVariableAirVolumeBox(string? id = null) => AddEntity<VariableAirVolumeBox>(id);
        public RVAV AddEquipmentHVACTerminalUnitVariableAirVolumeBoxRVAV(string? id = null) => AddEntity<RVAV>(id);
        public VariableAirVolumeBoxWithReheat AddEquipmentHVACTerminalUnitVariableAirVolumeBoxWithReheat(string? id = null) => AddEntity<VariableAirVolumeBoxWithReheat>(id);


        public Lighting AddEquipmentLighting(string? id = null) => AddEntity<Lighting>(id);
        public Meter AddEquipmentMeter(string? id = null) => AddEntity<Meter>(id);
        public Motor AddEquipmentMotor(string? id = null) => AddEntity<Motor>(id);
        public PVPanel AddEquipmentPVPanel(string? id = null) => AddEntity<PVPanel>(id);
        public Relay AddEquipmentRelay(string? id = null) => AddEntity<Relay>(id);
        public Safety AddEquipmentSafety(string? id = null) => AddEntity<Safety>(id);
        public Security AddEquipmentSecurity(string? id = null) => AddEntity<Security>(id);
        public SolarThermalCollector AddEquipmentSolarThermalCollector(string? id = null) => AddEntity<SolarThermalCollector>(id);
        public SteamDistribution AddEquipmentSteamDistribution(string? id = null) => AddEntity<SteamDistribution>(id);
        public Classes.Equipments.Valve AddEquipmentValve(string? id = null) => AddEntity<Classes.Equipments.Valve>(id);
        public WaterDistribution AddEquipmentWaterDistribution(string? id = null) => AddEntity<WaterDistribution>(id);

        public WaterHeater AddEquipmentWaterHeater(string? id = null) => AddEntity<WaterHeater>(id);
        public WeatherStation AddEquipmentWeatherStation(string? id = null) => AddEntity<WeatherStation>(id);

    }
}
