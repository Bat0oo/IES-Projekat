using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.IES_Projects;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class IrregularIntervalSchedule : BasicIntervalSchedule
    {
        public IrregularIntervalSchedule(long globalId) : base(globalId)
        {
        }
        private List<long> timePoints;
        public List<long> TimePoints
        {
            get { return timePoints; }
            set { timePoints = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                IrregularIntervalSchedule x = (IrregularIntervalSchedule)obj;
                return (CompareHelper.CompareLists(x.timePoints, this.timePoints));

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
                case ModelCode.IRREGULARINTERVALSCHEDULE_IRREGULARTIMEPOINT:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.IRREGULARINTERVALSCHEDULE_IRREGULARTIMEPOINT:
                    property.SetValue(timePoints);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            base.SetProperty(property);
        }
        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return timePoints.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (timePoints != null && timePoints.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.IRREGULARINTERVALSCHEDULE_IRREGULARTIMEPOINT] = timePoints.GetRange(0, timePoints.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE:
                    timePoints.Add(globalId);
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
                case ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE:

                    if (timePoints.Contains(globalId))
                    {
                        timePoints.Remove(globalId);
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

