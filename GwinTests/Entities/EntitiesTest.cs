using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp;
using GApp.GwinApp.DataModel.ModelInfo;
using GApp.GwinApp.Entities;
using GApp.Shared.AttributesManager;
using GApp.GwinApp.Attributes;
using GApp.GwinApp.FieldsTraitements;
using GApp.GwinApp;
using GenericWinForm.Demo.BAL;
using GApp.GwinApp.Application.Presentation.MainForm;
using System.Collections.Generic;
using GenericWinForm.Demo.DAL;

namespace GenericWinFormTests.Entities
{
    [TestClass]
    public class EntitiesTest
    {
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);

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

                    Dictionary<string, object> TestValyes = new Dictionary<string, object>();

                    

                    // Set Values
                    foreach (var prorpertyInfo in TypeEntity.GetProperties())
                    {
                        ConfigProperty configProperty = new ConfigProperty(prorpertyInfo, configEntity);
                        IFieldTraitements fieldTraitement = BaseFieldTraitement.CreateInstance(configProperty);
                        var value = fieldTraitement.GetTestValue(prorpertyInfo);
                        TestValyes[prorpertyInfo.Name] = value;
                        prorpertyInfo.SetValue(EntityInstance, value);
                    }

                    // GetValues
                    foreach (var prorpertyInfo in TypeEntity.GetProperties())
                    {
                       

                        ConfigProperty configProperty = new ConfigProperty(prorpertyInfo, configEntity);
                        IFieldTraitements fieldTraitement = BaseFieldTraitement.CreateInstance(configProperty);
                        var value = prorpertyInfo.GetValue(EntityInstance);
                        var Exptected = TestValyes[prorpertyInfo.Name];
                 
                       
                    }



                }
            }
        }
    }
}
