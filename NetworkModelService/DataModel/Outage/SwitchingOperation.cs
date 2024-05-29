using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Outage
{
    public class SwitchingOperation : IdentifiedObject
    {
        private SwitchState newState;
        private DateTime operationTime;
        //liste referenci
        private List<long> switches=new List<long>();
        private long outageSchedule = 0;
        public SwitchingOperation(long globalId) : base(globalId)
        {
        }

        public SwitchState NewState
        {
            get { return newState; }
            set { newState = value; }
        }
        public DateTime OperationTime
        {
            get { return operationTime; }
            set { operationTime = value; }
        }
        public List<long> Switches { get => switches; set => switches = value; }
        public long OutageSchedule {  get => outageSchedule; set => outageSchedule = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SwitchingOperation x = (SwitchingOperation)obj;
                return ((x.newState == this.newState) &&
                         (x.operationTime== this.operationTime) &&
                         (x.outageSchedule == this.outageSchedule) &&
                        (CompareHelper.CompareLists(x.switches, this.switches)));
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                case ModelCode.SWITCHINGOPERATION_SWITCH:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                    prop.SetValue((short)newState);
                    break;
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                    prop.SetValue(operationTime);
                    break;
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    prop.SetValue(outageSchedule);
                    break;
                case ModelCode.SWITCHINGOPERATION_SWITCH:
                    prop.SetValue(switches);
                    break;
                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                    newState = (SwitchState)property.AsEnum();
                    break;
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                    operationTime = property.AsDateTime();
                    break;
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    outageSchedule = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation	

        #region IReference implementation
        public override bool IsReferenced
        {
            get
            {
                return switches.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (outageSchedule != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE] = new List<long>();
                references[ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE].Add(outageSchedule);
            }

            if (switches != null && switches.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.SWITCHINGOPERATION_SWITCH] = switches.GetRange(0, switches.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCH_SWITCHINGOPERATION:
                    switches.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCH_SWITCHINGOPERATION:

                    if (switches.Contains(globalId))
                    {
                        switches.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }


        #endregion IReference implementation	
    }
}
