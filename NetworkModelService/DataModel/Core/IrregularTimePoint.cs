using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Outage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class IrregularTimePoint : IdentifiedObject
    {
        //sekunde, kako
        private int time;
        private float value1;
        private float value2;
        private long intervalSchedule;
             
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public float Value1
        {
            get { return value1; }
            set { value1 = value; }
        }
        public float Value2
        {
            get { return value2; }
            set { value2 = value; }
        }
        public long IntervalSchedule
        {
            get { return intervalSchedule; }
            set { intervalSchedule = value; }
        }
        public IrregularTimePoint(long globalId) : base(globalId)
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                IrregularTimePoint x = (IrregularTimePoint)obj;
                return ((x.value1 == this.value1) &&
                         (x.value2 == this.value2) &&
                         (x.time == this.time) &&
                        (x.intervalSchedule==this.intervalSchedule));
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
                case ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE:
                case ModelCode.IRREGULARTIMEPOINT_TIME:
                case ModelCode.IRREGULARTIMEPOINT_VALUE1:
                case ModelCode.IRREGULARTIMEPOINT_VALUE2:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.IRREGULARTIMEPOINT_TIME:
                    prop.SetValue(time);
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE1:
                    prop.SetValue(value1);
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE2:
                    prop.SetValue(value2);
                    break;
                case ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE:
                    prop.SetValue(intervalSchedule);
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
                case ModelCode.IRREGULARTIMEPOINT_TIME:
                    time= property.AsInt();
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE1:
                    value1 = property.AsFloat();
                    break;
                case ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE:
                    intervalSchedule = property.AsReference();
                    break;
                case ModelCode.IRREGULARTIMEPOINT_VALUE2:
                    value2 = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation	

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (intervalSchedule != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE] = new List<long>();
                references[ModelCode.IRREGULARTIMEPOINT_IRREGULARINTERVALSCHEDULE].Add(intervalSchedule);
            }


        }
        #endregion IReference implementation
    }
}
