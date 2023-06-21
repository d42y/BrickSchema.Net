using System;
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
    public class BrickSchemaManager
    {
        private List<dynamic> _entities;
        private readonly string? _brickPath;


        public BrickSchemaManager()
        {
            _entities = new List<dynamic>();
        }

        public BrickSchemaManager(string brickFilePath)
        {
            _entities = new List<dynamic>();
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
                if (existingEntity != null) return existingEntity;
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
            if (!string.IsNullOrEmpty(id))
            {
               
                
                var existingEntity = _entities.FirstOrDefault(x=>x.Id.Equals(id));
                if (existingEntity != null) return existingEntity;
            }
            T entity = new T
            {
                Id = id??Guid.NewGuid().ToString(),
                Type = typeof(T).Name
            };

            foreach (var _e in _entities)
            {
                entity.OtherEntities.Add(_e);
            }

            _entities.Add(entity);
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

        public BrickEntity? GetEntity(string id)
        {
            return _entities.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Tag? GetTag(string name)
        {
            var tags = _entities.Where(x => (x.Type?.Equals(typeof(Tag).Name) ?? false)).ToList();
            if (tags == null) return null;
            if (tags.Count == 0) return null;
            foreach (var tag in tags)
            {
                var t = tag as Tag;
                if (t.Name.Equals(name)) return t; 
            }
            return null;
        }

        public List<BrickEntity> GetEquipments(List<string> equipmentIds)
        {
            List<BrickEntity> entities = new List<BrickEntity>();

            foreach (var entity in _entities)
            {
                if (entity is Equipment)
                {
                    entities.Add(entity);
                }
            }

            if (equipmentIds.Count > 0)
            {
                entities = entities.Where(x => equipmentIds.Contains(x.Id)).ToList();
            }
            return entities;
        }

        public List<BrickBehavior> GetBehaviors(List<string> behaviorIds)
        {
            List<BrickBehavior> brickBehaviors = new List<BrickBehavior>();
            foreach (var entity in _entities)
            {
                var e = entity as BrickEntity;
                brickBehaviors.AddRange(e?.Behaviors.Where(x => behaviorIds.Contains(x.Id) || behaviorIds.Count == 0)??new List<BrickBehavior>());
            }

            return brickBehaviors;
        }

        public List<BrickBehavior> GetEquipmentBehaviors(string equipmentId)
        {
            var equipments = GetEquipments(new() { equipmentId });

            List<BrickBehavior> brickBehaviors = new();
            foreach (var entity in equipments)
            {
                var e = entity as BrickEntity;
                brickBehaviors.AddRange(e?.Behaviors ?? new List<BrickBehavior>());
            }

            return brickBehaviors;
        }

        //tenant
        public Tenant AddTenant(string? id = null) => AddEntity<Tenant>(id);

        //add classes
        //Collection
        public Loop AddCollectionLoop(string? id = null) => AddEntity<Loop>(id);
        public Air AddCollectionLoopAir(string? id = null) => AddEntity<Air>(id);
        public Water AddCollectionLoopWater(string? id = null) => AddEntity<Water>(id);
        public ChilledWater AddCollectionLoopChilledWater(string? id = null) => AddEntity<ChilledWater>(id);
        public DomesticWater AddCollectionLoopDomesticWater(string? id = null) => AddEntity<DomesticWater>(id);
        public HotWater AddCollectionLoopHotWater(string? id = null) => AddEntity<HotWater>(id);
        public HeatingWater AddCollectionLoopHeatingWater(string? id = null) => AddEntity<HeatingWater>(id);
        
        public PVArray AddCollectionPVArray(string? id = null) => AddEntity<PVArray>(id);
        public PhotovoltaicArray AddCollectionPhotovoltaicArray(string? id = null) => AddEntity<PhotovoltaicArray>(id);
        public Portfolio AddCollectionPortfolio(string? id = null) => AddEntity<Portfolio>(id);
        public BrickSchema.Net.Classes.Collection.System AddCollectionSystem(string? id = null) => AddEntity<BrickSchema.Net.Classes.Collection.System>(id);

        //Devices
        public BACnetDevice AddBACnetDevice(string? id = null) => AddEntity<BACnetDevice>(id);
        public ModbusDevice AddModbusDevice(string? id = null) => AddEntity<ModbusDevice>(id);
        public Workstation AddWorkstation(string? id = null) => AddEntity<Workstation>(id);
        public Server AddServer(string? id = null) => AddEntity<Server>(id);

        //Equipment
        public Camera AddEquipmentCamera(string? id = null) => AddEntity<Camera>(id);
        public Electrical AddEquipmentElectrical(string? id = null) => AddEntity<Electrical>(id);
        public Elevator AddEquipmentElevator(string? id = null) => AddEntity<Elevator>(id);
        public FireSafety AddEquipmentFireSafety(string? id = null) => AddEntity<FireSafety>(id);
        public Furniture AddEquipmentFurniture(string? id = null) => AddEntity<Furniture>(id);
        public GasDistribution AddEquipmentGasDistribution(string? id = null) => AddEntity<GasDistribution>(id);

        //HVAC
        public HVAC AddEquipmentHVAC(string? id = null) => AddEntity<HVAC>(id);

        public  AHU AddEquipmentHVACAHU(string? id = null) => AddEntity<AHU>(id);
        public  AirHandlerUnit AddEquipmentHVACAirHandlerUnit(string? id = null) => AddEntity<AirHandlerUnit>(id);
        public  AirHandlingUnit AddEquipmentHVACAirHandlingUnit(string? id = null) => AddEntity<AirHandlingUnit>(id);
        public  AirPlenum AddEquipmentHVACAirPlenum(string? id = null) => AddEntity<AirPlenum>(id);
        public  Boiler AddEquipmentHVACBoiler(string? id = null) => AddEntity<Boiler>(id);
        public  BypassValve AddEquipmentHVACBypassValve(string? id = null) => AddEntity<BypassValve>(id);
        public  CRAC AddEquipmentHVACCRAC(string? id = null) => AddEntity<CRAC>(id);
        public  CRAH AddEquipmentHVACCRAH(string? id = null) => AddEntity<CRAH>(id);
        //chiller
        public  Chiller AddEquipmentHVACChiller(string? id = null) => AddEntity<Chiller>(id);
        public AbsorptionChiller AddEquipmentHVACChillerAbsorptionChiller(string? id = null) => AddEntity<AbsorptionChiller>(id);
        public CentrifugalChiller AddEquipmentHVACChillerCentrifugalChiller(string? id = null) => AddEntity<CentrifugalChiller>(id);


        public  ColdDeck AddEquipmentHVACColdDeck(string? id = null) => AddEntity<ColdDeck>(id);
        public  Compressor AddEquipmentHVACCompressor(string? id = null) => AddEntity<Compressor>(id);
        public  ComputerRoomAirConditioning AddEquipmentHVACComputerRoomAirConditioning(string? id = null) => AddEntity<ComputerRoomAirConditioning>(id);
        public  ComputerRoomAirHandler AddEquipmentHVACComputerRoomAirHandler(string? id = null) => AddEntity<ComputerRoomAirHandler>(id);
        public  Condenser AddEquipmentHVACCondenser(string? id = null) => AddEntity<Condenser>(id);
        public  CoolingTower AddEquipmentHVACCoolingTower(string? id = null) => AddEntity<CoolingTower>(id);
        public  CoolingValve AddEquipmentHVACCoolingValve(string? id = null) => AddEntity<CoolingValve>(id);
        //damper
        public  Damper AddEquipmentHVACDamper(string? id = null) => AddEntity<Damper>(id);
        public EconomizerDamper AddEquipmentHVACDamperEconomizerDamper(string? id = null) => AddEntity<EconomizerDamper>(id);
        public ExhaustDamper AddEquipmentHVACDamperExhaustDamper(string? id = null) => AddEntity<ExhaustDamper>(id);
        public FireSmokeDamper AddEquipmentHVACDamperFireSmokeDamper(string? id = null) => AddEntity<FireSmokeDamper>(id);
        public MixedDamper AddEquipmentHVACDamperMixedDamper(string? id = null) => AddEntity<MixedDamper>(id);
        public OutsideDamper AddEquipmentHVACDamperOutsideDamper(string? id = null) => AddEntity<OutsideDamper>(id);
        public ReliefDamper AddEquipmentHVACDamperReliefDamper(string? id = null) => AddEntity<ReliefDamper>(id);
        public ReturnDamper AddEquipmentHVACDamperReturnDamper(string? id = null) => AddEntity<ReturnDamper>(id);



        public  DryCooler AddEquipmentHVACDryCooler(string? id = null) => AddEntity<DryCooler>(id);
        public  Economizer AddEquipmentHVACEconomizer(string? id = null) => AddEntity<Economizer>(id);

        //Fan
        public  Fan AddEquipmentHVACFan(string? id = null) => AddEntity<Fan>(id);
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
        public  Filter AddEquipmentHVACFilter(string? id = null) => AddEntity<Filter>(id);
        public FinalFilter AddEquipmentHVACFilterFinalFilter(string? id = null) => AddEntity<FinalFilter>(id);
        public IntakeAirFilter AddEquipmentHVACFilterIntakeAirFilter(string? id = null) => AddEntity<IntakeAirFilter>(id);
        public MixedAirFilter AddEquipmentHVACFilterMixedAirFilter(string? id = null) => AddEntity<MixedAirFilter>(id);
        public PreFilter AddEquipmentHVACFilterPreFilter(string? id = null) => AddEntity<PreFilter>(id);
        public ReturnAirFilter AddEquipmentHVACFilterReturnAirFilter(string? id = null) => AddEntity<ReturnAirFilter>(id);


        public  FumeHood AddEquipmentHVACFumeHood(string? id = null) => AddEntity<FumeHood>(id);
        public Classes.Equipments.HVACType.Valve AddEquipmentHVACValve(string? id = null) => AddEntity<Classes.Equipments.HVACType.Valve>(id);
        public  HX AddEquipmentHVACHX(string? id = null) => AddEntity<HX>(id);
        public  HeatExchanger AddEquipmentHVACHeatExchanger(string? id = null) => AddEntity<HeatExchanger>(id);
        public  HeatingValve AddEquipmentHVACHeatingValve(string? id = null) => AddEntity<HeatingValve>(id);
        public  HotDeck AddEquipmentHVACHotDeck(string? id = null) => AddEntity<HotDeck>(id);
        public  Humidifier AddEquipmentHVACHumidifier(string? id = null) => AddEntity<Humidifier>(id);
        public  IsolationValve AddEquipmentHVACIsolationValve(string? id = null) => AddEntity<IsolationValve>(id);
        public  Pump AddEquipmentHVACPump(string? id = null) => AddEntity<Pump>(id);
        public  SpaceHeater AddEquipmentHVACSpaceHeater(string? id = null) => AddEntity<SpaceHeater>(id);
        public  SteamValve AddEquipmentHVACSteamValve(string? id = null) => AddEntity<SteamValve>(id);
        public  Thermostat AddEquipmentHVACThermostat(string? id = null) => AddEntity<Thermostat>(id);

        //HVAC Terminal Unit
        public TerminalUnit AddEquipmentHVACTerminalUnit(string? id = null) => AddEntity<TerminalUnit>(id);

        public  AirDiffuser AddEquipmentHVACTerminalUnitAirDiffuser(string? id = null) => AddEntity<AirDiffuser>(id);
        public  CAV AddEquipmentHVACTerminalUnitCAV(string? id = null) => AddEntity<CAV>(id);
        public  ChilledBeam AddEquipmentHVACTerminalUnitChilledBeam(string? id = null) => AddEntity<ChilledBeam>(id);
        public  ConstantAirVolumeBox AddEquipmentHVACTerminalUnitConstantAirVolumeBox(string? id = null) => AddEntity<ConstantAirVolumeBox>(id);
        public  FCU AddEquipmentHVACTerminalUnitFCU(string? id = null) => AddEntity<FCU>(id);
        public  FanCoilUnit AddEquipmentHVACTerminalUnitFanCoilUnit(string? id = null) => AddEntity<FanCoilUnit>(id);
        public  InductionUnit AddEquipmentHVACTerminalUnitInductionUnit(string? id = null) => AddEntity<InductionUnit>(id);
        public  RadiantPanel AddEquipmentHVACTerminalUnitRadiantPanel(string? id = null) => AddEntity<RadiantPanel>(id);
        public  Radiator AddEquipmentHVACTerminalUnitRadiator(string? id = null) => AddEntity<Radiator>(id);
        //VAV
        public  VAV AddEquipmentHVACTerminalUnitVAV(string? id = null) => AddEntity<VAV>(id);
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


        //location
        public Building AddLocationBuilding(string? id = null) => AddEntity<Building>(id);
        public Floor AddLocationFloor(string? id = null) => AddEntity<Floor>(id);
        public OutdoorArea AddLocationOutdoorArea(string? id = null) => AddEntity<OutdoorArea>(id);
        public Outside AddLocationOutside(string? id = null) => AddEntity<Outside>(id);
        public Region AddLocationRegion(string? id = null) => AddEntity<Region>(id);
        public Site AddLocationSite(string? id = null) => AddEntity<Site>(id);
        public Space AddLocationSpace(string? id = null) => AddEntity<Space>(id);
        public CommonSpace AddLocationCommonSpace(string? id = null) => AddEntity<CommonSpace>(id);
        public Entrance AddLocationEntrance(string? id = null) => AddEntity<Entrance>(id);
        public GateHouse AddLocationGateHouse(string? id = null) => AddEntity<GateHouse>(id);
        public MediaHotDesk AddLocationMediaHotDesk(string? id = null) => AddEntity<MediaHotDesk>(id);
        public Parking AddLocationParking(string? id = null) => AddEntity<Parking>(id);
        public Room AddLocationRoom(string? id = null) => AddEntity<Room>(id);
        public TicketingBooth AddLocationTicketingBooth(string? id = null) => AddEntity<TicketingBooth>(id);
        public Tunnel AddLocationTunnel(string? id = null) => AddEntity<Tunnel>(id);
        public VerticalSpace AddLocationVerticalSpace(string? id = null) => AddEntity<VerticalSpace>(id);
        public WaterTank AddLocationWaterTank(string? id = null) => AddEntity<WaterTank>(id);
        public Storey AddLocationStorey(string? id = null) => AddEntity<Storey>(id);
        public Wing AddLocationWing(string? id = null) => AddEntity<Wing>(id);
        public Zone AddLocationZone(string? id = null) => AddEntity<Zone>(id);


        //Measureable
        public Quantity AddMeasurableQuantity(string? id = null) => AddEntity<Quantity>(id);
        public Substance AddMeasurableSubstance(string? id = null) => AddEntity<Substance>(id);


        //point

        public Alarm AddPointAlarm(string? id = null) => AddEntity<Alarm>(id);
        public Command AddPointCommand(string? id = null) => AddEntity<Command>(id);
        public Parameter AddPointParameter(string? id = null) => AddEntity<Parameter>(id);
        public Sensor AddPointSensor(string? id = null) => AddEntity<Sensor>(id);
        public Setpoint AddPointSetpoint(string? id = null) => AddEntity<Setpoint>(id);
        public Status AddPointStatus(string? id = null) => AddEntity<Status>(id);

        //Tag
        public Tag AddTag(string name)
        {
            Tag? tag = null;
            tag = GetTag(name);
            if (tag == null)
            {
                tag = AddEntity<Tag>();
                tag.Name = name;
            }
            return tag;
        }
    }
}
