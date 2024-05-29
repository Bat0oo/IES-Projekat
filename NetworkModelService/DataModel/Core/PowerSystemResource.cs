using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FTN.Common;



namespace FTN.Services.NetworkModelService.DataModel.Core
{
	public class PowerSystemResource : IdentifiedObject
	{

		private long outageSchedule = 0;
		public PowerSystemResource(long globalId)
			: base(globalId)
		{
		}	
		public long OutageSchedule
		{
			get { return outageSchedule; }
			set { outageSchedule = value; }
		}
		
		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
                PowerSystemResource x = (PowerSystemResource)obj;
                return ((x.outageSchedule==this.outageSchedule));

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
                case ModelCode.PSR_OUTAGESCHEDULE:

                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

		public override void GetProperty(Property property)
		{
            switch (property.Id)
            {
                case ModelCode.PSR_OUTAGESCHEDULE:
                    property.SetValue(outageSchedule);
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
                case ModelCode.PSR_OUTAGESCHEDULE:
                    outageSchedule = property.AsReference();
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
			if (outageSchedule != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.PSR_OUTAGESCHEDULE] = new List<long>();
				references[ModelCode.PSR_OUTAGESCHEDULE].Add(outageSchedule);
			}
			
			base.GetReferences(references, refType);			
		}

		#endregion IReference implementation		
	}
}
