using GApp.GwinApp;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Application.Presentation.MainForm;
using GApp.GwinApp.Attributes;
using GApp.GwinApp.Entities.Secrurity.Authentication;
using GApp.GwinApp.Fields;
using GenericWinForm.Demo.BAL;
using GenericWinForm.Demo.DAL;
using GenericWinForm.Demo.Entities.ProjectManager;
using GenericWinForm.Demo.Entities.TraineeManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwinTest.Components.Fields
{
    [TestClass()]
    public class ManyToManyFieldTest
    {
        [TestInitialize]
        public void GwinAppStart()
        {
            User user = User.CreateRootUser(new ModelContext());
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), user);
        }

        [TestMethod()]
        public void ManyToOneField_CreateInstanceTest()
        {
            // Model Data : Trainee, Groupe, Speciality
            using (ModelContext db = new ModelContext())
            {
                Panel Container = new Panel();
                Size SizeLabel = new Size(100, 20);
                Size SizeControl = new Size(100, 20);

                IGwinBaseBLO GroupeBLO = new GwinBaseBLO<Group>(db);
                PropertyInfo TaskProjectsPropertyInfo = typeof(Group).GetProperty(nameof(Group.TaskProjects));
                ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(typeof(Group));
                Trainee trainee = new Trainee();



                ManyToManyField ManyToManyField = new ManyToManyField(
                    TaskProjectsPropertyInfo,
                     Orientation.Vertical,
                      SizeLabel,
                    SizeControl,
                    configEntity,
                    Container,
                    GroupeBLO);

                // Selected the first speciality
                // selectedindex = 1 , index 0 for EmptyData
                ManyToManyField
                    .SelectionFilterManager
                    .ListeComboBox[typeof(Project).Name]
                    .SelectedIndex = 1;

              
               
            }
        }
    }
}
