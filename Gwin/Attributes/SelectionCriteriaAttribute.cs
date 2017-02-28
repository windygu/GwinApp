using System;

namespace App.Gwin.Attributes
{
    public  class SelectionCriteriaAttribute : Attribute
    {
        public Type[] Criteria { set; get; }

        public SelectionCriteriaAttribute(params Type[] Criteria)
        {
            this.Criteria = Criteria;
        }
    }
}