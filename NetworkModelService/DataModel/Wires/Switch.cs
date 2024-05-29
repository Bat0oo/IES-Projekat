using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Switch : ConductingEquipment
    {
        private long switchingOperations = 0;
        public Switch(long globalId) : base(globalId)
        {
        }
        public long SwitchingOperations
        {
            get { return switchingOperations; }
            set { switchingOperations = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Switch x = (Switch)obj;
                return ((x.switchingOperations == this.switchingOperations));
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

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.SWITCH_SWITCHINGOPERATION:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SWITCH_SWITCHINGOPERATION:
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
                case ModelCode.SWITCH_SWITCHINGOPERATION:
                    switchingOperations = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (switchingOperations != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.SWITCH_SWITCHINGOPERATION] = new List<long>();
                references[ModelCode.SWITCH_SWITCHINGOPERATION].Add(switchingOperations);
            }

            base.GetReferences(references, refType);
        }
    }
}
