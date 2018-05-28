using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Crest.Data;
using Crest;
using Crest.Data.Exceptions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Crest.Data.Interfaces;

namespace Crest.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestProjectSaving()
        {
            string path = "";
            using (var folderBrowsingDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowsingDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowsingDialog.SelectedPath))
                    path = folderBrowsingDialog.SelectedPath;
            }
            path += "/newProject.prj";
            ProjectUtility.SaveProject(path, new Project("Aurora", "Agmiles", new List<string> { "C#" } , ProjectType.CSharp_Project));
        }

        [TestMethod]
        public async void TestProjectLoading()
        {
            Stream loadStream = null;
            string result = "";
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Project files | *.prj",
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((loadStream = openFileDialog.OpenFile()) != null)
                    using (StreamReader reader = new StreamReader(loadStream))
                    {
                        result = await reader.ReadToEndAsync();
                    }
            }
            var project = new Project("Aurora", "Agmiles", new List<string> { "C#" }, ProjectType.CSharp_Project);
            var newProject = ProjectUtility.CreateProject(result) as Project;
            
            Assert.AreEqual(project.ProjectType, newProject.ProjectType);
        }

        [TestMethod]
        public void TestingSingleton()
        {

        }
    }
}
