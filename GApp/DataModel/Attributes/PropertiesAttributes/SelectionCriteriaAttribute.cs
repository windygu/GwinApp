using System;

namespace GApp.GwinApp.Attributes
{
    public  class SelectionCriteriaAttribute : Attribute
    {
        public Type[] CriteriasTypes { set; get; }

        public SelectionCriteriaAttribute(params Type[] CriteriasTypes)
        {
            this.CriteriasTypes = CriteriasTypes;
        }
    }
}