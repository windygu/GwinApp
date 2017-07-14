using App.Gwin.Entities;
using System.Collections.Generic;

namespace App.Gwin
{
    public interface IInputCollectionControle
    {
       List<BaseEntity> Value { get; }
    }
}