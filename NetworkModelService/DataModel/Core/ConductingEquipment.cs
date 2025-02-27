﻿using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConductingEquipment : Equipment
    {

        public ConductingEquipment(long globalId) : base(globalId)
        {
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConductingEquipment x = (ConductingEquipment)obj;
                return true;
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
            return base.HasProperty(property);

        }

        public override void GetProperty(Property prop)
        {
            base.GetProperty(prop);
        }

        public override void SetProperty(Property property)
        {

            base.SetProperty(property);

        }

        #endregion IAccess implementation


    }
}
