using FTN.Common;
using System;
using System.Collections.Generic;
namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{

    /// <summary>
    /// PowerTransformerConverter has methods for populating
    /// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
    /// </summary>
    public static class PowerTransformerConverter
    {

        #region Populate ResourceDescription
        public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
        {
            if ((cimIdentifiedObject != null) && (rd != null))
            {
                if (cimIdentifiedObject.MRIDHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
                }
                if (cimIdentifiedObject.NameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
                }
                if (cimIdentifiedObject.AliasNameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_ALLASNAME, cimIdentifiedObject.AliasName));
                }
            }
        }
        public static void PopulateBasicIntervalScheduleProperties(FTN.BasicIntervalSchedule cimBasicIntervalSchedule, ResourceDescription rd)
        {
            if ((cimBasicIntervalSchedule != null) && (rd != null))
            {
                PopulateIdentifiedObjectProperties(cimBasicIntervalSchedule, rd);

                if (cimBasicIntervalSchedule.StartTimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BASICINTERVALSCHEDULE_STARTTIME, cimBasicIntervalSchedule.StartTime));
                }
                if (cimBasicIntervalSchedule.Value1MultiplierHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BASICINTERVALSCHEDULE_VALUE1MULTIPLIER, (short)cimBasicIntervalSchedule.Value1Multiplier));
                }
                if (cimBasicIntervalSchedule.Value1UnitHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BASICINTERVALSCHEDULE_VALUE1UNIT, (short)cimBasicIntervalSchedule.Value1Unit));
                }
                if (cimBasicIntervalSchedule.Value2MultiplierHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BASICINTERVALSCHEDULE_VALUE2MULTIPLIER, (short)cimBasicIntervalSchedule.Value2Multiplier));
                }
                if (cimBasicIntervalSchedule.Value2UnitHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BASICINTERVALSCHEDULE_VALUE2UNIT, (short)cimBasicIntervalSchedule.Value2Unit));
                }
            }
        }

        public static void PopulateCurveProperties(FTN.Curve cimCurve, ResourceDescription rd)
        {
            if ((cimCurve != null) && (rd != null))
            {
                PopulateIdentifiedObjectProperties(cimCurve, rd);

                if (cimCurve.CurveStyleHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_CURVESTYLE, (short)cimCurve.CurveStyle));
                }
                if (cimCurve.XMultiplierHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_XMULTIPILLER, (short)cimCurve.XMultiplier));
                }
                if (cimCurve.XUnitHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_XUNIT, (short)cimCurve.XUnit));
                }
                if (cimCurve.Y1MultiplierHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_Y1MULTIPILLER, (short)cimCurve.Y1Multiplier));
                }
                if (cimCurve.Y1UnitHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_Y1UNIT, (short)cimCurve.Y1Unit));
                }
                if (cimCurve.Y2MultiplierHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_Y2MULTIPILLER, (short)cimCurve.Y2Multiplier));
                }
                if (cimCurve.Y2UnitHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_Y2UNIT, (short)cimCurve.Y2Unit));
                }
                if (cimCurve.Y3MultiplierHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_Y3MULTIPILLER, (short)cimCurve.Y3Multiplier));
                }
                if (cimCurve.Y3UnitHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVE_Y3UNIT, (short)cimCurve.Y3Unit));
                }
            }
        }
        public static void PopulateCurveDataProperties(FTN.CurveData cimCurveData, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimCurveData != null) && (rd != null))
            {
                PopulateIdentifiedObjectProperties(cimCurveData, rd);

                if (cimCurveData.XvalueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVEDATA_XVALUE, cimCurveData.Xvalue));
                }
                if (cimCurveData.Y1valueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVEDATA_Y1VALUE, cimCurveData.Y1value));
                }
                if (cimCurveData.Y2valueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVEDATA_Y2VALUE, cimCurveData.Y2value));
                }
                if (cimCurveData.Y3valueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CURVEDATA_Y3VALUE, cimCurveData.Y3value));
                }
                if (cimCurveData.CurveHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimCurveData.Curve.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimCurveData.GetType().ToString()).Append(" rdfID = \"").Append(cimCurveData.ID);
                        report.Report.Append("\" - Failed to set reference to Curve: rdfID \"").Append(cimCurveData.Curve).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.CURVEDATA_CURVE, gid));
                }
            }
        }

        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerSystemResource != null) && (rd != null))
            {
                PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);

                if (cimPowerSystemResource.OutageScheduleHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimPowerSystemResource.OutageSchedule.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
                        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimPowerSystemResource.OutageSchedule).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.PSR_OUTAGESCHEDULE, gid));
                }
            }
        }
        public static void PopulateIrregularTimePointProperties(FTN.IrregularTimePoint cimIrregularTimePoint, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimIrregularTimePoint != null) && (rd != null))
            {
                PopulateIdentifiedObjectProperties(cimIrregularTimePoint, rd);

                if (cimIrregularTimePoint.Value1HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IRREGULARTIMEPOINT_VALUE1, cimIrregularTimePoint.Value1));
                }
                if (cimIrregularTimePoint.Value2HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IRREGULARTIMEPOINT_VALUE2, cimIrregularTimePoint.Value2));
                }
                if (cimIrregularTimePoint.TimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IRREGULARTIMEPOINT_TIME, cimIrregularTimePoint.Time));
                }

                if (cimIrregularTimePoint.IntervalScheduleHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimIrregularTimePoint.IntervalSchedule.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimIrregularTimePoint.GetType().ToString()).Append(" rdfID = \"").Append(cimIrregularTimePoint.ID);
                        report.Report.Append("\" - Failed to set reference to IntervalSchedule: rdfID \"").Append(cimIrregularTimePoint.IntervalSchedule).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE, gid));
                }
            }
        }

        public static void PopulateSwitchingOperationProperties(FTN.SwitchingOperation cimSwitchingOperation, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSwitchingOperation != null) && (rd != null))
            {
                PopulateIdentifiedObjectProperties(cimSwitchingOperation, rd);

                if (cimSwitchingOperation.NewStateHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SWITCHINGOPERATION_NEWSTATE, (short)cimSwitchingOperation.NewState));

                }
                if (cimSwitchingOperation.OperationTimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SWITCHINGOPERATION_OPERATIONTIME, cimSwitchingOperation.OperationTime));

                }

                if (cimSwitchingOperation.OutageScheduleHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSwitchingOperation.OutageSchedule.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSwitchingOperation.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitchingOperation.ID);
                        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimSwitchingOperation.OutageSchedule).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE, gid));
                }

            }
        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimEquipment != null) && (rd != null))
            {
                PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);
            }
        }
        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                // Populate properties from the base class Equipment
                PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);

                // No additional properties for ConductingEquipment, so no further action is required.
            }
        }
        public static void PopulateSwitchProperties(FTN.Switch cimSwitch, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSwitch != null) && (rd != null))
            {
                // Populate properties from the base class ConductingEquipment
                PopulateConductingEquipmentProperties(cimSwitch, rd, importHelper, report);

                // Populate Switch-specific properties
                if (cimSwitch.SwitchingOperationsHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSwitch.SwitchingOperations.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSwitch.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitch.ID);
                        report.Report.Append("\" - Failed to set reference to SwitchingOperations: rdfID \"").Append(cimSwitch.SwitchingOperations).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.SWITCH_SWITCHINGOPERATION, gid));
                }
            }
        }

        public static void PopulateGroundDisconnectorProperties(FTN.GroundDisconnector cimGroundDisconnector, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimGroundDisconnector != null) && (rd != null))
            {
                PopulateSwitchProperties(cimGroundDisconnector, rd, importHelper, report);
            }
        }

        public static void PopulateIrregularIntervalScheduleProperties(FTN.IrregularIntervalSchedule cimIrregularIntervalSchedule, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimIrregularIntervalSchedule != null) && (rd != null))
            {
                PopulateBasicIntervalScheduleProperties(cimIrregularIntervalSchedule, rd);

            }
        }

        public static void PopulateOutageScheduleProperties(FTN.OutageSchedule cimOutageSchedule, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimOutageSchedule != null) && (rd != null))
            {
                PopulateIrregularIntervalScheduleProperties(cimOutageSchedule, rd, importHelper, report);

                if (cimOutageSchedule.PowerSystemResourceHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimOutageSchedule.PowerSystemResource.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimOutageSchedule.GetType().ToString()).Append(" rdfID = \"").Append(cimOutageSchedule.ID);
                        report.Report.Append("\" - Failed to set reference to PSR: rdfID \"").Append(cimOutageSchedule.PowerSystemResource.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    else
                    {
                        rd.AddProperty(new Property(ModelCode.OUTAGESCHEDULE_PSR, gid));
                    }
                }

            }
        }


        /*
        public static void PopulateLocationProperties(FTN.Location cimLocation, ResourceDescription rd)
        {
            if ((cimLocation != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimLocation, rd);

                if (cimLocation.CategoryHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.LOCATION_CATEGORY, cimLocation.Category));
                }
                if (cimLocation.CorporateCodeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.LOCATION_CORPORATECODE, cimLocation.CorporateCode));
                }
            }
        }

        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerSystemResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);

                if (cimPowerSystemResource.CustomTypeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PSR_CUSTOMTYPE, cimPowerSystemResource.CustomType));
                }
                if (cimPowerSystemResource.LocationHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimPowerSystemResource.Location.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
                        report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimPowerSystemResource.Location.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.PSR_LOCATION, gid));
                }
            }
        }

        public static void PopulateBaseVoltageProperties(FTN.BaseVoltage cimBaseVoltage, ResourceDescription rd)
        {
            if ((cimBaseVoltage != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimBaseVoltage, rd);

                if (cimBaseVoltage.NominalVoltageHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, cimBaseVoltage.NominalVoltage));
                }
            }
        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);

                if (cimEquipment.PrivateHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_ISPRIVATE, cimEquipment.Private));
                }
                if (cimEquipment.IsUndergroundHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_ISUNDERGROUND, cimEquipment.IsUnderground));
                }
            }
        }

        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);

                if (cimConductingEquipment.PhasesHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CONDEQ_PHASES, (short)GetDMSPhaseCode(cimConductingEquipment.Phases)));
                }
                if (cimConductingEquipment.RatedVoltageHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CONDEQ_RATEDVOLTAGE, cimConductingEquipment.RatedVoltage));
                }
                if (cimConductingEquipment.BaseVoltageHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimConductingEquipment.BaseVoltage.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimConductingEquipment.GetType().ToString()).Append(" rdfID = \"").Append(cimConductingEquipment.ID);
                        report.Report.Append("\" - Failed to set reference to BaseVoltage: rdfID \"").Append(cimConductingEquipment.BaseVoltage.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.CONDEQ_BASVOLTAGE, gid));
                }
            }
        }

        public static void PopulatePowerTransformerProperties(FTN.PowerTransformer cimPowerTransformer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerTransformer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentProperties(cimPowerTransformer, rd, importHelper, report);

                if (cimPowerTransformer.FunctionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTR_FUNC, (short)GetDMSTransformerFunctionKind(cimPowerTransformer.Function)));
                }
                if (cimPowerTransformer.AutotransformerHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTR_AUTO, cimPowerTransformer.Autotransformer));
                }
            }
        }

        public static void PopulateTransformerWindingProperties(FTN.TransformerWinding cimTransformerWinding, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTransformerWinding != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimTransformerWinding, rd, importHelper, report);

                if (cimTransformerWinding.ConnectionTypeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_CONNTYPE, (short)GetDMSWindingConnection(cimTransformerWinding.ConnectionType)));
                }
                if (cimTransformerWinding.GroundedHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_GROUNDED, cimTransformerWinding.Grounded));
                }
                if (cimTransformerWinding.RatedSHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDS, cimTransformerWinding.RatedS));
                }
                if (cimTransformerWinding.RatedUHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDU, cimTransformerWinding.RatedU));
                }
                if (cimTransformerWinding.WindingTypeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_WINDTYPE, (short)GetDMSWindingType(cimTransformerWinding.WindingType)));
                }
                if (cimTransformerWinding.PhaseToGroundVoltageHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOGRNDVOLTAGE, cimTransformerWinding.PhaseToGroundVoltage));
                }
                if (cimTransformerWinding.PhaseToPhaseVoltageHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOPHASEVOLTAGE, cimTransformerWinding.PhaseToPhaseVoltage));
                }
                if (cimTransformerWinding.PowerTransformerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTransformerWinding.PowerTransformer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTransformerWinding.GetType().ToString()).Append(" rdfID = \"").Append(cimTransformerWinding.ID);
                        report.Report.Append("\" - Failed to set reference to PowerTransformer: rdfID \"").Append(cimTransformerWinding.PowerTransformer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, gid));
                }
            }
        }

        public static void PopulateWindingTestProperties(FTN.WindingTest cimWindingTest, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimWindingTest != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimWindingTest, rd);

                if (cimWindingTest.LeakageImpedanceHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDN, cimWindingTest.LeakageImpedance));
                }
                if (cimWindingTest.LoadLossHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_LOADLOSS, cimWindingTest.LoadLoss));
                }
                if (cimWindingTest.NoLoadLossHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_NOLOADLOSS, cimWindingTest.NoLoadLoss));
                }
                if (cimWindingTest.PhaseShiftHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_PHASESHIFT, cimWindingTest.PhaseShift));
                }
                if (cimWindingTest.LeakageImpedance0PercentHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDN0PERCENT, cimWindingTest.LeakageImpedance0Percent));
                }
                if (cimWindingTest.LeakageImpedanceMaxPercentHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDNMAXPERCENT, cimWindingTest.LeakageImpedanceMaxPercent));
                }
                if (cimWindingTest.LeakageImpedanceMinPercentHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDNMINPERCENT, cimWindingTest.LeakageImpedanceMinPercent));
                }

                if (cimWindingTest.From_TransformerWindingHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimWindingTest.From_TransformerWinding.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimWindingTest.GetType().ToString()).Append(" rdfID = \"").Append(cimWindingTest.ID);
                        report.Report.Append("\" - Failed to set reference to TransformerWinding: rdfID \"").Append(cimWindingTest.From_TransformerWinding.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.WINDINGTEST_POWERTRWINDING, gid));
                }
            }
        }*/
        #endregion Populate ResourceDescription

        #region Enums convert
        public static SwitchState GetSwitchState(FTN.SwitchState switchState)
        {
            switch (switchState)
            {
                case FTN.SwitchState.open:
                    return SwitchState.open;
                case FTN.SwitchState.close:
                    return SwitchState.close;
                default: return SwitchState.open;
            }
        }
        public static UnitMultiplier GetUnitMultiplier(FTN.UnitMultiplier unitMultiplier)
        {
            switch (unitMultiplier)
            {
                case FTN.UnitMultiplier.G:
                    return UnitMultiplier.G;
                case FTN.UnitMultiplier.M:
                    return UnitMultiplier.M;
                case FTN.UnitMultiplier.T:
                    return UnitMultiplier.T;
                case FTN.UnitMultiplier.c:
                    return UnitMultiplier.c;
                case FTN.UnitMultiplier.d:
                    return UnitMultiplier.d;
                case FTN.UnitMultiplier.k:
                    return UnitMultiplier.k;
                case FTN.UnitMultiplier.m:
                    return UnitMultiplier.m;
                case FTN.UnitMultiplier.micro:
                    return UnitMultiplier.micro;
                case FTN.UnitMultiplier.n:
                    return UnitMultiplier.n;
                case FTN.UnitMultiplier.none:
                    return UnitMultiplier.none;
                case FTN.UnitMultiplier.p:
                    return UnitMultiplier.p;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unitMultiplier), unitMultiplier, null);
            }
        }

        public static UnitSymbol GetUnitSymbol(FTN.UnitSymbol unitSymbol)
        {
            switch (unitSymbol)
            {
                case FTN.UnitSymbol.A:
                    return UnitSymbol.A;
                case FTN.UnitSymbol.F:
                    return UnitSymbol.F;
                case FTN.UnitSymbol.H:
                    return UnitSymbol.H;
                case FTN.UnitSymbol.Hz:
                    return UnitSymbol.Hz;
                case FTN.UnitSymbol.J:
                    return UnitSymbol.J;
                case FTN.UnitSymbol.N:
                    return UnitSymbol.N;
                case FTN.UnitSymbol.Pa:
                    return UnitSymbol.Pa;
                case FTN.UnitSymbol.S:
                    return UnitSymbol.S;
                case FTN.UnitSymbol.V:
                    return UnitSymbol.V;
                case FTN.UnitSymbol.VA:
                    return UnitSymbol.VA;
                case FTN.UnitSymbol.VAh:
                    return UnitSymbol.VAh;
                case FTN.UnitSymbol.VAr:
                    return UnitSymbol.VAr;
                case FTN.UnitSymbol.VArh:
                    return UnitSymbol.VArh;
                case FTN.UnitSymbol.W:
                    return UnitSymbol.W;
                case FTN.UnitSymbol.Wh:
                    return UnitSymbol.Wh;
                case FTN.UnitSymbol.deg:
                    return UnitSymbol.deg;
                case FTN.UnitSymbol.degC:
                    return UnitSymbol.degC;
                case FTN.UnitSymbol.g:
                    return UnitSymbol.g;
                case FTN.UnitSymbol.h:
                    return UnitSymbol.h;
                case FTN.UnitSymbol.m:
                    return UnitSymbol.m;
                case FTN.UnitSymbol.m2:
                    return UnitSymbol.m2;
                case FTN.UnitSymbol.m3:
                    return UnitSymbol.m3;
                case FTN.UnitSymbol.min:
                    return UnitSymbol.min;
                case FTN.UnitSymbol.none:
                    return UnitSymbol.none;
                case FTN.UnitSymbol.ohm:
                    return UnitSymbol.ohm;
                case FTN.UnitSymbol.rad:
                    return UnitSymbol.rad;
                case FTN.UnitSymbol.s:
                    return UnitSymbol.s;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unitSymbol), unitSymbol, null);
            }
        }
        public static CurveStyle GetCurveStyle(FTN.CurveStyle curveStyle)
        {
            switch (curveStyle)
            {
                case FTN.CurveStyle.constantYValue:
                    return CurveStyle.constantYValue;
                case FTN.CurveStyle.formula:
                    return CurveStyle.formula;
                case FTN.CurveStyle.rampYValue:
                    return CurveStyle.rampYValue;
                case FTN.CurveStyle.straightLineYValues:
                    return CurveStyle.straightLineYValues;
                default:
                    throw new ArgumentOutOfRangeException(nameof(curveStyle), curveStyle, null);
            }
        }

        /*
		public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
		{
			switch (phases)
			{
				case FTN.PhaseCode.A:
					return PhaseCode.A;
				case FTN.PhaseCode.AB:
					return PhaseCode.AB;
				case FTN.PhaseCode.ABC:
					return PhaseCode.ABC;
				case FTN.PhaseCode.ABCN:
					return PhaseCode.ABCN;
				case FTN.PhaseCode.ABN:
					return PhaseCode.ABN;
				case FTN.PhaseCode.AC:
					return PhaseCode.AC;
				case FTN.PhaseCode.ACN:
					return PhaseCode.ACN;
				case FTN.PhaseCode.AN:
					return PhaseCode.AN;
				case FTN.PhaseCode.B:
					return PhaseCode.B;
				case FTN.PhaseCode.BC:
					return PhaseCode.BC;
				case FTN.PhaseCode.BCN:
					return PhaseCode.BCN;
				case FTN.PhaseCode.BN:
					return PhaseCode.BN;
				case FTN.PhaseCode.C:
					return PhaseCode.C;
				case FTN.PhaseCode.CN:
					return PhaseCode.CN;
				case FTN.PhaseCode.N:
					return PhaseCode.N;
				case FTN.PhaseCode.s12N:
					return PhaseCode.ABN;
				case FTN.PhaseCode.s1N:
					return PhaseCode.AN;
				case FTN.PhaseCode.s2N:
					return PhaseCode.BN;
				default: return PhaseCode.Unknown;
			}
		}

		public static TransformerFunction GetDMSTransformerFunctionKind(FTN.TransformerFunctionKind transformerFunction)
		{
			switch (transformerFunction)
			{
				case FTN.TransformerFunctionKind.voltageRegulator:
					return TransformerFunction.Voltreg;
				default:
					return TransformerFunction.Consumer;
			}
		}

		public static WindingType GetDMSWindingType(FTN.WindingType windingType)
		{
			switch (windingType)
			{
				case FTN.WindingType.primary:
					return WindingType.Primary;
				case FTN.WindingType.secondary:
					return WindingType.Secondary;
				case FTN.WindingType.tertiary:
					return WindingType.Tertiary;
				default:
					return WindingType.None;
			}
		}

		public static WindingConnection GetDMSWindingConnection(FTN.WindingConnection windingConnection)
		{
			switch (windingConnection)
			{
				case FTN.WindingConnection.D:
					return WindingConnection.D;
				case FTN.WindingConnection.I:
					return WindingConnection.I;
				case FTN.WindingConnection.Z:
					return WindingConnection.Z;
				case FTN.WindingConnection.Y:
					return WindingConnection.Y;
				default:
					return WindingConnection.Y;
			}
		}
		*/
        #endregion Enums convert
    }
}
