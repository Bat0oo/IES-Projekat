using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Outage
{
    public class OutageSchedule : IrregularIntervalSchedule
    {
        private long pSR = 0;
        private List<long> switchingOperations= new List<long>();
        public long PSR
        {
            get { return pSR; }
            set { pSR = value; }
        }
        public List<long> SwitchingOperations { get => switchingOperations; set => switchingOperations = value; }
        public OutageSchedule(long globalId) : base(globalId)
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                OutageSchedule x = (OutageSchedule)obj;
                return ((x.pSR==this.pSR)&& CompareHelper.CompareLists(x.switchingOperations, this.switchingOperations));

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

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.OUTAGESCHEDULE_PSR:
                case ModelCode.OUTAGESCHEDULE_SWITCHINGOPERATION:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                

                case ModelCode.OUTAGESCHEDULE_PSR:
                    property.SetValue(pSR);
                    break;

                case ModelCode.OUTAGESCHEDULE_SWITCHINGOPERATION:
                    property.SetValue(switchingOperations);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.OUTAGESCHEDULE_PSR:
                    pSR = property.AsReference();
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
                return switchingOperations.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (pSR != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.OUTAGESCHEDULE_PSR] = new List<long>();
                references[ModelCode.OUTAGESCHEDULE_PSR].Add(pSR);
            }

            if (switchingOperations != null && switchingOperations.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.OUTAGESCHEDULE_SWITCHINGOPERATION] = switchingOperations.GetRange(0, switchingOperations.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    switchingOperations.Add(globalId);
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
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:

                    if (switchingOperations.Contains(globalId))
                    {
                        switchingOperations.Remove(globalId);
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
