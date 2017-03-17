using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;
using App.Gwin.DataModel.ModelInfo;
using App.Gwin.Entities;
using App.Shared.AttributesManager;
using App.Gwin.Attributes;
using App.Gwin.FieldsTraitements;
using App.Gwin;
using GenericWinForm.Demo.BAL;
using App.Gwin.Application.Presentation.MainForm;

namespace GenericWinFormTests.Entities
{
    [TestClass]
    public class EntitiesTest
    {
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);

        }

        [TestMethod]
        public void TestAllEntities()
        {
            // Test All EntryForm
            using (ModelContext db = new ModelContext())
            {
                foreach (var TypeEntity in new GwinEntitiesManager().GetAll_Entities_Type())
                {
                    var EntityInstance = Activator.CreateInstance(TypeEntity) ;
                    ConfigEntity configEntity =  ConfigEntity.CreateConfigEntity(TypeEntity);

                    // Set Values
                    foreach (var prorpertyInfo in TypeEntity.GetProperties())
                    {
                        ConfigProperty configProperty = new ConfigProperty(prorpertyInfo, configEntity);
                        IFieldTraitements fieldTraitement = FieldTraitement.CreateInstance(configProperty);
                        var value = fieldTraitement.GetTestValue(prorpertyInfo);
                        prorpertyInfo.SetValue(EntityInstance, value);
                    }

                    // GetValues
                    foreach (var prorpertyInfo in TypeEntity.GetProperties())
                    {
                       

                        ConfigProperty configProperty = new ConfigProperty(prorpertyInfo, configEntity);
                        IFieldTraitements fieldTraitement = FieldTraitement.CreateInstance(configProperty);
                        var value = prorpertyInfo.GetValue(EntityInstance);
                      
                        var Exptected = fieldTraitement.GetTestValue(prorpertyInfo);
                        Assert.AreEqual(Exptected, value);
                    }



                }
            }
        }
    }
}
