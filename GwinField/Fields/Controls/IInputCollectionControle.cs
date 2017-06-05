using GApp.GwinApp.Entities;
using System.Collections.Generic;

namespace GApp.GwinApp
{
    public interface IInputCollectionControle
    {
       List<BaseEntity> Value { get; }
    }
}